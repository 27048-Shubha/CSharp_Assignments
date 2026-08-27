using LINQ.Models;

namespace LINQ.Tasks
{
    public class Task4
    {
        public List<Product> SortProduct(IReadOnlyList<Product> products)
        {
            return products.OrderByDescending(product => product.Price).Where(product => product.Category == Enums.ProductCategory.Books).ToList();
        }

        public List<Product> OptimizedSortProduct(IReadOnlyList<Product> products)
        {
            return products.Where(product => product.Category == Enums.ProductCategory.Books).OrderByDescending(product => product.Price).ToList();
        }
    }
}
