namespace CoffeeApp.Aplication.Exceptions
{
    public class InvalidCodeException : Exception
    {
        public InvalidCodeException(string? message) : base(message)
        {
        }
    }
}
