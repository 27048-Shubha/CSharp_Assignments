namespace LINQ.Models.DTOs
{
    /// <summary>
    /// Represents product information used for filtering results.
    /// </summary>
    public class FilterProductsDTO
    {
        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        /// <value>Name of the product.</value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        /// <value>Price of the product.</value>
        public decimal ProductPrice { get; set; }
    }
}
