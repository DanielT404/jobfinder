using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using JobFinder.Models.ViewModels;
using JobFinder.Data;
using JobFinder.Data.Repositories;
using JobFinder.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Runtime.CompilerServices;

namespace JobFinder.Controllers
{
    public class AccountManagerController : Controller
    {

        private DBApplicationContext _dbContext;
        private readonly UsersRepository _usersRepository;
        private readonly ApplicationsRepository _applicationsRepository;
        private readonly CompaniesRepository _companiesRepository;
        private readonly CompanyUsersRepository _companyUsersRepository;

        private readonly IConfiguration _appsettingsConfiguration;


        public AccountManagerController(DBApplicationContext context, IConfiguration configuration)
        {
            _dbContext = context;
            _usersRepository = new UsersRepository(context);
            _applicationsRepository = new ApplicationsRepository(context);
            _companiesRepository = new CompaniesRepository(context);
            _companyUsersRepository = new CompanyUsersRepository(context);
            _appsettingsConfiguration = configuration;

        }


        [Route("/register")]
        public ActionResult Register()
        {
            ViewBag.SelectedNav = "Register";
            return View();
        }

        [Route("/register/candidate")]
        public ActionResult RegisterCandidate()
        {
            ViewBag.SelectedNav = "Register";
            return View();
        }

        [Route("/register/candidate")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterCandidate([Bind("FirstName, LastName, Email, Password, PhoneNumber")] JobFinderUser jobFinderUser)
        {
            if (ModelState.IsValid)
            {
                if (!_usersRepository.UserEmailExists(jobFinderUser.Email))
                {
                    jobFinderUser.IsApproved = true;
                    jobFinderUser.IsActive = true;
                    jobFinderUser.UserRoleId = 3;
                    _usersRepository.addUser(jobFinderUser);
                    ViewBag.Message = "Your account has been succesfully created. You may now log in.";
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Email already exists in database!");
                }
            }
            ViewBag.SelectedNav = "Register";
            return View();
        }

        [Route("/register/recruiter")]
        public ActionResult RegisterRecruiter()
        {
            ViewBag.SelectedNav = "Register";
            return View();
        }

        [Route("/register/recruiter")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterRecruiter([Bind("FirstName, LastName, Email, Password, PhoneNumber, Name, Description, StartDate")] RecruiterRegisterViewModel recruiterRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                if (!_usersRepository.UserEmailExists(recruiterRegisterViewModel.Email))
                {
                    JobFinderUser jobFinderUser = new JobFinderUser
                    {
                        Password = recruiterRegisterViewModel.Password,
                        FirstName = recruiterRegisterViewModel.FirstName,
                        LastName = recruiterRegisterViewModel.LastName,
                        Email = recruiterRegisterViewModel.Email,
                        PhoneNumber = recruiterRegisterViewModel.PhoneNumber,
                        UserAddedAt = DateTime.Now,
                        UserUpdatedAt = DateTime.Now,
                        UserRoleId = 2,
                        IsApproved = false,
                        IsActive = true
                    };

                    int newUserId = _usersRepository.addUser(jobFinderUser);

                    if (_companiesRepository.CompanyExistsByName(recruiterRegisterViewModel.Name))
                    {
                        Company company = _companiesRepository.GetCompanyByName(recruiterRegisterViewModel.Name);
                        _companyUsersRepository.AssignUserToCompany(new CompanyUser
                        {
                            UserId = newUserId,
                            CKCompanyId = company.CompanyId
                        });

                        SendEmail(jobFinderUser.LastName + " " + jobFinderUser.FirstName, jobFinderUser.Email, company.Name);
                    }
                    else
                    {
                        Company company = new Company
                        {
                            Name = recruiterRegisterViewModel.Name,
                            StartDate = recruiterRegisterViewModel.StartDate,
                            Description = recruiterRegisterViewModel.Description
                        };

                        int newCompanyId = _companiesRepository.AddCompany(company);

                        _companyUsersRepository.AssignUserToCompany(new CompanyUser
                        {
                            UserId = newUserId,
                            CKCompanyId = newCompanyId
                        });

                        SendEmail(jobFinderUser.LastName + " " + jobFinderUser.FirstName, jobFinderUser.Email, company.Name);
                    }
                    ViewBag.Message = "Your account needs to be approved by the system administrator.";
                    ViewBag.SelectedNav = "Home";
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", "Email already exists in database!");
                }
            }
            ViewBag.SelectedNav = "Register";
            return View();
        }

        [Route("/login")]
        public ActionResult Login()
        {
            UserLoginViewModel userLoginViewModel = new UserLoginViewModel();
            ViewBag.SelectedNav = "Login";
            return View(userLoginViewModel);
        }

        [Route("/login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login([Bind("UserEmail", "UserPassword")] UserLoginViewModel userLoginViewModel)
        {
            if (ModelState.IsValid)
            {
                bool credentialsMatching = await _usersRepository.isCredentialsMatching(userLoginViewModel.UserEmail, userLoginViewModel.UserPassword);
                if (credentialsMatching)
                {
                    bool isAcceptedInPlatform = await _usersRepository.isApproved(userLoginViewModel.UserEmail);
                    bool isActiveInPlatform = await _usersRepository.isActive(userLoginViewModel.UserEmail);
                    
                    if (isAcceptedInPlatform == true)
                    {

                        if(isActiveInPlatform == true)
                        {
                            var identity = new ClaimsIdentity(_usersRepository.identifyAndSetClaims(userLoginViewModel), CookieAuthenticationDefaults.AuthenticationScheme);

                            var authenticationProperties = new AuthenticationProperties
                            {
                                IsPersistent = true
                            };

                            await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(identity),
                                authenticationProperties);
                            ViewBag.SelectedNav = "Home";
                            return Redirect("/");
                        } else {
                            TempData["Message"] = "Your account is currently disabled. Contact the system administrator to enable your account.";
                            ViewBag.SelectedNav = "Home";
                            return Redirect("/");
                        }
                    } else
                    {
                        TempData["Message"] = "Your account is currently waiting for approval by a system administrator.";
                        ViewBag.SelectedNav = "Home";
                        return Redirect("/");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Credentials do not match!");
                    ViewBag.SelectedNav = "Login";
                    return View(userLoginViewModel);
                }
            }
            else
            {
                ViewBag.SelectedNav = "Login";
                return View(userLoginViewModel);
            }
        }

        [Authorize(Roles = "admin,hr,candidate")]
        [Route("/profile")]
        public ActionResult Profile()
        {
            int userIdCurrentlyLoggedIn = Int32.Parse(User.Claims.FirstOrDefault(uc => uc.Type == ClaimTypes.NameIdentifier).Value);
            List<Application> userApplications = _applicationsRepository.GetApplicationsByUserId(userIdCurrentlyLoggedIn);
            ViewData["userId"] = userIdCurrentlyLoggedIn;
            ViewBag.SelectedNav = "Profile";
            return View(userApplications);
        }



        [Route("/logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        private void SendEmail(string name, string email, string company)
        {
            using (var smtpClient = new SmtpClient())
            {
                var emailCredentials = new NetworkCredential()
                {
                    UserName = _appsettingsConfiguration["Email:EmailAddress"],
                    Password = _appsettingsConfiguration["Email:EmailPassword"]
                };

                smtpClient.Credentials = emailCredentials;
                smtpClient.Host = _appsettingsConfiguration["Email:Host"];
                smtpClient.Port = int.Parse(_appsettingsConfiguration["Email:Port"]);
                smtpClient.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(_appsettingsConfiguration["Email:EmailAddress"]));
                    emailMessage.From = new MailAddress(_appsettingsConfiguration["Email:EmailAddress"]);
                    emailMessage.Subject = $"'{name}' has just registered in the application as a recruiter for company '{company}' and is waiting for approval.";
                    emailMessage.Body = $"'{name}' has just registered as a recruiter for company '{company}' in the platform and is waiting for approval.";
                    smtpClient.Send(emailMessage);
                }
            }
        }
    }
}
