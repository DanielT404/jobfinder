using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobFinder.Data;
using JobFinder.Data.Repositories;
using JobFinder.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers
{
    public class JobsController : Controller
    {
        private readonly DBApplicationContext _dbContext;
        private readonly JobListingsRepository _jobListingsRepository;
        private readonly CategoriesRepository _categoriesRepository;

        public JobsController(DBApplicationContext context)
        {
            _dbContext = context;
            _jobListingsRepository = new JobListingsRepository(context);
            _categoriesRepository = new CategoriesRepository(context);
        }

        [Route("/jobs")]
        public ActionResult Index()
        {
            List<JobListing> allJobListings = _jobListingsRepository.GetAllJobListingsActive();
            ViewBag.SelectedNav = "Jobs";
            return View(allJobListings);
        }

        [Route("/jobs/category/{categorySlug}")]
        public ActionResult JobsByCategorySlug(string categorySlug)
        {
            Category category = _categoriesRepository.FindCategoryBySlug(categorySlug);
            List<JobListing> jobListingsByCategorySlug = _jobListingsRepository.GetJobListingsByCategorySlug(categorySlug);

            ViewBag.categoryName = category.Name;
            ViewBag.SelectedNav = "Jobs";
            return View(jobListingsByCategorySlug);
        }

        [Route("/jobs/{id}")]
        public ActionResult Details(int? id)
        {
            ViewBag.SelectedNav = "Jobs";
            JobListing jobListing = _jobListingsRepository.GetJobListingById(id);
            return View(jobListing);
        }
    }
}
