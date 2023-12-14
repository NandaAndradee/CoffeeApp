namespace CoffeeApp.Domain.Models
{
    public class CafeinneLevels
    {
        public string CoffeeCode { get; private set; }
        public int CaffeineLevel { get; private set; }

        public CafeinneLevels(string coffeeCode, int caffeineLevel)
        {
            CoffeeCode = coffeeCode;
            CaffeineLevel = caffeineLevel;
        }
    }
}
