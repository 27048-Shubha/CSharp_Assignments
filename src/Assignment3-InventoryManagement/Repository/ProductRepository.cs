namespace Assignment3_InventoryManagement.Repository
{
    using Assignment3_InventoryManagement.Models;

    /// <summary>
    /// Manages CRUD operations of the inventory management system.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>();

        /// <summary>
        /// Inserts new products.
        /// </summary>
        /// <param name="product">Product object holding user input.</param>
        public void AddProduct(Product product)
        {
            this._products.Add(product);
        }

        /// <summary>
        /// Updates price of the products.
        /// </summary>
        /// <param name="pId">Guid of the products to be updated.</param>
        /// <param name="price">New Price to be updated.</param>
        public void UpdatePrice(Guid pId, decimal price)
        {
            Product? product = this._products.FirstOrDefault(p => p.Id == pId);
            product.Price = price;
        }

        /// <summary>
        /// Updates stock quantity of the products.
        /// </summary>
        /// <param name="pId">Guid of the products to be updated.</param>
        /// <param name="stock">New stock value to be updated.</param>
        public void UpdateStock(Guid pId, decimal stock)
        {
            Product? product = this._products.FirstOrDefault(p => p.Id == pId);
            product.StockQuantity = stock;
        }

        /// <summary>
        /// Gets products price.
        /// </summary>
        /// <param name="pId">The id of the products.</param>
        /// <returns>The price of the products.</returns>
        public decimal GetProductPrice(Guid pId)
        {
            Product? foundProduct = this._products.FirstOrDefault(p => p.Id == pId);
            return foundProduct?.Price ?? 0m;
        }

        /// <summary>
        /// Gets stock quantity of the products.
        /// </summary>
        /// <param name="pId">The Id of the products.</param>
        /// <returns>The stock quantity of the products.</returns>
        public decimal GetProductStock(Guid pId)
        {
            Product? foundProduct = this._products.FirstOrDefault(p => p.Id == pId);
            return foundProduct?.StockQuantity ?? 0m;
        }

        /// <summary>
        /// Deletes existing products.
        /// </summary>
        /// <param name="productId">Guid of the products to be deleted.</param>
        public void DeleteProduct(Guid productId)
        {
            this._products.RemoveAll(item => item.Id == productId);
        }

        /// <summary>
        /// Lists list of all products.
        /// </summary>
        /// <returns>Returns clone copy of products.</returns>
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
        /// Search for the products based on the name.
        /// </summary>
        /// <param name="name">Details of the products.</param>
        /// <returns>Returns products details in the cloned copy.</returns>
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
        /// <param name="name">Name of the products whose Guid to be found.</param>
        /// <returns>Guid of the products.</returns>
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
        /// Gets count of products inside products list.
        /// </summary>
        /// <returns>The total number of products in the products list. </returns>
        public int GetProductCount()
        {
            return this._products.Count;
        }
    }
}