namespace Assignment3_InventoryManagement.Repository
{
    using Assignment3_InventoryManagement.Models;

    /// <summary>
    /// Manages CRUD operations of Inventory Management System.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>();

        /// <summary>
        /// Inserts new _products.
        /// </summary>
        /// <param name="product">Product object holding user input.</param>
        public void AddProduct(Product product)
        {
            this._products.Add(product);
        }

        /// <summary>
        /// Updates price of the _products.
        /// </summary>
        /// <param name="pId">Guid of the _products to be updated.</param>
        /// <param name="price">New Price to be updated.</param>
        public void UpdatePrice(Guid pId, decimal price)
        {
            Product? product = this._products.FirstOrDefault(p => p.Id == pId);
            product.Price = price;
        }

        /// <summary>
        /// Updates stock quantity of the _products.
        /// </summary>
        /// <param name="pId">Guid of the _products to be updated.</param>
        /// <param name="stock">New stock value to be updated.</param>
        public void UpdateStock(Guid pId, decimal stock)
        {
            Product? product = this._products.FirstOrDefault(p => p.Id == pId);
            product.StockQuantity = stock;
        }

        /// <summary>
        /// Gets _products price.
        /// </summary>
        /// <param name="pId">The id of the _products.</param>
        /// <returns>The price of the _products.</returns>
        public decimal GetProductPrice(Guid pId)
        {
            Product? foundProduct = this._products.FirstOrDefault(p => p.Id == pId);
            return foundProduct?.Price ?? 0m;
        }

        /// <summary>
        /// Gets stock quantity of the _products.
        /// </summary>
        /// <param name="pId">The Id of the _products.</param>
        /// <returns>The stock quantity of the _products.</returns>
        public decimal GetProductStock(Guid pId)
        {
            Product? foundProduct = this._products.FirstOrDefault(p => p.Id == pId);
            return foundProduct?.StockQuantity ?? 0m;
        }

        /// <summary>
        /// Deletes existing _products.
        /// </summary>
        /// <param name="productId">Guid of the _products to be deleted.</param>
        public void DeleteProduct(Guid productId)
        {
            this._products.RemoveAll(item => item.Id == productId);
        }

        /// <summary>
        /// Lists list of all _products.
        /// </summary>
        /// <returns>Returns clone copy of _products.</returns>
        public List<Product> ViewProducts()
        {
            List<Product> clone = new List<Product>();
            foreach (Product item in this._products)
            {
                clone.Add(new Product(item.Id, item.Name, item.Price, item.StockQuantity));
            }

            return clone;
        }

        /// <summary>
        /// Search for the _products based on the name.
        /// </summary>
        /// <param name="name">Details of the _products.</param>
        /// <returns>Returns _products details in the cloned copy.</returns>
        public List<Product> SearchProduct(string name)
        {
            List<Product> products = new List<Product>();
            foreach (Product product in this._products)
            {
                if (product.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    products.Add(new Product(product.Id, product.Name, product.Price, product.StockQuantity));
                }
            }

            return products;
        }

        /// <summary>
        /// Finds prodcut id based on the name.
        /// </summary>
        /// <param name="name">Name of the _products whose Guid to be found.</param>
        /// <returns>Guid of the _products.</returns>
        public Guid GetProductId(string name)
        {
            for (int i = 0; i < this._products.Count; i++)
            {
                if (this._products[i].Name == name)
                {
                    return this._products[i].Id;
                }
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Gets count of _products inside _products list.
        /// </summary>
        /// <returns>The total number of _products in the _products list. </returns>
        public int GetProductCount()
        {
            return this._products.Count;
        }
    }
}