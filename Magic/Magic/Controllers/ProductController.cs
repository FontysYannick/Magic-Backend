using Magic_DAL.Context;
using Magic_Logic.Classes;
using Magic_Logic.Container;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Magic.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ProductController : ControllerBase
    {
        private Product_Container pc;
        private readonly IConfiguration configuration;

        public ProductController(IConfiguration ic)
        {
            configuration = ic;
            pc = new(new Product_Context(configuration["db:ConnectionString"]));
        }

        [HttpGet]
        [Route("api/[controller]")]
        public string JsonConverter()
        {
            List<Product> products = pc.Getproducts();

            var json = JsonSerializer.Serialize(products);
            return json;
        }


        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult CreateProduct(Product product)
        {
            try
            {
                pc.Create(product);
                return Ok(product);
            }
            catch
            {
                return Unauthorized();
            }
        }

        [HttpDelete]
        [Route("api/[controller]")]
        public IActionResult DeleteProduct(Product product)
        {
            try
            {
                pc.Delete(product.Id);
                return Ok(product.Id);
            }
            catch
            {
                return Unauthorized();
            }
        }

        [HttpPatch]
        [Route("api/[controller]")]
        public IActionResult UpdateProduct(Product product)
        {
            try
            {
                pc.Update(product);
                return Ok(product);
            }
            catch
            {
                return Unauthorized();
            }
        }
    }
}
