using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models.Cheese;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        public static List<Cheese> cheeses = new List<Cheese>();

        [HttpGet]
        public IActionResult Index()
        {
            List<Cheese> model = CheeseData.GetAll();
            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Cheese cheese)
        {
            CheeseData.Add(cheese);
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult CheckBoxDelete()
        {
            List<Cheese> model = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult CheckBoxDelete(int[] cheeseIdsToDelete)
        {
            cheeseIdsToDelete.ToList().ForEach(id => CheeseData.Remove(id));
            return Redirect("Index");
        }

        [HttpGet]
        public IActionResult DropDownDelete()
        {
            List<Cheese> model = CheeseData.GetAll();
            return View(model);
        }

        [HttpPost]
        public IActionResult DropDownDelete(Cheese cheese)
        {
            CheeseData.Remove(cheese);
            return Redirect("Index");
        }
    }
}