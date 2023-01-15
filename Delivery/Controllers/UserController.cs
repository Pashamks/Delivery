using Delivery.DataBase;
using Delivery.DataBase.Models;
using Delivery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Delivery.Controllers
{
    public class UserController : Controller
    {
        private DbRepository dbRepository;
        public UserController()
        {
            dbRepository = new DbRepository();
        }
        public IActionResult Index()
        {
            return View(dbRepository.GetProducts().Result);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Validate(LogginModel user)
        {
            var status = dbRepository.GetUserStatus(user);
            if(status == 0)
                return RedirectToAction("Register", "User"); 
            else if(status == 1)
                return RedirectToAction("Index", "Admin");
            else if (status==2)
                return RedirectToAction("Index", "Courier");
            else
                return RedirectToAction("Index", "User");
        }

        public IActionResult CreateAccount(LogginModel user)
        {
            dbRepository.AddUser(new UserModel
            {
                Name = user.Name,
                Balance = 100,
                Password = user.Password,
                PhoneNumber = user.PhoneNumber
            }).Wait();
            return RedirectToAction("Login", "User"); ;
        }
       
        [Route("logout")]
        [HttpPost]
        public IActionResult Logout(string userName)
        {
            return Ok();
        }
        [Route("balance")]
        [HttpPut]
        public IActionResult EditBalance([FromBody]User user)
        {
            dbRepository.EditBalance(user).Wait();
            return Ok();
        }
    }
}
