namespace Assignment3_InventoryManagement.Exceptions
{
    using System;

    /// <summary>
    /// User Defined Exception when Name Not is not found in _products repo extended from Exception.
    /// </summary>
    public class EmptyInventoryException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmptyInventoryException"/> class.
        /// </summary>
        /// <param name="message">Error message.</param>
        public EmptyInventoryException(string? message)
            : base(message)
        {
            // User Defined Exception.
        }
    }
}
