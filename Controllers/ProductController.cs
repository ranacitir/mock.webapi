using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mock.webapi.Entity;
using mock.webapi.Services;
using System.Text.Json;

namespace mock.webapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
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
    }
}
