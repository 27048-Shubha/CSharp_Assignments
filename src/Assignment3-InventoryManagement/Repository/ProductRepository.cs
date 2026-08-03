namespace Assignment3_InventoryManagement.Repository
{
    using Assignment3_InventoryManagement.Models;

    /// <summary>
    /// Manages CRUD operations of Inventory Management System.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private List<Product> product = new List<Product>();

        /// <summary>
        /// Inserts new product.
        /// </summary>
        /// <param name="product">Product object holding user input.</param>
        public void AddProduct(Product product)
        {
            this.product.Add(product);
        }

        /// <summary>
        /// Updates price of the product.
        /// </summary>
        /// <param name="pId">Guid of the product to be updated.</param>
        /// <param name="price">New Price to be updated.</param>
        public void UpdatePrice(Guid pId, decimal price)
        {
            Product? product = this.product.First(p => p.Id == pId);
            product.Price = price;
        }

        /// <summary>
        /// Updates stock quantity of the product.
        /// </summary>
        /// <param name="pId">Guid of the product to be updated.</param>
        /// <param name="stock">New stock value to be updated.</param>
        public void UpdateStock(Guid pId, decimal stock)
        {
            Product? product = this.product.First(p => p.Id == pId);
            product.StockQuantity = stock;
        }

        /// <summary>
        /// Gets product price.
        /// </summary>
        /// <param name="pId">The id of the product.</param>
        /// <returns>The price of the product.</returns>
        public decimal GetProductPrice(Guid pId)
        {
            Product? foundProduct = this.product.FirstOrDefault(p => p.Id == pId);
            return foundProduct?.Price ?? 0m;
        }

        /// <summary>
        /// Gets stock quantity of the product.
        /// </summary>
        /// <param name="pId">The Id of the product.</param>
        /// <returns>The stock quantity of the product.</returns>
        public decimal GetProductStock(Guid pId)
        {
            Product? foundProduct = this.product.FirstOrDefault(p => p.Id == pId);
            return foundProduct?.StockQuantity ?? 0m;
        }

        /// <summary>
        /// Deletes existing product.
        /// </summary>
        /// <param name="productId">Guid of the product to be deleted.</param>
        public void DeleteProduct(Guid productId)
        {
            for (int i = 0; i < this.product.Count; i++)
            {
                if (this.product[i].Id == productId)
                {
                    this.product.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Lists list of all products.
        /// </summary>
        /// <returns>Returns clone copy of products.</returns>
        public List<Product> ViewProducts()
        {
            List<Product> clone = new List<Product>();
            foreach (Product item in this.product)
            {
                clone.Add(new Product(item.Id, item.Name, item.Price, item.StockQuantity));
            }

            return clone;
        }

        /// <summary>
        /// Search for the product based on the name.
        /// </summary>
        /// <param name="name">Details of the product.</param>
        /// <returns>Returns product details in the cloned copy.</returns>
        public List<Product> SearchProduct(string name)
        {
            List<Product> products = new List<Product>();
            foreach (Product product in this.product)
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
        /// <param name="name">Name of the product whose Guid to be found.</param>
        /// <returns>Guid of the product.</returns>
        public Guid GetProductId(string name)
        {
            for (int i = 0; i < this.product.Count; i++)
            {
                if (this.product[i].Name == name)
                {
                    return this.product[i].Id;
                }
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Gets count of products inside product list.
        /// </summary>
        /// <returns>The total number of products in the product list. </returns>
        public int GetProductCount()
        {
            return this.product.Count;
        }
    }
}