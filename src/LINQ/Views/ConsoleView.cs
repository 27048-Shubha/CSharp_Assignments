using ConsoleTables;
using LINQ.Models;
using LINQ.Models.DTOs;
using Spectre.Console;

namespace LINQ.Views
{
    public class ConsoleView
    {
        public void Continue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

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

                if (Enum.TryParse<Enums.TaskMenu>(Console.ReadLine(), out Enums.TaskMenu userChoice))
                {
                    return userChoice;
                }
                else
                {
                    Console.WriteLine("Kindly enter valid inputs only!");
                }
            }
        }

        public void Display(List<Product> list)
        {
            var table = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");

            foreach (var item in list)
            {
                table.AddRow(item.Id, item.Name, item.Price, item.Category);
            }

            table.Write();
        }

        public void Display(IReadOnlyList<Product> list)
        {
            var table = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Category");

            foreach (var item in list)
            {
                table.AddRow(item.Id, item.Name, item.Price, item.Category);
            }

            table.Write();
        }

        public void Display(IReadOnlyList<Supplier> list)
        {
            var table = new ConsoleTable("Supplier Id", "Supplier Name", "Product Id");

            foreach (var item in list)
            {
                table.AddRow(item.ProductId, item.SupplierName, item.SupplierId);
            }

            table.Write();
        }

        public void Display(IReadOnlyList<Order> list)
        {
            var table = new ConsoleTable("Order Id", "Order Date", "Order Status");

            foreach (var item in list)
            {
                table.AddRow(item.Id, item.OrderDate, item.Status);
            }

            table.Write();
        }

        public void Display(List<FilterProductsDTO> list)
        {
            var table = new ConsoleTable("Product Name", "Product Price");

            foreach (var item in list)
            {
                table.AddRow(item.ProductName, item.ProductPrice);
            }

            table.Write();
        }

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

        public void Display(int data)
        {
            Console.WriteLine(data);
        }

        public void Display(string message)
        {
            Console.WriteLine(message);
        }
    }
}