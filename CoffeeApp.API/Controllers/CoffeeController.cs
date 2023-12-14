using Aplication.Interfaces;
using CoffeeApp.Aplication.ApiModels;
using CoffeeApp.Aplication.Exceptions;
using CoffeeApp.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeApp.API.Controllers
{
    [ApiController]
    [Route("v1")]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeService _coffeeService;

        public CoffeeController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        [HttpGet("coffees")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _coffeeService.GetAll());
        }

        [HttpPost("calculate")]
        public async Task<IActionResult> Post(ConsumptionRequest consumption)
        {
            try
            {
                var responseRecommendations = await _coffeeService.Calculate(consumption);
                return Ok(responseRecommendations);
            }
            catch (TimeNotSpecifiedException time)
            {
                return BadRequest(time.Message);
            }
            catch (InvalidCodeException invalidCode)
            {
                return BadRequest(invalidCode.Message);
            }
            catch (DailyLimitExceededException dailyLimitExceeded)
            {
                return Ok(dailyLimitExceeded.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        
    }
}
