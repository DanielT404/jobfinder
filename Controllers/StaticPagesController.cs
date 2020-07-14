using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using JobFinder.Data;
using JobFinder.Data.Repositories;
using JobFinder.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JobFinder.Controllers
{
    public class StaticPagesController : Controller
    {

        private readonly DBApplicationContext _dbContext;
        private readonly IConfiguration _appsettingsConfiguration;

        private readonly CategoriesRepository _categoriesRepository;

        public StaticPagesController(DBApplicationContext context, IConfiguration configuration)
        {
            _dbContext = context;
            _categoriesRepository = new CategoriesRepository(context);
            _appsettingsConfiguration = configuration;
        }

        [Route("/")]
        public ActionResult Index()
        {
            List<Category> categories = _categoriesRepository.GetCategories();
            if(TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();

            }
            ViewBag.SelectedNav = "Home";
            return View(categories);
        }

        [Route("/email/send")]
        [HttpPost]
        public ActionResult SendEmail(IFormCollection collection)
        {
            string name = collection["name"];
            string email = collection["email"];
            string message = collection["message"];

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
                    emailMessage.From = new MailAddress(email);
                    emailMessage.Subject = $"{name} from JobFinder sent you a message using the contact form.";
                    emailMessage.Body = $"{message} | " +
                        $"Name: {name} | " +
                        $"Email: {email}";

                    smtpClient.Send(emailMessage);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
