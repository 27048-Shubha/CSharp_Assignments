namespace Assignment3_InventoryManagement.Views
{
    using Assignment3_InventoryManagement.Helper;
    using Assignment3_InventoryManagement.Models;
    using ConsoleTables;

    /// <summary>
    /// Manages console operations of inventory system.
    /// </summary>
    public class ConsoleView
    {
        /// <summary>
        /// Displays Dash.
        /// </summary>
        public void DisplayDash()
        {
            SetColor(ConsoleColor.Yellow);
            Console.WriteLine("------------------------------------");
        }

        /// <summary>
        /// Displays Menu for Inventory System.
        /// </summary>
        public void DisplayMenu()
        {
            this.DisplayDash();
            SetColor(ConsoleColor.Cyan);
            Console.WriteLine("Welcome To Inventory Management System!\n");
            Console.WriteLine("1. Add new product\n" +
                "2. Edit a product\n" +
                "3. Delete a product\n" +
                "4. View all products\n" +
                "5. Search product by name\n");
            this.DisplayDash();
        }

        /// <summary>
        /// Displays Menu for Inventory System.
        /// </summary>
        public void DisplaySortMenu()
        {
            this.DisplayDash();
            SetColor(ConsoleColor.Cyan);
            Console.WriteLine("Enter: ");
            Console.WriteLine("1.Sort By Name\n2. Sort By Price\n3. Sort By Stock Quanitty\n4. View All Products\n5. Search Product By Name\n6. Exit");
            this.DisplayDash();
        }

        /// <summary>
        /// Gets User's _choice for Menu gunctions.
        /// </summary>
        /// <param name="choice">Choice entered by the user.</param>
        /// <returns>True if user enters valid integer else False.</returns>
        public bool GetUserChoice(out int choice)
        {
            SetColor(ConsoleColor.DarkCyan);
            string value = Console.ReadLine() ?? string.Empty;
            if (!TypeValidator.IsValidInt(value, out choice))
            {
                this.DisplayInvalidChoice();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get value of name of the _products.
        /// </summary>
        /// <param name="name">Reference to stock of the _products.</param>
        public void GetProductName(out string name)
        {
            SetColor(ConsoleColor.DarkCyan);
            this.Display("name");
            name = Console.ReadLine() ?? "Unnamed Product";
        }

        /// <summary>
        /// Get value of price of the _products.
        /// </summary>
        /// <param name="price">Reference to price of the _products.</param>
        /// <returns>True if price value entered is valid else False.</returns>
        public bool GetProductPrice(out decimal price)
        {
            SetColor(ConsoleColor.DarkCyan);
            this.Display("price");
            string? value = Console.ReadLine();
            if (!TypeValidator.IsValidDecimal(value, out price))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get value of stock of the _products.
        /// </summary>
        /// <param name="stock">Reference to stock of the _products.</param>
        /// <returns>True if Stock value is valid else False.</returns>
        public bool GetProductStock(out decimal stock)
        {
            SetColor(ConsoleColor.DarkCyan);
            this.Display("stock");
            string? value = Console.ReadLine();
            if (!TypeValidator.IsValidDecimal(value, out stock))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Displays information abouta _products.
        /// </summary>
        /// <param name="products">Product list tot be displayed.</param>
        public void DisplayProducts(List<Product> products)
        {
            SetColor(ConsoleColor.Yellow);
            if (products.Count == 0)
            {
                this.DisplayEmpty();
                return;
            }

            var table = new ConsoleTable("ID", "NAME", "PRICE", "STOCK QUANTITY");
            foreach (Product product in products)
            {
                table.AddRow(product.Id.ToString()[..6], product.Name, product.Price, product.StockQuantity);
            }

            table.Write();
        }

        /// <summary>
        /// Displays Invalid Input warning.
        /// </summary>
        public void DisplayDefault()
        {
            SetColor(ConsoleColor.Red);
            Console.WriteLine("Kindly enter valid inputs only!");
        }

        /// <summary>
        /// Displays _choice invalid message.
        /// </summary>
        public void DisplayInvalidChoice()
        {
            SetColor(ConsoleColor.Red);
            Console.WriteLine("Invalid choice!");
        }

        /// <summary>
        /// Displays _choice invalid message.
        /// </summary>
        /// <param name="message">Input variable name to be entered.</param>
        public void Display(string message)
        {
            SetColor(ConsoleColor.Cyan);
            Console.WriteLine($"Enter {message}: ");
        }

        /// <summary>
        /// Displays Messages to the console..
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public void DisplayMessage(string message)
        {
            SetColor(ConsoleColor.Yellow);
            Console.WriteLine($"{message}");
        }

        /// <summary>
        /// Displays invalid input message to the console.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public void DisplayInvalidInput(string? message)
        {
            SetColor(ConsoleColor.Yellow);
            Console.WriteLine($"{message}");
        }

        /// <summary>
        /// Displays success message for CRUD operations.
        /// </summary>
        /// <param name="operation">Succeeded operation.</param>
        public void DisplaySuccess(string operation)
        {
            SetColor(ConsoleColor.Green);
            Console.WriteLine($"{operation} successful!");
        }

        /// <summary>
        /// Displays inventory empty warning.
        /// </summary>
        public void DisplayEmpty()
        {
            SetColor(ConsoleColor.Yellow);
            Console.WriteLine("Inventory is empty!");
        }

        /// <summary>
        /// Displays exit message.
        /// </summary>
        public void DiplayExitMessage()
        {
            SetColor(ConsoleColor.DarkCyan);
            Console.WriteLine("Thank you for using Inventory Management System!");
        }

        /// <summary>
        /// Clears console.
        /// </summary>
        public void ClearConsole()
        {
            Thread.Sleep(1000);
            Console.Clear();
        }

        /// <summary>
        /// Sets color to the console.
        /// </summary
        /// <param name="color">Color to be set.</param>
        private static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
    }
}