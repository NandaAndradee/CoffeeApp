using System.Text.Json.Serialization;

namespace CoffeeApp.Aplication.ApiModels
{
    public class RecommendationResponseItem
    {
        [JsonPropertyName("name")]
        public string CoffeeName { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        public string CoffeeCode { get; set; } = string.Empty;

        [JsonPropertyName("wait")]
        public int WaitTimeToDrink { get; set; }

    }
}
