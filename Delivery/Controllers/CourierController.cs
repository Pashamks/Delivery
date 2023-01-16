using Delivery.DataBase;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers
{
    public class CourierController : Controller
    {
        DbRepository dbRepository;
        public CourierController()
        {
            dbRepository = new DbRepository();
        }
        public IActionResult Index()
        {
            return View(dbRepository.GetPurchases().Result);
        }
        public IActionResult Take()
        {
            return View();
        }
        public IActionResult Close()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TakePurchase(int Id)
        {
            dbRepository.TakePurchase(Id);
            return RedirectToAction("Index", "Courier");
        }
        [HttpPost]
        public IActionResult ClosePurchase(int Id)
        {
            dbRepository.ClosePurchase(Id);
            return RedirectToAction("Index", "Courier");
        }
    }
}
