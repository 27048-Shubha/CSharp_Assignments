using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3_InventoryManagement.Models;

namespace Assignment3_InventoryManagement.Repository
{
    using Assignment3_InventoryManagement.Models;

    /// <summary>
    /// Manages CRUD operations of Inventory Management System
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private List<Product> _product = new List<Product>();

        /// <summary>
        /// Inserts new product
        /// </summary>
        /// <param name="product">Product object holding user input</param>
        public void AddProduct(Product product)
        {
            _product.Add(product);
        }

        //UpdateProduct

        /// <summary>
        /// Deletes existing product
        /// </summary>
        /// <param name="productId">Guid of the product to be deleted.</param>
        public void DeleteProduct(Guid productId)
        {
            for (int i = 0; i < _product.Count; i++)
            {
                if (_product[i].Id == productId)
                {
                    _product.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Lists list of all products
        /// </summary>
        /// <returns>Returns clone copy of products</returns>
        public List<Product> ViewProducts()
        {
            List<Product> clone = new List<Product>();
            foreach(Product item in _product)
            {
                clone.Add(new Product(item.Name, item.Price, item.StockQuantity));
            }
            return clone;
        }

        /// <summary>
        /// Search for the product based on the name
        /// </summary>
        /// <param name="name">Details of the product</param>
        /// <returns>Returns product details in the cloned copy</returns>
        public Product SearchProduct(string name)
        {
            for (int i = 0; i < _product.Count; i++)
            {
                if (_product[i].Name == name)
                {
                    Product clone = new Product(_product[i].Name, _product[i].Price, _product[i].StockQuantity);
                    return clone;
                }
            }
            return null;
        }

        /// <summary>
        /// Finds prodcut id based on the name
        /// </summary>
        /// <param name="name">Name of the product whose Guid to be found</param>
        /// <returns>Guid of the product.</returns>
        public Guid GetProductId(string name)
        {
            for (int i = 0; i < _product.Count; i++)
            {
                if (_product[i].Name == name)
                {
                    return _product[i].Id;
                }
            }
            return Guid.Empty;
        }
    }
}