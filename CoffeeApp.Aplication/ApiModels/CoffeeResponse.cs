using System.Text.Json.Serialization;

namespace CoffeeApp.Aplication.ApiModels
{
    public class CoffeeResponse
    {
        [JsonPropertyName("coffees")]
        public List<CoffeeResponseItem> CoffeeResponseItems { get; set; }

        public CoffeeResponse()
        {
            CoffeeResponseItems = new List<CoffeeResponseItem>();
        }
    }
}
