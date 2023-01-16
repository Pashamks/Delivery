using Delivery.DataBase;
using Delivery.DataBase.Models;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers
{

    public class AdminController : Controller
    {
        private DbRepository dbRepostiroy;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View(dbRepostiroy.GetUsers().Result);
        }
        public IActionResult Products()
        {
            return View(dbRepostiroy.GetProducts().Result);
        }
        public AdminController()
        {
            dbRepostiroy = new DbRepository();
        }
        [HttpPost]
        public IActionResult ProductDelete(int Id)
        {
            dbRepostiroy.RemoveProduct(dbRepostiroy.GetProductById(Id)).Wait();
            return RedirectToAction("Products", "Admin");
        }
        [HttpPost]
        public IActionResult ProductAdd(Product product)
        {
            dbRepostiroy.AddProduct(product).Wait();
            return RedirectToAction("Products", "Admin");
        }
        [HttpPut]
        public IActionResult EditProduct(Product product)
        {
            dbRepostiroy.UpdateProduct(product);
            return Ok();
        }
    }
}
