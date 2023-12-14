namespace CoffeeApp.Aplication.Exceptions
{
    public class TimeNotSpecifiedException : Exception
    {
        public TimeNotSpecifiedException(string message) : base(message) 
        { 
        }
        public TimeNotSpecifiedException(string message, Exception inner) : base(message, inner) 
        { 
        }  
    }
}
