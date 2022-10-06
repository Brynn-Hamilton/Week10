using Microsoft.AspNetCore.Mvc;
using GroceryCrud.Models;

namespace GroceryCrud.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            // Instead of saving the product list into a variable
            // and passing that variable, let's just put the 
            // call right into View(model)
            return View(DAL.GetAllProducts());
        }
        // Display detail for a single product
        public IActionResult Detail(int id)
        {
            return View(DAL.GetOneProduct(id));
        }

        // Add a product requires two routes
        // 1. A route to send the form to the browser
        // 2. A route the browser calls when the form is submitted

        public IActionResult Addform()
        {
            return View();
        }

        public IActionResult Add(Product prod)
        {
            return Redirect("/product");
        }

        // Delete a product
        public IActionResult Delete(int id)
        {
            DAL.DeleteProduct(id);
            return Redirect("/product");
        }
        public IActionResult EditForm(int id)
        {
            ViewData["categories"] = DAL.GetAllCategories();
            return View(DAL.GetOneProduct(id));
        }

        public IActionResult SaveChanges(Product prod)
        {
            DAL.UpdateProduct(prod);
            return Redirect("/product");
        }
    }
}
