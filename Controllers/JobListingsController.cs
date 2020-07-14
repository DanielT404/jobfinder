using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobFinder.Data;
using JobFinder.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using JobFinder.Data.Repositories;
using Microsoft.AspNetCore.Http;
using JobFinder.Models.ViewModels.Admin;

namespace JobFinder.Controllers
{
    [Authorize(Roles = "admin,hr")]
    public class JobListingsController : Controller
    {
        private readonly DBApplicationContext _dbContext;
        private readonly JobListingsRepository _jobListingsRepository;
        private readonly CompaniesRepository _companiesRepository;
        private readonly CategoriesRepository _categoriesRepository;
        private readonly TemplatesRepository _templatesRepository;

        public JobListingsController(DBApplicationContext context)
        {
            _dbContext = context;
            _jobListingsRepository = new JobListingsRepository(context);
            _companiesRepository = new CompaniesRepository(context);
            _categoriesRepository = new CategoriesRepository(context);
            _templatesRepository = new TemplatesRepository(context);

        }

        [Authorize(Roles = "hr")]
        [Route("/joblistings")]
        public ActionResult Index()
        {
            int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);
            List<JobListing> jobListings = _jobListingsRepository.GetJobListingsByUserId(userIdCurrentlyLoggedIn);
            ViewBag.SelectedNav = "Dashboard";
            return View(jobListings);
        }

        [Authorize(Roles = "hr")]
        [Route("/joblisting/details/{id}")]
        public ActionResult Details(int? id)
        {
            int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);
            if (id == null)
            {
                return NotFound();
            }

            JobListing jobListing = _jobListingsRepository.GetJobListingById(id);
            if (jobListing == null)
            {
                return NotFound();
            }
            ViewBag.SelectedNav = "Dashboard";
            return View(jobListing);
        }

        [Authorize(Roles = "hr")]
        [Route("/joblisting/{id}/applications")]
        public ActionResult ViewApplications(int? id)
        {
            int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);
            if (id == null)
            {
                return NotFound();
            }

            List<Application> applications = _jobListingsRepository.GetApplicationsByJobListing(id);
            if (applications == null)
            {
                return NotFound();
            }

            return View(applications);
        }

        [Authorize(Roles = "hr")]
        [Route("/joblisting/create")]
        public ActionResult Create()
        {
            int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);

            List<Company> companiesAssignedToUserLoggedIn = _companiesRepository.GetCompaniesAssignedToUser(userIdCurrentlyLoggedIn);
            List<Category> categories = _categoriesRepository.GetCategories();

            List<string> regions = new List<string> { "Africa", "Asia", "The Caribbean", "Central America", "Europe", "Oceania", "North America", "South America" };
            List<string> types = new List<string> { "Full Time", "Part Time", "Remote", "Voluntary or carity acts" };

            ViewData["Companies"] = new SelectList(companiesAssignedToUserLoggedIn, "CompanyId", "Name");
            ViewData["Categories"] = new SelectList(categories, "CategoryId", "Name");
            ViewData["Regions"] = new SelectList(regions, regions);
            ViewData["Types"] = new SelectList(types, types);
            ViewBag.SelectedNav = "Dashboard";
            return View();
        }

        [Authorize(Roles = "hr")]
        [Route("/joblisting/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(
            "Title,Type,Position,Region,Location,Description,IsActive,CategoryId,CompanyId,WorkExperience,Education,Skills,OtherNotes")]
        AddJobListingWithTemplateViewModel addJobListingWithTemplateViewModel)
        {
            int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);
            if (ModelState.IsValid)
            {
                JobListing jobListing = new JobListing
                {
                    Title = addJobListingWithTemplateViewModel.Title,
                    Type = addJobListingWithTemplateViewModel.Type,
                    Position = addJobListingWithTemplateViewModel.Position,
                    Region = addJobListingWithTemplateViewModel.Region,
                    Location = addJobListingWithTemplateViewModel.Location,
                    Description = addJobListingWithTemplateViewModel.Description,
                    IsActive = Convert.ToByte(addJobListingWithTemplateViewModel.IsActive),
                    JobListingAddedAt = DateTime.Now,
                    UserId = userIdCurrentlyLoggedIn,
                    CompanyId = addJobListingWithTemplateViewModel.CompanyId,
                    CategoryId = addJobListingWithTemplateViewModel.CategoryId
                };

                int jobListingId = _jobListingsRepository.AddJobListing(jobListing, userIdCurrentlyLoggedIn);

                if (jobListingId != 0)
                {
                    Template template = new Template
                    {
                        WorkExperience = Convert.ToByte(addJobListingWithTemplateViewModel.WorkExperience),
                        Skills = Convert.ToByte(addJobListingWithTemplateViewModel.Skills),
                        Education = Convert.ToByte(addJobListingWithTemplateViewModel.Education),
                        OtherNotes = Convert.ToByte(addJobListingWithTemplateViewModel.OtherNotes),
                        JobListingId = jobListingId,
                        UserId = userIdCurrentlyLoggedIn,
                        TemplateAddedAt = DateTime.Now
                    };
                    _templatesRepository.AddTemplate(template);
                }

                ViewBag.SelectedNav = "Dashboard";
                return RedirectToAction(nameof(Index));
            }
            List<Company> companiesAssignedToUserLoggedIn = _companiesRepository.GetCompaniesAssignedToUser(userIdCurrentlyLoggedIn);
            List<Category> categories = _categoriesRepository.GetCategories();

            List<string> regions = new List<string> { "Africa", "Asia", "The Caribbean", "Central America", "Europe", "Oceania", "North America", "South America" };
            List<string> types = new List<string> { "Full Time", "Part Time", "Remote", "Voluntary or carity acts" };

            ViewData["Companies"] = new SelectList(companiesAssignedToUserLoggedIn, "CompanyId", "Name");
            ViewData["Categories"] = new SelectList(categories, "CategoryId", "Name");
            ViewData["Regions"] = new SelectList(regions, regions);
            ViewData["Types"] = new SelectList(types, types);
            ViewBag.SelectedNav = "Dashboard";

            return View(addJobListingWithTemplateViewModel);
        }

        [Authorize(Roles = "hr")]
        [Route("/joblisting/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);
            
            JobListing jobListing = _jobListingsRepository.GetJobListingById(id);
            Template templateFromDb = _templatesRepository.GetTemplateByJobId(id);
            
            bool isAllowedToSeeJobListing = _jobListingsRepository.isAllowedToModifyJobListing(userIdCurrentlyLoggedIn, jobListing.CompanyId);
            if (!isAllowedToSeeJobListing)
            {
                return NotFound();
            }

            List<Company> companiesAssignedToUserLoggedIn = _companiesRepository.GetCompaniesAssignedToUser(userIdCurrentlyLoggedIn);
            List<Category> categories = _categoriesRepository.GetCategories();

            List<string> regions = new List<string> { "Africa", "Asia", "The Caribbean", "Central America", "Europe", "Oceania", "North America", "South America" };
            List<string> types = new List<string> { "Full Time", "Part Time", "Remote", "Voluntary or carity acts" };

            EditJobListingWithTemplateViewModel editJobListingWithTemplateViewModel = new EditJobListingWithTemplateViewModel
            {
                Title = jobListing.Title,
                Position = jobListing.Position,
                Type = jobListing.Type,
                Description = jobListing.Description,
                Location = jobListing.Location,
                JobListingId = userIdCurrentlyLoggedIn,
                CategoryId = jobListing.Category.CategoryId,
                CompanyId = jobListing.Company.CompanyId,
                Region = jobListing.Region,
                UserId = jobListing.JobFinderUser.UserId,
                IsActive = Convert.ToBoolean(jobListing.IsActive),
                Education = Convert.ToBoolean(templateFromDb.Education),
                WorkExperience = Convert.ToBoolean(templateFromDb.WorkExperience),
                Skills = Convert.ToBoolean(templateFromDb.Skills),
                OtherNotes = Convert.ToBoolean(templateFromDb.OtherNotes)
            };

            ViewData["Companies"] = new SelectList(companiesAssignedToUserLoggedIn, "CompanyId", "Name");
            ViewData["Categories"] = new SelectList(categories, "CategoryId", "Name");
            ViewData["Regions"] = new SelectList(regions, regions);
            ViewData["Types"] = new SelectList(types, types);
            ViewBag.SelectedNav = "Dashboard";

            return View(editJobListingWithTemplateViewModel);
        }

        [Route("/joblisting/edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("JobListingId, CompanyId, CategoryId,Title,Type,Position,Region,Location,Description,IsActive,WorkExperience,Education,Skills,OtherNotes")] EditJobListingWithTemplateViewModel editJobListingWithTemplateViewModel)
        {
            JobListing jobListingFromDb = _jobListingsRepository.GetJobListingById(id);
            int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);

            if (!_jobListingsRepository.isAllowedToModifyJobListing(userIdCurrentlyLoggedIn, jobListingFromDb.CompanyId))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                jobListingFromDb.Location = editJobListingWithTemplateViewModel.Location;
                jobListingFromDb.Position = editJobListingWithTemplateViewModel.Position;
                jobListingFromDb.Region = editJobListingWithTemplateViewModel.Region;
                jobListingFromDb.Title = editJobListingWithTemplateViewModel.Title;
                jobListingFromDb.Type = editJobListingWithTemplateViewModel.Type;
                jobListingFromDb.Description = editJobListingWithTemplateViewModel.Description;
                jobListingFromDb.CategoryId = editJobListingWithTemplateViewModel.CategoryId;
                jobListingFromDb.CompanyId = editJobListingWithTemplateViewModel.CompanyId;
                jobListingFromDb.IsActive = Convert.ToByte(editJobListingWithTemplateViewModel.IsActive);

                if(!editJobListingWithTemplateViewModel.IsActive)
                {
                    jobListingFromDb.JobListingClosedAt = DateTime.Now;
                }

                _jobListingsRepository.EditJobListing(jobListingFromDb);

                Template templateFromDb = _templatesRepository.GetTemplateByJobId(id);

                templateFromDb.WorkExperience = Convert.ToByte(editJobListingWithTemplateViewModel.WorkExperience);
                templateFromDb.Skills = Convert.ToByte(editJobListingWithTemplateViewModel.Skills);
                templateFromDb.Education = Convert.ToByte(editJobListingWithTemplateViewModel.Education);
                templateFromDb.OtherNotes = Convert.ToByte(editJobListingWithTemplateViewModel.OtherNotes);
                templateFromDb.JobListingId = id;
                templateFromDb.UserId = userIdCurrentlyLoggedIn;
                templateFromDb.TemplateUpdatedAt = DateTime.Now;
                _templatesRepository.EditTemplate(templateFromDb);

                ViewBag.SelectedNav = "Dashboard";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SelectedNav = "Dashboard";
            return View(editJobListingWithTemplateViewModel);
        }

        [Route("/joblisting/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobListing = _jobListingsRepository.GetJobListingById(id);

            if (jobListing == null)
            {
                return NotFound();
            }
            ViewBag.SelectedNav = "Dashboard";
            return View(jobListing);
        }

        [Route("/joblisting/delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobListing jobListing = _jobListingsRepository.GetJobListingById(id);
            _jobListingsRepository.DeleteJobListing(jobListing);
            ViewBag.SelectedNav = "Dashboard";
            return RedirectToAction(nameof(Index));
        }
    }
}
