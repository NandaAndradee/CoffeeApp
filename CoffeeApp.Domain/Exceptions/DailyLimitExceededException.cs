namespace CoffeeApp.Domain.Exceptions
{
    public class DailyLimitExceededException : Exception
    {
        public DailyLimitExceededException()
        {
        }
        public DailyLimitExceededException(string message) : base(message) { }
        public DailyLimitExceededException(string message, Exception inner) : base(message, inner) { }
       
    }
}
