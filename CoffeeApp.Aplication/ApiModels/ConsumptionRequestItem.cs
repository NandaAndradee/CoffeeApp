using System.Text.Json.Serialization;

namespace CoffeeApp.Aplication.ApiModels
{
    public class ConsumptionRequestItem
    {
        [JsonPropertyName("code")]
        public string CoffeeCode { get; set; } = string.Empty;

        [JsonPropertyName("time")]
        public int TimeYouDrank { get; set; }
    }
}
