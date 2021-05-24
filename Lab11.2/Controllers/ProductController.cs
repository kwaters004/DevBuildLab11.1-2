using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using Lab11._2.Models;



namespace Lab11._2.Controllers
{
    public class ProductController : Controller
    {
        static MySqlConnection db = new MySqlConnection("Server=localhost;Database=coffeeshop;Uid=root;Password=abc123");
        public IActionResult Index()
        {
            return RedirectToAction("Products");
        }

        public IActionResult Products()
        {

            List<Product> prods = db.GetAll<Product>().ToList();
            List<string> cats = new List<string>();

            foreach (Product prod in prods)
            {
                if (!cats.Contains(prod.category))
                {
                    cats.Add(prod.category);
                }
            }

            cats = cats.OrderBy(o => o).ToList();
            ViewBag.categories = cats;
            return View(prods);

        }


        public IActionResult Detail(int id)
        {

            Product prod = db.Get<Product>(id);

            return View(prod);
        }
    }
}
