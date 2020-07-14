using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using JobFinder.Data;
using JobFinder.Data.Repositories;
using JobFinder.Models;
using JobFinder.Models.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobFinder.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly TemplatesRepository _templatesRepository;
        private readonly ApplicationsRepository _applicationsRepository;
        private readonly CompanyUsersRepository _companyUsersRepository;
        private readonly ApplicationEducationsRepository _applicationEducationsRepository;
        private readonly ApplicationSkillsRepository _applicationSkillsRepository;
        private readonly ApplicationWorkExperiencesRepository _applicationWorkExperience;

        private readonly DBApplicationContext _dbContext;

        public ApplicationsController(DBApplicationContext context)
        {
            _dbContext = context;
            _templatesRepository = new TemplatesRepository(context);
            _applicationsRepository = new ApplicationsRepository(context);
            _companyUsersRepository = new CompanyUsersRepository(context);
            _applicationEducationsRepository = new ApplicationEducationsRepository(context);
            _applicationSkillsRepository = new ApplicationSkillsRepository(context);
            _applicationWorkExperience = new ApplicationWorkExperiencesRepository(context);
        }


        [Authorize(Roles = "hr")]
        [Route("/applications")]
        public ActionResult Index()
        {
            int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);
            List<Application> applications = _applicationsRepository.GetApplicationsByHRUser(userIdCurrentlyLoggedIn);
            ViewBag.SelectedNav = "Dashboard";
            return View(applications);
        }

        [Authorize(Roles = "hr, candidate")]
        [Route("/applications/{applicationId}")]
        public ActionResult Details(int applicationId)
        {
            // get application
            Application application = _applicationsRepository.GetApplicationById(applicationId);

            // get current user logged in
            int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);
            
            // check if application does not exists
            if (application == null)
            {
                return NotFound();
            }

            // check if application is not made by the applicant
            if (User.IsInRole("candidate"))
            {
                ViewBag.SelectedNav = "Profile";
                if (application.JobFinderUser.UserId != userIdCurrentlyLoggedIn)
                {
                    return NotFound();
                }
            }

            // check if company user is not assigned to see the job listing
            if (User.IsInRole("hr"))
            {
                ViewBag.SelectedNav = "Dashboard";
                int companyId = application.JobListing.Company.CompanyId;
                if (!_companyUsersRepository.CompanyUserExists(userIdCurrentlyLoggedIn, companyId))
                {
                    return NotFound();
                }
            }

            // retrieve data for application
            ApplicationEducation applicationEducation = _applicationEducationsRepository.GetApplicationEducationForApplication(applicationId);
            ApplicationWorkExperience applicationWorkExperience = _applicationWorkExperience.GetApplicationWorkExperienceForApplication(applicationId);
            ApplicationSkill applicationSkill = _applicationSkillsRepository.GetApplicationSkillForApplication(applicationId);

            // build a list for potential application statuses
            List<string> ApplicationStatuses = new List<string> { "Pending", "Contacted", "Accepted", "Rejected" };

            // build up a view model with all the data required to see an application
            ViewApplicationViewModel viewApplicationViewModel = new ViewApplicationViewModel
            {
                Application = application,
                ApplicationEducation = applicationEducation,
                ApplicationSkill = applicationSkill,
                ApplicationWorkExperience = applicationWorkExperience,
                OtherNotes = application.OtherNotes,
                Status = application.Status,
                ApplicationWrittenAt = application.ApplicationWrittenAt

            };
            ViewBag.ApplicationStatuses = new SelectList(ApplicationStatuses, ApplicationStatuses);
            return View(viewApplicationViewModel);
        }

        [Authorize(Roles = "candidate,hr,admin")]
        [Route("/jobs/{jobId}/apply")]
        public ActionResult Create(int? jobId)
        {
            Template jobTemplate = _templatesRepository.GetTemplateByJobId(jobId);
            if (jobTemplate == null)
            {
                return NotFound();
            }
            if(!Convert.ToBoolean(jobTemplate.JobListing.IsActive))
            {
                return RedirectToAction("Index");
            }

            int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);

            bool userAlreadyApplied = _applicationsRepository.UserAppliedAlready(userIdCurrentlyLoggedIn, jobId);
            if(userAlreadyApplied)
            {
                return RedirectToAction("Index");
            }

            ViewData["showWorkExperienceFields"] = jobTemplate.WorkExperience;
            ViewData["showSkillsFields"] = jobTemplate.Skills;
            ViewData["showEducationFields"] = jobTemplate.Education;
            ViewData["showOtherNotes"] = jobTemplate.OtherNotes;

            ViewData["JobId"] = jobId;
            ViewBag.SelectedNav = "Jobs";
            return View();
        }

        [Authorize(Roles = "candidate,hr,admin")]
        [Route("/jobs/{jobId}/apply")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int jobId, IFormCollection collection)
        {
            Template jobTemplate = _templatesRepository.GetTemplateByJobId(jobId);
            int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);

            Application application = new Application
            {
                Status = "Pending",
                UserId = userIdCurrentlyLoggedIn,
                ApplicationWrittenAt = DateTime.Now,
                JobListingId = jobId
            };

            if (jobTemplate.OtherNotes == 1)
            {
                application.OtherNotes = collection["otherNotes"];
            }

            int ApplicationId = _applicationsRepository.AddApplication(application);

            if (jobTemplate.WorkExperience == 1)
            {
                ApplicationWorkExperience newApplicationWorkExperience = new ApplicationWorkExperience
                {
                    CompanyName = collection["workExpCompanyName"],
                    StartDate = DateTime.Parse(collection["workExpStartDate"]),
                    EndDate = DateTime.Parse(collection["workExpEndDate"]),
                    Position = collection["workExpPosition"],
                    Responsibilities = collection["workExpResponsibilities"],
                    Duties = collection["workExpDuties"],
                    ApplicationId = ApplicationId
                };
                _dbContext.ApplicationWorkExperiences.Add(newApplicationWorkExperience);
                _dbContext.SaveChanges();
            }
            if (jobTemplate.Skills == 1)
            {
                ApplicationSkill newApplicationSkill = new ApplicationSkill
                {
                    Name = collection["skillName"],
                    Rating = Int16.Parse(collection["skillRating"]),
                    Description = collection["skillDescription"],
                    ApplicationId = ApplicationId
                };
                _dbContext.ApplicationSkills.Add(newApplicationSkill);
                _dbContext.SaveChanges();
            }
            if (jobTemplate.Education == 1)
            {
                ApplicationEducation newApplicationEducation = new ApplicationEducation
                {
                    SchoolName = collection["schoolName"],
                    StartDate = DateTime.Parse(collection["educationStartDate"]),
                    EndDate = DateTime.Parse(collection["educationEndDate"]),
                    Degree = collection["educationDegree"],
                    ApplicationId = ApplicationId
                };
                _dbContext.ApplicationEducations.Add(newApplicationEducation);
                _dbContext.SaveChanges();

            }

            ViewBag.SelectedNav = "Jobs";
            return RedirectToAction("Index", "Jobs");
        }

        [Authorize(Roles = "hr")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ModifyApplicationStatus([Bind("ApplicationId, Status")] Application application)
        {
            Application applicationFromDb = _dbContext.Applications.Find(application.ApplicationId);
            if(applicationFromDb == null)
            {
                return NotFound();
            }
            applicationFromDb.Status = application.Status;

            _applicationsRepository.ModifyApplicationStatus(applicationFromDb);

            return RedirectToAction("Index");
        }
    }
}
