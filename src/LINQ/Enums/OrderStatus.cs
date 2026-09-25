namespace LINQ.Enums
{
    /// <summary>
    /// Represents the current status of an order.
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// The order has been created and is being processed.
        /// </summary>
        Processing,

        /// <summary>
        /// The order has been shipped to the customer.
        /// </summary>
        Shipped,

        /// <summary>
        /// The order has been successfully delivered.
        /// </summary>
        Delivered,

        /// <summary>
        /// The order has been cancelled.
        /// </summary>
        Cancelled,

        /// <summary>
        /// The delivered order has been returned.
        /// </summary>
        Returned,
    }
}
