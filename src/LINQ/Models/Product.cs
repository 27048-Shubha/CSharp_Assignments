namespace LINQ.Models
{
    /// <summary>
    /// Represents a product available in the system.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>Id of the product.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        /// <value>Name of the product.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        /// <value>Price of the product.</value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        /// <value>Category of the product.</value>
        public Enums.ProductCategory Category { get; set; }
    }
}
