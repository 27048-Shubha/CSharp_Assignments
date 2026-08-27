using LINQ.Models;
using LINQ.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ.Tasks
{
    public class Task2
    {
        private IReadOnlyList<Product> _products;

        public List<CategorySummaryDTO> FilterProducts(IReadOnlyList<Product> products)
        {
            List<CategorySummaryDTO> filteredProducts = products.GroupBy(product => product.Category)
                .Select(group => new CategorySummaryDTO()
                {
                    Category = group.Key,
                    Count = group.Count(),
                    MostExpensiveProduct = group.OrderByDescending(
                        product => product.Price
                    ).First(),
                }).ToList();

            return filteredProducts;
        }

        public List<ProductSupplierInfoDTO> PerformInnerJoin(IReadOnlyList<Product> products, IReadOnlyList<Supplier> suppliers)
        {
            List<ProductSupplierInfoDTO> joinedInfo = (from product in products
                                                       join supplier in suppliers
                                                       on product.Id equals supplier.SupplierId
                                                       select new ProductSupplierInfoDTO()
                                                       {
                                                           ProductId = product.Id,
                                                           ProductName = product.Name,
                                                           ProductPrice = product.Price,
                                                           ProductCategory = product.Category,
                                                           SupplierId = supplier.SupplierId,
                                                           SupplierName = supplier.SupplierName,
                                                       }).ToList();
            return joinedInfo;
        }
    }
}
