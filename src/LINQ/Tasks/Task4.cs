namespace LINQ.Tasks
{
    using LINQ.Models;

    /// <summary>
    /// Demonstrates product sorting using different LINQ approaches.
    /// </summary>
    public class Task4
    {
        /// <summary>
        /// Sorts book products by price in descending order.
        /// </summary>
        /// <param name="products">The collection of products.</param>
        /// <returns>A sorted list of books.</returns>
        public List<Product> SortProduct(IReadOnlyList<Product> products)
        {
            return products.Distinct().OrderByDescending(product => product.Price).Where(product => product.Category == Enums.ProductCategory.Books).ToList();
        }

        /// <summary>
        /// Filters books first and then sorts them by price in descending order.
        /// </summary>
        /// <param name="products">The collection of products.</param>
        /// <returns>A sorted list of books.</returns>
        public List<Product> OptimizedSortProduct(IReadOnlyList<Product> products)
        {
            return products.Where(product => product.Category == Enums.ProductCategory.Books).OrderByDescending(product => product.Price).ToList();
        }
    }
}
