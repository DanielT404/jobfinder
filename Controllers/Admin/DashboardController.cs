using JobFinder.Data;
using JobFinder.Data.Repositories;
using JobFinder.Data.Repositories.Charts;
using JobFinder.Models.ChartModels;
using JobFinder.Models.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobFinder.Controllers.Admin
{
    [Route("/admin/dashboard/{action=Index}")]
    [Authorize(Roles = "admin,hr")]
    public class DashboardController : Controller
    {

        private readonly DBApplicationContext _dbContext;
        private readonly ChartsRepository _chartsRepository;

        public DashboardController(DBApplicationContext context)
        {
            _dbContext = context;
            _chartsRepository = new ChartsRepository(context);
        }

        public ViewResult Index()
        {
            string role = User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.Role).Value;
            int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);

            ChartViewModel chartViewModel = new ChartViewModel
            {
                CategoryChartData = _chartsRepository.GetPopularCategories(),
                CompanyChartData = _chartsRepository.GetDesiredCompanies()
            };

            if(role == "hr")
            {
                chartViewModel.NumberOfApplicationsReceived = _chartsRepository.GetNumberOfApplicationsReceived(userIdCurrentlyLoggedIn);
                chartViewModel.NumberOfJobListings = _chartsRepository.GetNumberOfJobListings(userIdCurrentlyLoggedIn);
                chartViewModel.NumberOfJobListingsActive = _chartsRepository.GetNumberOfJobListingsActive(userIdCurrentlyLoggedIn);
            };

            ViewBag.SelectedNav = "Dashboard";

            return View("~/Views/Admin/Index.cshtml", chartViewModel);
        }
    }
}
