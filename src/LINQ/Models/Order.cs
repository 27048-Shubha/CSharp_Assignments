namespace LINQ.Models
{
    /// <summary>
    /// Represents a customer order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>Id of the order.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        /// <value>Date of the order.</value>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the current order status.
        /// </summary>
        /// <value>Status of the order.</value>
        public Enums.OrderStatus Status { get; set; }
    }
}
