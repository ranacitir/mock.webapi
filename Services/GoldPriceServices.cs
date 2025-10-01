using System.Text.Json;

namespace Mock.Services
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
            // Örnek: GoldAPI.io kullanımı
            _httpClient.DefaultRequestHeaders.Add("x-access-token", "goldapi-fwpichsmg8bfg2t-io");

            var response = await _httpClient.GetAsync("https://www.goldapi.io/api/XAU/USD");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            // GoldAPI JSON response'unda "price" alanı gram/USD fiyatını verir
            double price = doc.RootElement.GetProperty("price").GetDouble();
            return price;
        }
    }
}