using Assignment3_InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_InventoryManagement.Repository
{
    /// <summary>
    /// Interface that holds product operations.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Inserts new product
        /// </summary>
        /// <param name="product">Product object holding user input</param>
        public void AddProduct(Product product);

        //UpdateProduct

        /// <summary>
        /// Deletes existing product
        /// </summary>
        /// <param name="productId">Guid of the product to be deleted.</param>
        public void DeleteProduct(Guid productId);

        /// <summary>
        /// Lists list of all products
        /// </summary>
        /// <returns>Returns clone copy of products</returns>
        public List<Product> ViewProducts();

        /// <summary>
        /// Search for the product based on the name
        /// </summary>
        /// <param name="name">Details of the product</param>
        /// <returns>Returns product details in the cloned copy</returns>
        public Product SearchProduct(string name);

        /// <summary>
        /// Finds prodcut id based on the name
        /// </summary>
        /// <param name="name">Name of the product whose Guid to be found</param>
        /// <returns>Guid of the product.</returns>
        public Guid GetProductId(string name);
    }
}