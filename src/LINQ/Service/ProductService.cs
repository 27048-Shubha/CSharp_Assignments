using LINQ.Models;
using LINQ.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Service
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        internal ProductService(ProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public void Add(int productId, string productName, int productPrice, Enums.ProductCategory category)
        {
            Product product = new Product()
            {
                Id = productId,
                Name = productName,
                Price = productPrice,
                Category = category,
            };

            this._productRepository.Add(product);
        }

        public IReadOnlyList<Product> GetAll()
        {
            return this._productRepository.GetAll();
        }
    }
}
