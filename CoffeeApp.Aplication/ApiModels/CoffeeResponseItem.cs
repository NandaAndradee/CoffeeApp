using System.Text.Json.Serialization;

namespace CoffeeApp.Aplication.ApiModels
{
    public class CoffeeResponseItem
    {
        [JsonPropertyName("code")]
        public string CoffeeCode { get; set; } = string.Empty;

        [JsonPropertyName("name")]
        public string CoffeeName { get; set; } = string.Empty;
    }
}
