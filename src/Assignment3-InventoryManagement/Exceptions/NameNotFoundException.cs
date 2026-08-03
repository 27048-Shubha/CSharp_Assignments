namespace Assignment3_InventoryManagement.Exceptions
{
    using System;

    /// <summary>
    /// User Defined Exception when Name Not is not found in product repo extended from Exception.
    /// </summary>
    public class NameNotFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameNotFoundException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        public NameNotFoundException(string? message)
            : base(message)
        {
            // User Defined Exception.
        }
    }
}
