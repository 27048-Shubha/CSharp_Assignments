using Assignment3_InventoryManagement.Models;
using Assignment3_InventoryManagement.Repository;
using System.Collections.Generic;

namespace Assignment3_InventoryManagement.Services
{
    /// <summary>
    /// Manages CRUD calls to Repository.
    /// </summary>
    public class InventoryService
    {
        private readonly ProductRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class.
        /// </summary>
        /// <param name="repository">Object for calling repository for operations.</param>
        public InventoryService(ProductRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Creates object to be stored in Product list.
        /// </summary>
        /// <param name="name">Name of the product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="stock">Stock Quantity of the product</param>
        public void AddProduct(string name, decimal price, int stock)
        {
            // if product name, price, stock are valid
            Product product = new Product(name, price, stock);
            _repository.AddProduct(product);
        }

        /// <summary>
        /// Gets Guid of the product and calls repo for deletion
        /// </summary>
        /// <param name="name">Name of the product to be deleted.</param>
        public void RemoveProduct(string name)
        {
            Guid productId = _repository.GetProductId(name);
            _repository.DeleteProduct(productId);
        }

        //UpdateProduct

        /// <summary>
        /// Returns list of Products in Product list.
        /// </summary>
        /// <returns>List of Products</returns>
        public List<Product> ListProducts()
        {
            return _repository.ViewProducts();
        }

        /// <summary>
        /// Calls repo to search for the product.
        /// </summary>
        /// <param name="name">Name of the product.</param>
        /// <returns>Product object holding details on product to be searched.</returns>
        public Product FindProduct(string name)
        {
            return _repository.SearchProduct(name);
        }
    }
}