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
using System.Text;
using System.Security.Cryptography;
using JobFinder.Data.Repositories;
using System.Security.Claims;

namespace JobFinder.Controllers
{
    public class JobFinderUsersController : Controller
    {
        private readonly DBApplicationContext _dbContext;
        private readonly UsersRepository _usersRepository;

        public JobFinderUsersController(DBApplicationContext context)
        {
            _dbContext = context;
            _usersRepository = new UsersRepository(context);
        }

        [Authorize(Roles = "admin")]
        [Route("/users")]
        public ViewResult Index()
        {
            List<JobFinderUser> jobFinderUsers = _usersRepository.getApplicationUsers();
            ViewBag.SelectedNav = "Dashboard";

            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.SuccessMessage = TempData["SuccessMessage"].ToString();
            }
            if (TempData["InfoMessage"] != null)
            {
                ViewBag.InfoMessage = TempData["InfoMessage"].ToString();
            }
            return View(jobFinderUsers);
        }

        [Authorize(Roles = "admin")]
        [Route("/users/create")]
        public ActionResult Create()
        {
            ViewData["UserRoleId"] = new SelectList(_dbContext.UserRoles, "UserRoleId", "RoleName");
            ViewBag.SelectedNav = "Dashboard";
            return View();
        }


        [Authorize(Roles = "admin")]
        [Route("/users/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("FirstName,LastName,Email,Password,PhoneNumber,UserRoleId")] JobFinderUser jobFinderUser)
        {

            if (ModelState.IsValid)
            {
                if (!_usersRepository.UserEmailExists(jobFinderUser.Email))
                {
                    _usersRepository.addUser(jobFinderUser);
                    ViewBag.SelectedNav = "Dashboard";
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Email already exists in database!");
                }
            }
            ViewBag.SelectedNav = "Dashboard";
            ViewData["UserRoleId"] = new SelectList(_dbContext.UserRoles, "UserRoleId", "RoleName", jobFinderUser.UserRoleId);
            return View(jobFinderUser);
        }

        [Authorize(Roles = "admin,hr,candidate")]
        [Route("/users/edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (User.IsInRole("hr") || User.IsInRole("candidate"))
            {
                int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);
                if (id != userIdCurrentlyLoggedIn)
                {
                    return NotFound();
                }
                ViewBag.SelectedNav = "Profile";
                ViewData["notAdmin"] = 1;
            }

            var jobFinderUser = _usersRepository.findUserById(id);
            if (jobFinderUser == null)
            {
                return NotFound();
            }
            if (User.IsInRole("admin"))
            {
                ViewData["UserRoleId"] = new SelectList(_dbContext.UserRoles, "UserRoleId", "RoleName", jobFinderUser.UserRoleId);
                ViewBag.SelectedNav = "Dashboard";
            }
            return View(jobFinderUser);
        }

        [Authorize(Roles = "admin,hr,candidate")]
        [Route("/users/edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("FirstName,LastName,Email,Password,PhoneNumber,UserRoleId")] JobFinderUser jobFinderUserNewData)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    JobFinderUser targetUser = _usersRepository.findUserById(id);
                    targetUser.FirstName = jobFinderUserNewData.FirstName;
                    targetUser.LastName = jobFinderUserNewData.LastName;
                    targetUser.Email = jobFinderUserNewData.Email;
                    targetUser.Password = _usersRepository.sha256_hash(jobFinderUserNewData.Password);
                    targetUser.PhoneNumber = jobFinderUserNewData.PhoneNumber;
                    targetUser.UserRoleId = jobFinderUserNewData.UserRoleId;
                    targetUser.UserUpdatedAt = DateTime.Now;

                    _usersRepository.editUser(targetUser);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_usersRepository.UserExists(jobFinderUserNewData.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserRoleId"] = new SelectList(_dbContext.UserRoles, "UserRoleId", "RoleName", jobFinderUserNewData.UserRoleId);
            ViewBag.SelectedNav = "Dashboard";
            return View(jobFinderUserNewData);
        }

        [Authorize(Roles = "admin")]
        [Route("/users/approve/{id}")]
        public ActionResult Approve(int id)
        {

            JobFinderUser targetUser = _usersRepository.findUserById(id);
            if (targetUser != null)
            {
                targetUser.IsApproved = true;
                _usersRepository.editUser(targetUser);
                ViewBag.SelectedNav = "Dashboard";
                TempData["SuccessMessage"] = $"The recruiter having email address '{targetUser.Email}' has been approved and can authenticate in the platform.";
            }
            else
            {
                ViewBag.SelectedNav = "Dashboard";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        [Route("/users/unapprove/{id}")]
        public ActionResult Unapprove(int id)
        {
            JobFinderUser targetUser = _usersRepository.findUserById(id);
            if (targetUser != null)
            {
                targetUser.IsApproved = false;
                _usersRepository.editUser(targetUser);
                ViewBag.SelectedNav = "Dashboard";
                TempData["InfoMessage"] = $"The recruiter having email address '{targetUser.Email}' has been unapproved and can't authenticate in the platform.";
            }
            else
            {
                ViewBag.SelectedNav = "Dashboard";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        [Route("/users/delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobFinderUser jobFinderUser = _usersRepository.findUserById(id);
            if (jobFinderUser == null)
            {
                return NotFound();
            }
            ViewBag.SelectedNav = "Dashboard";
            return View(jobFinderUser);
        }

        [Authorize(Roles = "admin")]
        [Route("/users/delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobFinderUser jobFinderUser = _usersRepository.findUserById(id);
            _usersRepository.deleteUser(jobFinderUser, true);
            TempData["InfoMessage"] = $"User '{jobFinderUser.LastName} {jobFinderUser.FirstName}', with email address '{jobFinderUser.Email}' has been set as inactive and can not use the platform.";
            ViewBag.SelectedNav = "Dashboard";
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "admin")]
        [Route("/users/undo/delete/{id}")]
        public ActionResult UndoDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            JobFinderUser jobFinderUser = _usersRepository.findUserById(id);
            _usersRepository.deleteUser(jobFinderUser, false);
            TempData["SuccessMessage"] = $"User '{jobFinderUser.LastName} {jobFinderUser.FirstName}', with email address '{jobFinderUser.Email}' has been set as active and can use the platform.";
            ViewBag.SelectedNav = "Dashboard";
            return RedirectToAction(nameof(Index));
        }
    }
}
