using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["FullName"] = "Apud";
            ViewBag.Address = "Jl. Bumi Serpong Damai";

            Category model = new Category
            {
                CategoryId = 1,
                CategoryName = "Laptop Gaming"
            };

            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
