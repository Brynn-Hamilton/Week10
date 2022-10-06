using GroceryCrud.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GroceryCrud.Controllers
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
            // Here's some test code
            List<Category> categories = DAL.GetAllCategories();
            ViewBag.count = categories.Count;
            return View();
        }

        public IActionResult Privacy()
        {
            Product prod = new Product();
            prod.name = "Aaa";
            prod.description = "Aaa test product";
            prod.price = 1.50m;
            prod.inventory = 10;
            prod.category = "FRUIT";
            Product result = DAL.InsertProduct(prod);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}