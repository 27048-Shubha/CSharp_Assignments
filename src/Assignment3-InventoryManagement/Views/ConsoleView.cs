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
            ConsoleColorManager.SetColor(ConsoleColor.Yellow);
            Console.WriteLine("------------------------------------");
        }

        /// <summary>
        /// Displays Menu for Inventory System.
        /// </summary>
        public void DisplayMenu()
        {
            this.DisplayDash();
            ConsoleColorManager.SetColor(ConsoleColor.Cyan);
            Console.WriteLine("Welcome To Inventory Management System!\n");
            Console.WriteLine("1. Add New Product\n2. Edit A Product\n3. Delete A Product\n4. View All Products\n5. Search Product By Name\n6. Exit");
            this.DisplayDash();
        }

        /// <summary>
        /// Displays Menu for Inventory System.
        /// </summary>
        public void DisplaySortMenu()
        {
            this.DisplayDash();
            ConsoleColorManager.SetColor(ConsoleColor.Cyan);
            Console.WriteLine("Enter: \n");
            Console.WriteLine("1.Sort By Name\n2. Sort By Price\n3. Sort By Stock Quanitty\n4. View All Products\n5. Search Product By Name\n6. Exit");
            this.DisplayDash();
        }

        /// <summary>
        /// Gets User's choice for Menu gunctions.
        /// </summary>
        /// <param name="choice">Choice entered by the user.</param>
        /// <returns>True if user enters valid integer else False.</returns>
        public bool GetUserChoice(out int choice)
        {
            ConsoleColorManager.SetColor(ConsoleColor.DarkCyan);
            string value = Console.ReadLine() ?? string.Empty;
            if (!TypeValidation.IsValidInt(value, out choice))
            {
                this.DisplayInvalidChoice();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get value of name of the product.
        /// </summary>
        /// <param name="name">Reference to stock of the product.</param>
        public void GetProductName(out string name)
        {
            ConsoleColorManager.SetColor(ConsoleColor.DarkCyan);
            this.Display("name");
            name = Console.ReadLine() ?? "Unnamed Product";
        }

        /// <summary>
        /// Get value of price of the product.
        /// </summary>
        /// <param name="price">Reference to price of the product.</param>
        /// <returns>True if price value entered is valid else False.</returns>
        public bool GetProductPrice(out decimal price)
        {
            ConsoleColorManager.SetColor(ConsoleColor.DarkCyan);
            this.Display("price");
            string? value = Console.ReadLine();
            if (!TypeValidation.IsValidDecimal(value, out price))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get value of stock of the product.
        /// </summary>
        /// <param name="stock">Reference to stock of the product.</param>
        /// <returns>True if Stock value is valid else False.</returns>
        public bool GetProductStock(out decimal stock)
        {
            ConsoleColorManager.SetColor(ConsoleColor.DarkCyan);
            this.Display("stock");
            string? value = Console.ReadLine();
            if (!TypeValidation.IsValidDecimal(value, out stock))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Displays information abouta product.
        /// </summary>
        /// <param name="products">Product list tot be displayed.</param>
        public void DisplayProducts(List<Product> products)
        {
            ConsoleColorManager.SetColor(ConsoleColor.Yellow);
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
            ConsoleColorManager.SetColor(ConsoleColor.Red);
            Console.WriteLine("Kindly Enter Valid Inputs Only!");
        }

        /// <summary>
        /// Displays choice invalid message.
        /// </summary>
        public void DisplayInvalidChoice()
        {
            ConsoleColorManager.SetColor(ConsoleColor.Red);
            Console.WriteLine("Invalid Choice!");
        }

        /// <summary>
        /// Displays choice invalid message.
        /// </summary>
        /// <param name="message">Input variable name to be entered.</param>
        public void Display(string message)
        {
            ConsoleColorManager.SetColor(ConsoleColor.Blue);
            Console.WriteLine($"Enter {message}: ");
        }

        /// <summary>
        /// Displays Messages to the console..
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public void DisplayMessage(string message)
        {
            ConsoleColorManager.SetColor(ConsoleColor.Yellow);
            Console.WriteLine($"{message}");
        }

        /// <summary>
        /// Displays invalid input message to the console.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public void DisplayInvalidInput(string? message)
        {
            ConsoleColorManager.SetColor(ConsoleColor.Yellow);
            Console.WriteLine($"{message}");
        }

        /// <summary>
        /// Displays success message for CRUD operations.
        /// </summary>
        /// <param name="operation">Succeeded operation.</param>
        public void DisplaySuccess(string operation)
        {
            ConsoleColorManager.SetColor(ConsoleColor.Green);
            Console.WriteLine($"{operation} Successful!");
        }

        /// <summary>
        /// Displays inventory empty warning.
        /// </summary>
        public void DisplayEmpty()
        {
            ConsoleColorManager.SetColor(ConsoleColor.Yellow);
            Console.WriteLine("Inventory Is Empty!");
        }

        /// <summary>
        /// Displays exit message.
        /// </summary>
        public void DiplayExitMessage()
        {
            ConsoleColorManager.SetColor(ConsoleColor.DarkCyan);
            Console.WriteLine("Thank You For Using Inventory Management System!");
        }

        /// <summary>
        /// Clears console.
        /// </summary>
        public void ClearConsole()
        {
            Thread.Sleep(1000);
            Console.Clear();
        }
    }
}