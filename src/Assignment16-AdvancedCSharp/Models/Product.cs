using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// Represents product information.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">Name of the product.</param>
        /// <param name="category">Category of the product.</param>
        /// <param name="price">Price of the product.</param>
        internal Product(string name, string category, double price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>Name of the product.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the category of the product.
        /// </summary>
        /// <value>Category of the product.</value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        /// <value>Price of the product.</value>
        public double Price { get; set; }
    }
}
