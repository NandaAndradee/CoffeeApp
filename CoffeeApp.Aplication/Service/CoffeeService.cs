using Aplication.Interfaces;
using CoffeeApp.Aplication.ApiModels;
using CoffeeApp.Aplication.Exceptions;
using CoffeeApp.Domain.Constants;
using CoffeeApp.Domain.Exceptions;
using CoffeeApp.Domain.Models;
using CoffeeApp.Domain.Repository;

namespace Aplication.Service
{
    public class CoffeeService : ICoffeeService
    {
        private readonly ICoffeeRepository _coffeeRepository;

        public CoffeeService(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        public async Task<CoffeeResponse> GetAll()
        {
            var coffeeList = await _coffeeRepository.GetAll();

            // Map a list of CoffeeModel to a list of CoffeesApiModel
            var coffeeItems = coffeeList.Select(coffee => new CoffeeResponseItem
            {
                CoffeeCode = coffee.Code,
                CoffeeName = coffee.Name
            }).ToList();

            return new CoffeeResponse() { CoffeeResponseItems = coffeeItems };
        }

        public async Task<RecommendationResponse> Calculate(ConsumptionRequest consumption)
        {
            var caffeineLevels = await _coffeeRepository.GetCafeinneLevels();

            var currentBodyCaffeineLevel = await GetCurrentBodyCaffeineLevel(consumption, caffeineLevels);

            if (currentBodyCaffeineLevel == 0)
                throw new InvalidCodeException("Invalid Code");

            var response = new RecommendationResponse();

            foreach (var coffeeDetail in caffeineLevels)
            {
                var coffee = await _coffeeRepository.GetCoffeeByCode(coffeeDetail.CoffeeCode);

                if (coffee != null)
                {
                    var waitTime = CalcWaitTime(currentBodyCaffeineLevel, coffeeDetail.CaffeineLevel);

                    response.RecommendationResponseItems.Add(new RecommendationResponseItem
                    {
                        CoffeeCode = coffee.Code,
                        CoffeeName = coffee.Name,
                        WaitTimeToDrink = waitTime
                    });
                }
            }

            return response;
        }

        private int CalcWaitTime(double currentBodyCaffeineLevel, int coffeeCaffeineLevel)
        {
            var remainingCaffeine = CoffeeConstants.OPTIMAL_CAFFEINE_LEVEL_MG - currentBodyCaffeineLevel;
            if (remainingCaffeine >= coffeeCaffeineLevel) return 0;

            var ratio = coffeeCaffeineLevel / currentBodyCaffeineLevel;
            return (int)Math.Abs(Math.Ceiling(CoffeeConstants.MEAN_HALF_LIFE_CAFFEINE_SEC * Math.Log(ratio, 0.5) / 60));
        }

        private async Task<double> GetCurrentBodyCaffeineLevel(ConsumptionRequest consumption, IEnumerable<CafeinneLevels> caffeineLevels)
        {
            var currentBodyCaffeineLevel = 0.0;

            foreach (var coffee in consumption.ConsumptionRequestItem)
            {
                var coffeeDetail = caffeineLevels.FirstOrDefault(l => l.CoffeeCode == coffee.CoffeeCode);

                if (coffeeDetail != null)
                {
                    if (coffee.TimeYouDrank == null || coffee.TimeYouDrank <= 0)
                    {
                        throw new TimeNotSpecifiedException("The time field is mandatory and must be greater than zero.");
                    }

                    currentBodyCaffeineLevel += CalculateCaffeineLevel(coffeeDetail.CaffeineLevel, coffee.TimeYouDrank * 60);
                }
            }

            if (currentBodyCaffeineLevel >= CoffeeConstants.MAXIMUM_DAILY_CAFFEINE_MG)
            {
                throw new DailyLimitExceededException("[]");
            }

            return currentBodyCaffeineLevel;
        }

        private double CalculateCaffeineLevel(int initialQuantity, int elapsedTime)
        {
            return initialQuantity * Math.Pow(0.5, elapsedTime / CoffeeConstants.MEAN_HALF_LIFE_CAFFEINE_SEC);
        }

    }

}
