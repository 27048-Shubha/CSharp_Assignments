using ConsoleTables;
using LINQ.Enums;
using LINQ.Models;
using LINQ.Models.DTOs;

namespace LINQ.Views
{
    /// <summary>
    /// Manages console operations of the application.
    /// </summary>
    public class ConsoleView
    {
        /// <summary>
        /// Displays a message and waits for the user to press a key before clearing the console.
        /// </summary>
        public void Continue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Prompts the user to select a task from the menu and returns the selected option.
        /// </summary>
        /// <returns>The selected task menu option.</returns>
        public Enums.TaskMenu GetUserChoice()
        {
            while (true)
            {
                Console.WriteLine("Enter\n" +
                    "1. View task 1\n" +
                    "2. View task 2\n" +
                    "3. View task 3\n" +
                    "4. View task 4\n" +
                    "5. View task 5\n");

                if (Enum.TryParse<TaskMenu>(Console.ReadLine(), out TaskMenu userChoice))
                {
                    return userChoice;
                }
                else
                {
                    Console.WriteLine("Kindly enter valid inputs only!");
                }
            }
        }

        /// <summary>
        /// Displays a array of elements.=
        /// </summary>
        /// <param name="array">The array of integers to display.</param>
        public void Display(int[] array)
        {
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Displays a collection of products in a console table.
        /// </summary>
        /// <param name="list">The list of products to display.</param>
        public void Display(List<Product> list)
        {
            var table = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");

            foreach (var item in list)
            {
                table.AddRow(item.Id, item.Name, item.Price, item.Category);
            }

            table.Write();
        }

        /// <summary>
        /// Displays a read-only collection of products in a console table.
        /// </summary>
        /// <param name="list">The read-only list of products to display</param>
        public void Display(IReadOnlyList<Product> list)
        {
            var table = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");

            foreach (var item in list)
            {
                table.AddRow(item.Id, item.Name, item.Price, item.Category);
            }

            table.Write();
        }

        /// <summary>
        /// Displays a read-only collection of suppliers in a console table.
        /// </summary>
        /// <param name="list">The read-only list of suppliers to display.</param>
        public void Display(IReadOnlyList<Supplier> list)
        {
            var table = new ConsoleTable("Supplier Id", "Supplier Name", "Product Id");

            foreach (var item in list)
            {
                table.AddRow(item.ProductId, item.SupplierName, item.SupplierId);
            }

            table.Write();
        }

        /// <summary>
        /// Displays a read-only collection of orders in a console table.
        /// </summary>
        /// <param name="list">The read-only list of orders to display.</param>
        public void Display(IReadOnlyList<Order> list)
        {
            var table = new ConsoleTable("Order Id", "Order Date", "Order Status");

            foreach (var item in list)
            {
                table.AddRow(item.Id, item.OrderDate, item.Status);
            }

            table.Write();
        }

        /// <summary>
        /// Displays filtered product information in a console table.
        /// </summary>
        /// <param name="list">The filtered product details to display.</param>
        public void Display(List<FilterProductsDTO> list)
        {
            var table = new ConsoleTable("Product Name", "Product Price");

            foreach (var item in list)
            {
                table.AddRow(item.ProductName, item.ProductPrice);
            }

            table.Write();
        }

        /// <summary>
        /// Displays category summary information in a console table.
        /// </summary>
        /// <param name="list">The category summary details to display.</param>
        public void Display(List<CategorySummaryDTO> list)
        {
            var table = new ConsoleTable(
                "Category",
                "Count",
                "Most Expensive Product",
                "Price");

            foreach (var item in list)
            {
                table.AddRow(
                    item.Category,
                    item.Count,
                    item.MostExpensiveProduct.Name,
                    item.MostExpensiveProduct.Price);
            }

            table.Write();
        }

        /// <summary>
        /// Displays product and supplier information in a console table.
        /// </summary>
        /// <param name="list">The product supplier information to display.</param>
        public void Display(List<ProductSupplierInfoDTO> list)
        {
            var table = new ConsoleTable(
                "Product Id",
                "Product Name",
                "Price",
                "Category",
                "Supplier Id",
                "Supplier Name");

            foreach (var item in list)
            {
                table.AddRow(
                    item.ProductId,
                    item.ProductName,
                    item.ProductPrice,
                    item.ProductCategory,
                    item.SupplierId,
                    item.SupplierName);
            }

            table.Write();
        }

        /// <summary>
        /// Displays unique number pairs in a console table.
        /// </summary>
        /// <param name="list">The collection of pairs to display.</param>
        public void Display(List<PairDTO> list)
        {
            var table = new ConsoleTable(
                "Value 1",
                "Value 2");

            foreach (var item in list)
            {
                table.AddRow(
                    item.Value1,
                    item.Value2);
            }

            table.Write();
        }

        /// <summary>
        /// Displays a collection of suppliers in a console table.
        /// </summary>
        /// <param name="list">The suppliers to display.</param>
        public void Display(List<Supplier> list)
        {
            var table = new ConsoleTable(
                "Supplier Id",
                "Supplier Name",
                "Product Id");

            foreach (var item in list)
            {
                table.AddRow(
                    item.SupplierId,
                    item.SupplierName,
                    item.ProductId);
            }

            table.Write();
        }

        /// <summary>
        /// Displays a collection of orders in a console table.
        /// </summary>
        /// <param name="list">The orders to display.</param>
        public void Display(List<Order> list)
        {
            var table = new ConsoleTable(
                "Id",
                "Order Date",
                "Status");

            foreach (var item in list)
            {
                table.AddRow(
                    item.Id,
                    item.OrderDate,
                    item.Status);
            }

            table.Write();
        }

        /// <summary>
        /// Displays an integer value in the console.
        /// </summary>
        /// <param name="data">The integer value to display.</param>
        public void Display(int data)
        {
            Console.WriteLine(data);
        }

        /// <summary>
        /// Displays a message in the console.
        /// </summary>
        /// <param name="message">The message to display.</param>
        public void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}