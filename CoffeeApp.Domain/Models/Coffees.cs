namespace CoffeeApp.Domain.Models
{
    public class Coffees
    {
        public string Name { get; private set; }
        public string Code { get; private set; }

        public Coffees(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }


}
