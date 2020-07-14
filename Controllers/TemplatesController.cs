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
    [Authorize(Roles = "admin,hr")]
    public class TemplatesController : Controller
    {
        private readonly DBApplicationContext _dbContext;
        private readonly TemplatesRepository _templatesRepository;
        private readonly JobListingsRepository _jobListingsRepository;


        public TemplatesController(DBApplicationContext context)
        {
            _dbContext = context;
            _templatesRepository = new TemplatesRepository(context);
            _jobListingsRepository = new JobListingsRepository(context);
        }
        
        [Route("/joblisting/{jobListingId}/template/create")]
        public ActionResult Create(int? jobListingId)
        {
            if (jobListingId == null)
            {
                return NotFound();
            }
            if(!_jobListingsRepository.JobListingExists(jobListingId))
            {
                return NotFound();
            }

            if(_templatesRepository.TemplateExists(jobListingId))
            {
                TempData["templateExists"] = "Template already exists!";
                ViewBag.SelectedNav = "Dashboard";
                return RedirectToAction("Index", "JobListings");
            }
            ViewBag.SelectedNav = "Dashboard";
            return View();
        }

        [Route("/joblisting/{jobListingId}/template/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int jobListingId, [Bind("TemplateId,Education,WorkExperience,Skills,AllowCVUpload,OtherNotes")] JobListingTemplateViewModel jobListingTemplateViewModel)
        {
            int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);

            if (!_jobListingsRepository.isAllowedToSetTemplate(userIdCurrentlyLoggedIn, jobListingId))
            {
                return NotFound();
            }
            Template template = new Template
            {
                UserId = userIdCurrentlyLoggedIn,
                JobListingId = jobListingId,
                Education = Convert.ToByte(jobListingTemplateViewModel.Education),
                WorkExperience = Convert.ToByte(jobListingTemplateViewModel.WorkExperience),
                Skills = Convert.ToByte(jobListingTemplateViewModel.Skills),
                OtherNotes = Convert.ToByte(jobListingTemplateViewModel.OtherNotes),
                TemplateAddedAt = DateTime.Now
            };
            _templatesRepository.AddTemplate(template);
            ViewBag.SelectedNav = "Dashboard";
            return RedirectToAction("Index", "JobListings");
        }

        [Route("/template/{id}/edit")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
