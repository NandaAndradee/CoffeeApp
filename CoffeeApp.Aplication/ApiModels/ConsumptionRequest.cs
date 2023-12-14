using System.Text.Json.Serialization;

namespace CoffeeApp.Aplication.ApiModels
{
    public class ConsumptionRequest
    {
        [JsonPropertyName("consumptions")]
        public List<ConsumptionRequestItem> ConsumptionRequestItem { get; set; }

        public ConsumptionRequest()
        {
            ConsumptionRequestItem = new List<ConsumptionRequestItem>();
        }
    }
}
