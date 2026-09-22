using Models;

namespace Assignment16_AdvancedCSharp.Tasks
{
    /// <summary>
    /// Demonstrates task5 with delegates
    /// </summary>
    internal class Task5_DelegatesForSorting
    {
        private delegate int SortDelegate(Product product1, Product product2);

        /// <summary>
        /// Entry point of task 5 demonstration.
        /// </summary>
        public void Run()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("Shoe", "Footwear", 1000));
            products.Add(new Product("Watch", "Accessories", 1500));
            products.Add(new Product("Pen", "Stationery", 100));

            Console.WriteLine("Sort by Name: ");
            this.SortAndDisplay(this.SortByName, products);

            Console.WriteLine("\nSort by Category: ");
            this.SortAndDisplay(this.SortByCategory, products);

            Console.WriteLine("\nSort by Price: ");
            this.SortAndDisplay(this.SortByPrice, products);
        }

        private int SortByName(Product product1, Product product2)
        {
            return product1.Name.CompareTo(product2.Name);
        }

        private int SortByCategory(Product product1, Product product2)
        {
            return product1.Category.CompareTo(product2.Category);
        }

        private int SortByPrice(Product product1, Product product2)
        {
            return product1.Price.CompareTo(product2.Price);
        }

        private List<Product> SortAndDisplay(SortDelegate sortDelegate, List<Product> productList)
        {
            for (int i = 0; i < productList.Count; i++)
            {
                for (int j = i; j < productList.Count; j++)
                {
                    if (sortDelegate(productList[i], productList[j]) > 0)
                    {
                        Product temp = productList[i];
                        productList[i] = productList[j];
                        productList[j] = temp;
                    }
                }
            }

            Console.WriteLine($"Name - Category - Price");

            foreach (Product product in productList)
            {
                Console.WriteLine($"{product.Name} - {product.Category} - {product.Price}");
            }

            return productList;
        }
    }
}
