namespace Assignment16_AdvancedCSharp.Tasks
{
    using Assignment16_AdvancedCSharp.Models;

    /// <summary>
    /// Demonstrates task5 with delegates
    /// </summary>
    public class Task5DelegatesForSorting
    {
        private delegate int SortDelegate(Product first, Product second);

        /// <summary>
        /// Entry point of task 5 demonstration.
        /// </summary>
        public void Run()
        {
            List<Product> products = new List<Product>()
            {
                new Product("Shoe", "Footwear", 1000),
                new Product("Watch", "Accessories", 1500),
                new Product("Pen", "Stationery", 100),
            };

            Console.WriteLine("Sort by Name: ");
            SortDelegate sortByName = new SortDelegate(SortByName);
            this.SortAndDisplay(SortByName, products);

            Console.WriteLine("\nSort by Category: ");
            SortDelegate sortByCategory = new SortDelegate(SortByCategory);
            this.SortAndDisplay(sortByCategory, products);

            Console.WriteLine("\nSort by Price: ");
            SortDelegate sortByPrice = new SortDelegate(SortByPrice);
            this.SortAndDisplay(sortByPrice, products);
        }

        private static int SortByName(Product first, Product second)
        {
            return string.Compare(
                first.Name,
                second.Name,
                StringComparison.OrdinalIgnoreCase);
        }

        private static int SortByCategory(Product first, Product second)
        {
            return string.Compare(
                first.Category,
                second.Category,
                StringComparison.OrdinalIgnoreCase);
        }

        private static int SortByPrice(Product first, Product second)
        {
            return first.Price.CompareTo(second.Price);
        }

        private void SortAndDisplay(SortDelegate sortDelegate, IReadOnlyList<Product> productList)
        {
            List<Product> sortedProducts = new (productList);

            for (int i = 0; i < sortedProducts.Count; i++)
            {
                for (int j = i; j < sortedProducts.Count; j++)
                {
                    if (sortDelegate(sortedProducts[i], sortedProducts[j]) > 0)
                    {
                        Product temp = sortedProducts[i];
                        sortedProducts[i] = sortedProducts[j];
                        sortedProducts[j] = temp;
                    }
                }
            }

            Console.WriteLine($"{"Name",-12} {"Category",-15} {"Price",10}");

            foreach (Product product in sortedProducts)
            {
                Console.WriteLine(
                    $"{product.Name,-12} {product.Category,-15} {product.Price,10:N2}");
            }
        }
    }
}
