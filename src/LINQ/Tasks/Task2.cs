namespace LINQ.Tasks
{
    using System.Collections.Generic;
    using System.Linq;
    using LINQ.Models;
    using LINQ.Models.DTOs;

    /// <summary>
    /// Performs grouping and join operations using LINQ.
    /// </summary>
    public class Task2
    {
        /// <summary>
        /// Groups products by category and generates summary information.
        /// </summary>
        /// <param name="products">The collection of products to group.</param>
        /// <returns>A list containing category summary information.</returns>
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

        /// <summary>
        /// Joins products and suppliers and returns combined information.
        /// </summary>
        /// <param name="products">The collection of products.</param>
        /// <param name="suppliers">The collection of suppliers.</param>
        /// <returns>A list containing product and supplier information.</returns>
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
