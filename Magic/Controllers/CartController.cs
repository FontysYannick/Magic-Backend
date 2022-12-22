using Magic_DAL.Context;
using Magic_Logic.Classes;
using Magic_Logic.Container;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Magic.Controllers
{
    [ApiController]
    [EnableCors]
    public class CartController : ControllerBase
    {
        private Cart_Container cc;
        private readonly IConfiguration configuration;

        public CartController(IConfiguration ic)
        {
            configuration = ic;
            cc = new(new Cart_Context(configuration["db:ConnectionString"]));
        }

        [HttpGet]
        [Route("api/[controller]")]
        public string GetCart(int id)
        {
            List<Product> products = cc.GetProductsFromCart(id);

            var json = JsonSerializer.Serialize(products);
            return json;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult CreateCart(Product product, int user)
        {
            try
            {
                cc.Create(product, user);
                return Ok(product);
            }
            catch
            {
                return Unauthorized();
            }
        }

        [HttpDelete]
        [Route("api/[controller]")]
        public IActionResult DeleteCart(int id)
        {
            try
            {
                cc.Delete(id);
                return Ok(id);
            }
            catch
            {
                return Unauthorized();
            }
        }
    }
}
