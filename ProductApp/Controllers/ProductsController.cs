using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            var products = new List<Product>()
            {
                new() { Id=1, ProductName="Keyboard" },
                new() { Id=2, ProductName="Computer" },
                new() { Id=3, ProductName="Mouse" }
            };
            _logger.LogInformation("GetProduct action called");
            return Ok(products);
        }

        [HttpPost]
        public IActionResult GetAllProducts([FromBody] Product product)
        {
            _logger.LogWarning("Product has been created.");
            return StatusCode(201);
        }
    }
}
