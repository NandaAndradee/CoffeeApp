using CoffeeApp.Aplication.ApiModels;

namespace Aplication.Interfaces
{
    public interface ICoffeeService
    {
        Task<CoffeeResponse> GetAll();
        Task<RecommendationResponse> Calculate(ConsumptionRequest consumption);
    }
}
