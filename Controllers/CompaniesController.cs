using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobFinder.Data;
using JobFinder.Models;
using Microsoft.AspNetCore.Authorization;
using JobFinder.Models.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore;
using JobFinder.Data.Repositories;

namespace JobFinder.Controllers
{
    [Authorize(Roles = "admin")]
    public class CompaniesController : Controller
    {
        private DBApplicationContext _dbContext;
        private readonly CompaniesRepository _companiesRepository;

        public CompaniesController(DBApplicationContext context)
        {
            _dbContext = context;
            _companiesRepository = new CompaniesRepository(context);
        }

        [Route("/companies")]
        public ActionResult Index()
        {
            List<Company> companies = _companiesRepository.GetCompanies();
            ViewBag.SelectedNav = "Dashboard";
            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"].ToString();
            }
            return View(companies);
        }

        [Route("/companies/create")]
        public ActionResult Create()
        {
            ViewBag.SelectedNav = "Dashboard";
            return View();
        }

        [Route("/companies/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,Description,StartDate")] Company company)
        {
            if (ModelState.IsValid)
            {
                _companiesRepository.AddCompany(company);
                ViewBag.SelectedNav = "Dashboard";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SelectedNav = "Dashboard";
            return View(company);
        }

        [Route("/companies/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company company = _companiesRepository.FindCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }
            ViewBag.SelectedNav = "Dashboard";
            return View(company);
        }

        [Route("/companies/edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("CompanyId,Name,Description,StartDate")] Company company)
        {
            if (id != company.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _companiesRepository.UpdateCompany(company);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_companiesRepository.CompanyExists(company.CompanyId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.SelectedNav = "Dashboard";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.SelectedNav = "Dashboard";
            return View(company);
        }

        [Route("/companies/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = _companiesRepository.FindCompanyById(id);
            if (company == null)
            {
                return NotFound();
            }
            
            ViewBag.SelectedNav = "Dashboard";
            return View(company);
        }

        [Route("/companies/delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = _companiesRepository.FindCompanyById(id);
            if (company != null)
            {
                ViewBag.SelectedNav = "Dashboard";
                if (company.JobListings.Count() < 1)
                {
                    _companiesRepository.DeleteCompany(company);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["ErrorMessage"] = $"Company '{company.Name}' has active job listings and cannot be deleted.";
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.SelectedNav = "Dashboard";
            return RedirectToAction(nameof(Index));
        }
    }
}
