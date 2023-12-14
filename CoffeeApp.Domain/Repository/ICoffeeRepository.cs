using CoffeeApp.Domain.Models;

namespace CoffeeApp.Domain.Repository
{
    public interface ICoffeeRepository
    {
        Task<IEnumerable<Coffees>> GetAll();
        Task<IEnumerable<CafeinneLevels>> GetCafeinneLevels();
        Task<Coffees?> GetCoffeeByCode(string coffeeCode);
    }
}
