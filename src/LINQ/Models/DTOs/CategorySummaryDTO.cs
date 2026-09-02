namespace LINQ.Models.DTOs
{
    /// <summary>
    /// Represents summary information for a product category,
    /// including the total product count and most expensive product.
    /// </summary>
    public class CategorySummaryDTO
    {
        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        /// <value>Category of the product.</value>
        public Enums.ProductCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the number of products in the category.
        /// </summary>
        /// <value>Count of the product</value>
        public decimal Count { get; set; }

        /// <summary>
        /// Gets or sets the most expensive product in the category.
        /// </summary>
        /// <value>Most expenseive product data</value>
        public Product MostExpensiveProduct { get; set; }
    }
}
