using System.Text.Json.Serialization;

namespace CoffeeApp.Aplication.ApiModels
{
    public class RecommendationResponse
    {
        [JsonPropertyName("recommendations")]
        public List<RecommendationResponseItem> RecommendationResponseItems { get; set; }

        public RecommendationResponse()
        {
            RecommendationResponseItems = new List<RecommendationResponseItem>();
        }

    }
}
