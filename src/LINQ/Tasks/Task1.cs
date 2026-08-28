namespace LINQ.Tasks
{
    using LINQ.Models;
    using LINQ.Models.DTOs;

    /// <summary>
    /// Performs filtering, sorting, and aggregation operations on products.
    /// </summary>
    public class Task1
    {
        /// <summary>
        /// Filters electronics products with a price greater than 500and projects the result into DTO objects.
        /// </summary>
        /// <param name="products">The collection of products to filter.</param>
        /// <returns>A list of filtered product information.</returns>
        public List<FilterProductsDTO> FilterProducts(IReadOnlyList<Product> products)
        {
            List<Product> filteredProducts = products.Where(product => (product.Category == Enums.ProductCategory.Electronics) && (product.Price > 500)).ToList();
            return filteredProducts.Select(product => new FilterProductsDTO()
            {
                ProductName = product.Name,
                ProductPrice = product.Price,
            }).ToList();
        }

        /// <summary>
        /// Sorts products by price in descending order.
        /// </summary>
        /// <param name="products">The collection of products to sort.</param>
        /// <returns>A sorted list of products.</returns>
        public List<FilterProductsDTO> SortProducts(List<FilterProductsDTO> products)
        {
            return products.OrderByDescending(product => product.ProductPrice).ToList();
        }

        /// <summary>
        /// Calculates the average price of products.
        /// </summary>
        /// <param name="products">The collection of products.</param>
        /// <returns>The average product price.</returns>
        public decimal FindAverage(List<FilterProductsDTO> products)
        {
            return products.Average(product => product.ProductPrice);
        }
    }
}
