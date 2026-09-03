namespace Assignment3_InventoryManagement.Models
{
    /// <summary>
    /// Manages properites of Product class.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">Name of the products.</param>
        /// <param name="price">Price of the products.</param>
        /// <param name="stock">Stock quantity of the products.</param>
        public Product(string name, decimal price, decimal stock)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.Price = price;
            this.StockQuantity = stock;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with same GUID.
        /// </summary>
        /// <param name="id">Existing Guid of the products.</param>
        /// <param name="name">Name of the products.</param>
        /// <param name="price">Price of the products.</param>
        /// <param name="stock">Stock Quantity of the products.</param>
        public Product(Guid id, string name, decimal price, decimal stock)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.StockQuantity = stock;
        }

        /// <summary>
        /// Gets id of products.
        /// </summary>
        /// <value>Guid of the products.</value>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets or sets name of products.
        /// </summary>
        /// <value>Name of the products.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets price of products.
        /// </summary>
        /// <value>Price of the products.</value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets stock quantity of products.
        /// </summary>
        /// <value>Stock Quantity of the products.</value>
        public decimal StockQuantity { get; set; }
    }
}