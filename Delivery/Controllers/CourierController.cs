using Microsoft.AspNetCore.Mvc;

namespace Delivery.Controllers
{
    public class CourierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
