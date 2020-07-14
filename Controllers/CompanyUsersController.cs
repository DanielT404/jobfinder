using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobFinder.Data;
using JobFinder.Models;
using JobFinder.Data.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace JobFinder.Controllers
{
    [Authorize(Roles = "admin")]
    public class CompanyUsersController : Controller
    {
        private readonly DBApplicationContext _context;
        private readonly CompanyUsersRepository _companyUsersRepository;
        private readonly UsersRepository _usersRepository;

        public CompanyUsersController(DBApplicationContext context)
        {
            _context = context;
            _companyUsersRepository = new CompanyUsersRepository(context);
            _usersRepository = new UsersRepository(context);
        }

        [Route("/company/users")]
        public ActionResult Index()
        {
            List<CompanyUser> companyUsers = _companyUsersRepository.GetAllCompanyUsers();
            ViewBag.SelectedNav = "Dashboard";
            return View(companyUsers);
        }

       
        [Route("/company/users/new")]
        public ActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Name");
            ViewData["UserId"] = new SelectList(_usersRepository.GetUsersWithRoleHR(), "UserId", "Email");
            ViewBag.SelectedNav = "Dashboard";
            return View();
        }

        [Route("/company/users/new")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("UserId,CKCompanyId")] CompanyUser companyUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _companyUsersRepository.AssignUserToCompany(companyUser);
                    ViewBag.SelectedNav = "Dashboard";
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Name", companyUser.CKCompanyId);
                    ViewData["UserId"] = new SelectList(_usersRepository.GetUsersWithRoleHR(), "UserId", "Email", companyUser.UserId);
                    ViewBag.SelectedNav = "Dashboard";
                    return View(companyUser);
                }
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "CompanyId", "Name", companyUser.CKCompanyId);
            ViewData["UserId"] = new SelectList(_usersRepository.GetUsersWithRoleHR(), "UserId", "Email", companyUser.UserId);
            ViewBag.SelectedNav = "Dashboard";
            return View(companyUser);
        }

        [Route("/company/users/delete/{userId}/company/{companyId}")]
        public ActionResult Delete(int? userId, int? companyId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            var companyUser = _companyUsersRepository.GetUserByUserIdAndCompanyId(userId, companyId);
            if (companyUser == null)
            {
                return NotFound();
            }
            ViewBag.SelectedNav = "Dashboard";
            return View(companyUser);
        }

        [Route("/company/users/delete/{userId}/company/{companyId}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? userId, int? companyId)
        {

            _companyUsersRepository.UnassignUserToCompany(userId, companyId);
            ViewBag.SelectedNav = "Dashboard";
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyUserExists(int userId, int companyId)
        {
            return _context.CompanyUsers.Any(e => e.UserId == userId && e.CKCompanyId == companyId);
        }
    }
}
