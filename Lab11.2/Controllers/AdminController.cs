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
    public class AdminController : Controller
    {
        static MySqlConnection db = new MySqlConnection("Server=localhost;Database=coffeeshop;Uid=root;Password=abc123");

        public IActionResult Index()
        {
            List<Product> prods = db.GetAll<Product>().ToList();
            List<string> categories = new List<string>();

            foreach(Product prod in prods)
            {
                if(!categories.Contains(prod.category))
                {
                    categories.Add(prod.category);
                }
            }

            ViewBag.categories = categories;


            return View(prods);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AddItem(Product prod)
        {
            db.Insert(prod);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            Product prod = db.Get<Product>(id);
            
            return View(prod);
        }

        public IActionResult ConfirmRemove(int id)
        {
            Product prod = db.Get<Product>(id);
            db.Delete(prod);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Product prod = db.Get<Product>(id);

            return View(prod);
        }

        public IActionResult EditItem(Product prod)
        {
            db.Update(prod);

            return RedirectToAction("Index");
        }

    }
}
