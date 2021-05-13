using Lab11._2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Lab11._2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Registration()
        {
            //return Content("Here is the registration page");
            return View();
        }

        public IActionResult FormSubmit(User user, string password1)
        {
            //return Content("Here's the form submit page");

            Regex rx = new Regex(@"[0-9]+");

            if(rx.IsMatch(user.FirstName) || rx.IsMatch(user.LastName))
            {
                return Content("Your name cannot contain any numbers.");
            }

            // need to add more validation here. 
            if(user.Password != password1)
            {
                return Content("Sorry, the passwords do not match");
            }

            Models.User.currentUser = user;

            return View(user);
        }

        public IActionResult ViewProfile(User user)
        {
            return View(Models.User.currentUser);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
