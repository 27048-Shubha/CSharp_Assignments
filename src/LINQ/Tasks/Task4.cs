namespace LINQ.Tasks
{
    using System.Diagnostics;
    using LINQ.Helpers;
    using LINQ.Models;
    using LINQ.Views;

    /// <summary>
    /// Demonstrates product sorting using different LINQ approaches.
    /// </summary>
    public class Task4
    {
        private readonly ConsoleView _console;

        /// <summary>
        /// Initializes a new instance of the <see cref="Task4"/> class.
        /// </summary>
        /// <param name="console">Object to handle console operations.</param>
        internal Task4(ConsoleView console)
        {
            this._console = console;
        }
        /// <summary>
        /// Filters book products first, removes duplicates, and then sorts them
        /// by price in descending order using LINQ.
        /// </summary>
        /// <param name="products">The collection of products to process.</param>
        /// <returns> A list of unique book products sorted by price in descending order.</returns>
        public List<Product> FilterFirstApproach(IReadOnlyList<Product> products)
        {
            Stopwatch stopwatch = Timer.StartTimer();
            List<Product> result = products
                .Where(p => p.Category == Enums.ProductCategory.Books)
                .Distinct()
                .OrderByDescending(p => p.Price)
                .ToList();

            this._console.Display("Filter first LINQ based approach: ");
            Timer.PrintExecutionTime(stopwatch);
            return result;
        }

        /// <summary>
        /// Filters book products using a manual iteration approach and sorts them
        /// by price in descending order without using LINQ for filtering.
        /// </summary>
        /// <param name="products"> The collection of products to process. </param>
        /// <returns> A list of book products sorted by price in descending order. </returns>
        public List<Product> NoLINQApproach(IReadOnlyList<Product> products)
        {
            Stopwatch stopwatch = Timer.StartTimer();
            List<Product> books = new ();

            foreach (Product product in products)
            {
                if (product.Category == Enums.ProductCategory.Books)
                {
                    books.Add(product);
                }
            }

            books.Sort((x, y) => y.Price.CompareTo(x.Price));

            this._console.Display("No LINQ Approach: ");
            Timer.PrintExecutionTime(stopwatch);
            return books;
        }

        /// <summary>
        /// Filters book products using a manual iteration approach, then removes
        /// duplicates and sorts the resulting collection by price in descending order
        /// using LINQ.
        /// </summary>
        /// <param name="products"> The collection of products to process.</param>
        /// <returns> A list of unique book products sorted by price in descending order. </returns>
        public List<Product> ManualFilterThenQueryApproach(IReadOnlyList<Product> products)
        {
            // Manual Filter + LINQ
            Stopwatch stopwatch = Timer.StartTimer();
            List<Product> books = new ();

            foreach (Product product in products)
            {
                if (product.Category == Enums.ProductCategory.Books)
                {
                    books.Add(product);
                }
            }

            books = books.Distinct()
                .OrderByDescending(p => p.Price)
                .ToList();

            this._console.Display("Manual filter then query approach (LINQ + No LINQ): ");
            Timer.PrintExecutionTime(stopwatch);

            return books;
        }

        /// <summary>
        /// Creates a lookup based on product categories and retrieves book products,
        /// removes duplicates, and sorts them by price in descending order.
        /// </summary>
        /// <param name="products"> The collection of products used to build the lookup. </param>
        /// <returns> A list of unique book products sorted by price in descending order. </returns>
        public List<Product> LookUpBasedApproach(IReadOnlyList<Product> products)
        {
            Stopwatch stopwatch = Timer.StartTimer();

            var lookup = products.ToLookup(p => p.Category);

            List<Product> result = lookup[Enums.ProductCategory.Books]
                .Distinct()
                .OrderByDescending(p => p.Price)
                .ToList();

            this._console.Display("Lookup based approach: ");
            Timer.PrintExecutionTime(stopwatch);

            return result;
        }
    }
}
