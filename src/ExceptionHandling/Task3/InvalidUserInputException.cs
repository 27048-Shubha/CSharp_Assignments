namespace ExceptionHandling.Task3
{
    public class InvalidUserInputException : Exception
    {
        public InvalidUserInputException(string message)
            : base(message)
        {
        }
    }
}