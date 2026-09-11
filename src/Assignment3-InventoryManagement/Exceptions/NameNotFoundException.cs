namespace Assignment3_InventoryManagement.Exceptions
{
    using System;

    /// <summary>
    /// User Defined Exception when Name Not is not found in products repository extended from Exception.
    /// </summary>
    public class NameNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameNotFoundException"/> class.
        /// </summary>
        public NameNotFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        public NameNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">Inner exception of exception class.</param>
        public NameNotFoundException(
            string message,
            Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
