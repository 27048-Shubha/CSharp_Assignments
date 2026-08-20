namespace Assignment3_InventoryManagement.Models
{
    /// <summary>
    /// Manages Properites of Product class.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">Name of the _products.</param>
        /// <param name="price">Price of the _products.</param>
        /// <param name="stock">Stock Quantity of the _products.</param>
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
        /// <param name="id">Existing Guid of the _products.</param>
        /// <param name="name">Name of the _products.</param>
        /// <param name="price">Price of the _products.</param>
        /// <param name="stock">Stock Quantity of the _products.</param>
        public Product(Guid id, string name, decimal price, decimal stock)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.StockQuantity = stock;
        }

        /// <summary>
        /// Gets id of _products.
        /// </summary>
        /// <value>Guid of the _products.</value>
        public Guid Id
        {
            get; private set;
        }

        /// <summary>
        /// Gets or sets name of _products.
        /// </summary>
        /// <value>Name of the _products.</value>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets _price of _products.
        /// </summary>
        /// <value>Price of the _products.</value>
        public decimal Price
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets stock quantity of _products.
        /// </summary>
        /// <value>Stock Quantity of the _products.</value>
        public decimal StockQuantity
        {
            get; set;
        }
    }
}