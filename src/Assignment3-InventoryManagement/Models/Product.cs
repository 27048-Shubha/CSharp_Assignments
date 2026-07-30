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
        /// <param name="name">Name of the product.</param>
        /// <param name="price">Price of the product.</param>
        /// <param name="stock">Stock Quantity of the product.</param>
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
        /// <param name="id">Existing Guid of the product</param>
        /// <param name="name">Name of the product.</param>
        /// <param name="price">Price of the product.</param>
        /// <param name="stock">Stock Quantity of the product.</param>
        public Product(Guid id, string name, decimal price, decimal stock)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.StockQuantity = stock;
        }

        /// <summary>
        /// Gets id of product
        /// </summary>
        /// <value>Guid of the product</value>
        public Guid Id
        {
            get; private set;
        }

        /// <summary>
        /// Gets or sets name of product
        /// </summary>
        /// <value>Name of the product</value>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets price of product
        /// </summary>
        /// <value>Price of the product</value>
        public decimal Price
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets stock quantity of product
        /// </summary>
        /// <value>Stock Quantity of the product</value>
        public decimal StockQuantity
        {
            get; set;
        }
    }
}