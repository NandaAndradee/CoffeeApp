using CoffeeApp.Domain.Models;
using CoffeeApp.Domain.Repository;

namespace CoffeeApp.Repository
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly List<Coffees> coffees;
        private readonly List<CafeinneLevels> cafeinneLevels;

        public CoffeeRepository()
        {
            coffees = new List<Coffees>
            {
                new Coffees("Black Coffee", "blk"),
                new Coffees("Espresso", "esp"),
                new Coffees("Cappuccino", "cap"),
                new Coffees("Latte", "lat"),
                new Coffees("Flat White", "wht"),
                new Coffees("Cold Brew", "clb"),
                new Coffees("Decaf Coffee", "dec")
            };

            cafeinneLevels = new List<CafeinneLevels>
            {
                new CafeinneLevels("blk", 95),
                new CafeinneLevels("esp", 63),
                new CafeinneLevels("cap", 63),
                new CafeinneLevels("lat", 63),
                new CafeinneLevels("wht", 63),
                new CafeinneLevels("clb", 120),
                new CafeinneLevels("dec", 5)
            };
        }

        public async Task<IEnumerable<Coffees>> GetAll()
        {
            return coffees.OrderBy(c => c.Name).ToList();
        }

        public async Task<IEnumerable<CafeinneLevels>> GetCafeinneLevels()
        {
            return cafeinneLevels;
        }

        public async Task<Coffees?> GetCoffeeByCode(string coffeeCode)
        {
            return coffees.FirstOrDefault(c => c.Code == coffeeCode);
        }
    }
}
