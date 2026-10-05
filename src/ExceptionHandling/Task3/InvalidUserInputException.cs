namespace ExceptionHandling.Task3
{
    /// <summary>
    /// Custom exception to handle invalid user input.
    /// </summary>
    public class InvalidUserInputException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidUserInputException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        public InvalidUserInputException(string message)
            : base(message)
        {
        }
    }
}