using System.Text.Json;

namespace mock.webapi.Services
{
    public class GoldPriceService
    {
        private readonly HttpClient _httpClient;

        public GoldPriceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<double> GetGoldPriceAsync()
        {

            var response = await _httpClient.GetAsync("https://api.gold-api.com/price/XAU");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            // GoldAPI JSON response'unda "price" alanı gram/USD fiyatını verir
            double price = doc.RootElement.GetProperty("price").GetDouble();
            return price;
        }
    }
}