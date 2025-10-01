using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mock.Services;
using System.Text.Json;

namespace Mock.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        // GET: ApiController
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] GoldPriceService goldPriceService)
        {
            string fileName = Path.Combine(Directory.GetCurrentDirectory(), "products.json");
            string jsonString = System.IO.File.ReadAllText(fileName);

            List<Product> products = JsonSerializer.Deserialize<List<Product>>(jsonString)!;

            double goldPrice = await goldPriceService.GetGoldPriceAsync();

            foreach (var product in products)
            {
                product.Price = (product.PopularityScore + 1) * product.Weight * goldPrice;
            }

            return Ok(products);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(new { Message = $"You requested item with ID: {id}" });
        }
    }
}
