using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQ.Models;
using LINQ.Models.DTOs;

namespace LINQ.Tasks
{
    public class Task1
    {
        private IReadOnlyList<Product> _products;

        public List<FilterProductsDTO> FilterProducts(IReadOnlyList<Product> products)
        {
            List<Product> filteredProducts = products.Where(product => (product.Category == Enums.ProductCategory.Electronics) && (product.Price > 500)).ToList();
            return filteredProducts.Select(product => new FilterProductsDTO()
            {
                ProductName = product.Name,
                ProductPrice = product.Price,
            }).ToList();
        }

        public List<FilterProductsDTO> SortProducts(List<FilterProductsDTO> products)
        {
            return products.OrderByDescending(product => product.ProductPrice).ToList();
        }

        public decimal FindAverage(List<FilterProductsDTO> products)
        {
            return products.Average(product => product.ProductPrice);
        }
    }
}
