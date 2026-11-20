namespace Assignment16_AdvancedCSharp.Models
{
    /// <summary>
    /// Represents product information.
    /// </summary>
    internal sealed class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">Name of the product.</param>
        /// <param name="category">Category of the product.</param>
        /// <param name="price">Price of the product.</param>
        public Product(string name, string category, decimal price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }

        /// <summary>
        /// Gets the name of the product.
        /// </summary>
        /// <value>Name of the product.</value>
        public string Name { get; }

        /// <summary>
        /// Gets the category of the product.
        /// </summary>
        /// <value>Category of the product.</value>
        public string Category { get; }

        /// <summary>
        /// Gets the price of the product.
        /// </summary>
        /// <value>Price of the product.</value>
        public decimal Price { get; }
    }
}
