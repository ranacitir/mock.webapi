using System.Text.Json.Serialization;

namespace Mock
{
    public class Product
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("popularityScore")]
        public double PopularityScore { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("images")]
        public Images Images { get; set; } = null!;

        public double Price { get; set; }

    }

    public class Images
    {
        [JsonPropertyName("yellow")]
        public string Yellow { get; set; }

        [JsonPropertyName("rose")]
        public string Rose { get; set; }

        [JsonPropertyName("white")]
        public string White { get; set; }
    }
}
