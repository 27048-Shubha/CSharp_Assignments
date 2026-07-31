namespace Assignment3_InventoryManagement.Exceptions
{
    using System;

    /// <summary>
    /// User Defined Exception when Name Not is not found in product repo extended from Exception.
    /// </summary>
    public class NameNotFound : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameNotFound"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        public NameNotFound(string? message)
            : base(message)
        {
            // User Defined Exception.
        }
    }
}
