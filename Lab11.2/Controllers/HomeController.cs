using Lab11._2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;


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

            string clickBack = "Click 'Back' to return to the registration form.";

            if(rx.IsMatch(user.FirstName) || rx.IsMatch(user.LastName))
            {
                return Content($"Your name cannot contain any numbers. {clickBack}");
            }

            // need to add more validation here. 

            if(user.Email == "email@email.com")
            {
                return Content($"Please enter a valid email. {clickBack}");
            }

            if(user.State == "Your State")
            {
                return Content($"Please enter a valid state. {clickBack}");
            }

            if(user.Password != password1)
            {
                return Content($"Sorry, the passwords do not match. {clickBack}");
            }

            Models.User.currentUser = user;

            return View(user);
        }

        public IActionResult ViewProfile(User user)
        {
            return View(Models.User.currentUser);
        }

        public IActionResult Products()
        {
            MySqlConnection db = new MySqlConnection("Server=localhost;Database=coffeeshop;Uid=root;Password=abc123");
            List<Product> prods = db.GetAll<Product>().ToList();

            return View(prods);
        }

        public IActionResult Detail(int id)
        {
            MySqlConnection db = new MySqlConnection("Server=localhost;Database=coffeeshop;Uid=root;Password=abc123");
            Product prod = db.Get<Product>(id);
            return View(prod);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
