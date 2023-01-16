using Delivery.DataBase;
using Delivery.DataBase.Models;
using Delivery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Delivery.Controllers
{
    public class ProductController : Controller
    {
        private DbRepository dbRepository;
        public ProductController()
        {
            dbRepository = new DbRepository();
        }
        [Route("all")]
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await dbRepository.GetProducts());
        }
        [Route("buyproduct")]
        [HttpPost]
        public IActionResult BuyProduct(BuyModel buyModel)
        {
            if (dbRepository.GetBalance(buyModel.UserName) < dbRepository.GetPrice(buyModel.ProductName) ||
                buyModel.Amount > dbRepository.GetProductAmoun(buyModel.ProductName)
                || dbRepository.GetProductAmoun(buyModel.ProductName) == 0)
                return BadRequest();
            dbRepository.BuyProduct(buyModel).Wait();
            return Ok();
        }
        [Route("userProducts")]
        [HttpGet]
        public async Task<IActionResult> GetUserProducts([FromQuery]string name)
        {
            return Ok(await dbRepository.GetUserProducts(name));
        }
    
    }
}
