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
        public AdminController()
        {
            dbRepostiroy = new DbRepository();
        }
        [HttpDelete]
        public IActionResult DeleteProduct([FromBody]string product)
        {
            dbRepostiroy.RemoveProduct(product).Wait();
            return Ok(product);
        }
        [HttpPut]
        public IActionResult EditProduct(Product product)
        {
            dbRepostiroy.UpdateProduct(product);
            return Ok();
        }
    }
}
