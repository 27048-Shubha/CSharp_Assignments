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
        /// Displays menu for inventory system.
        /// </summary>
        public void DisplayMenu()
        {
            this.DisplaySeparator();
            SetColor(ConsoleColor.Cyan);
            Console.WriteLine("Welcome To Inventory Management System\n");
            Console.WriteLine("Enter:\n");
            Console.WriteLine("1. Add new product\n" +
                "2. Edit a product\n" +
                "3. Delete a product\n" +
                "4. View all products\n" +
                "5. Search product by name\n" +
                "6. Sort products\n" +
                "7. Exit application");
            this.DisplaySeparator();
        }

        /// <summary>
        /// Displays menu for inventory system.
        /// </summary>
        public void DisplaySortMenu()
        {
            this.DisplaySeparator();
            SetColor(ConsoleColor.Cyan);
            Console.WriteLine("Enter: ");
            Console.WriteLine("1. Sort by name\n" +
                "2. Sort by price\n" +
                "3. Sort by stock quantity\n" +
                "4. Back to main menu");
            this.DisplaySeparator();
        }

        /// <summary>
        /// Gets user's choice for menu functions.
        /// </summary>
        /// <returns>True if user enters valid integer else False.</returns>
        public int GetUserChoice()
        {
            SetColor(ConsoleColor.DarkCyan);
            while (true)
            {
                string value = Console.ReadLine() ?? string.Empty;
                if (!TypeValidator.IsValidInt(value, out int choice))
                {
                    this.DisplayInvalidChoice();
                }
                else
                {
                    return choice;
                }
            }
        }

        /// <summary>
        /// Get value of name of the products.
        /// </summary>
        /// <param name="name">Reference to stock of the products.</param>
        public void GetProductName(out string name)
        {
            SetColor(ConsoleColor.DarkCyan);
            this.DisplayInputPrompt("name");
            name = Console.ReadLine() ?? "Unnamed Product";
        }

        /// <summary>
        /// Get value of price of the products.
        /// </summary>
        /// <param name="editMode">True if is in edit mode, else false.</param>
        /// <param name="price">Reference to price of the products.</param>
        /// <returns>True if price value entered is valid else false.</returns>
        public bool GetProductPrice(bool editMode, out decimal price)
        {
            SetColor(ConsoleColor.DarkCyan);
            this.DisplayInputPrompt("price");
            string? value = Console.ReadLine();
            if (!TypeValidator.IsValidDecimal(value, out price))
            {
                if (!editMode)
                {
                    this.DisplayMessage("Invalid Input! Price must be a positive value.");
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// Get value of stock of the products.
        /// </summary>
        /// <param name="editMode">True if is in edit mode, else false.</param>
        /// <param name="stock">Reference to stock of the products.</param>
        /// <returns>True if stock value is valid else False.</returns>
        public bool GetProductStock(bool editMode, out decimal stock)
        {
            SetColor(ConsoleColor.DarkCyan);
            this.DisplayInputPrompt("stock");
            string? value = Console.ReadLine();
            if (!TypeValidator.IsValidDecimal(value, out stock))
            {
                if (!editMode)
                {
                    this.DisplayMessage("Invalid Input! Stock must be an non negative value.");
                }

                return false;
            }

            return true;
        }

        /// <summary>
        /// Displays information about products.
        /// </summary>
        /// <param name="products">Product list tot be displayed.</param>
        public void DisplayProducts(IList<Product> products)
        {
            SetColor(ConsoleColor.Yellow);
            if (products.Count == 0)
            {
                this.DisplayEmpty();
                return;
            }

            this.DisplayMessage("Current inventory:");

            var table = new ConsoleTable("ID", "NAME", "PRICE", "STOCK QUANTITY");
            foreach (Product product in products)
            {
                table.AddRow(product.Id.ToString()[..6], product.Name, product.Price, product.StockQuantity);
            }

            table.Write();
        }

        /// <summary>
        /// Displays invalid input warning.
        /// </summary>
        public void DisplayDefault()
        {
            SetColor(ConsoleColor.Red);
            Console.WriteLine("Kindly enter valid inputs only!");
        }

        /// <summary>
        /// Displays choice invalid message.
        /// </summary>
        public void DisplayInvalidChoice()
        {
            SetColor(ConsoleColor.Red);
            Console.WriteLine("Invalid choice!");
        }

        /// <summary>
        /// Displays choice invalid message.
        /// </summary>
        /// <param name="message">Input variable name to be entered.</param>
        public void DisplayInputPrompt(string message)
        {
            SetColor(ConsoleColor.Cyan);
            Console.WriteLine($"Enter {message}: ");
        }

        /// <summary>
        /// Displays messages to the console..
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public void DisplayMessage(string message)
        {
            SetColor(ConsoleColor.Yellow);
            Console.WriteLine($"{message}");
        }

        /// <summary>
        /// Displays messages to skip editing values.
        /// </summary>
        public void DisplaySkipMessage()
        {
            SetColor(ConsoleColor.Yellow);
            Console.WriteLine($"Click enter to skip editing values");
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
            Console.WriteLine("Thank you for using Inventory Management System");
            SetColor(ConsoleColor.White);
        }

        /// <summary>
        /// Pauses the console by prompting user to enter key.
        /// </summary>
        public void PauseAndClear()
        {
            this.DisplayInputPrompt("\nPress any key to continue...");
            Console.ReadKey(intercept: true);
            Console.Clear();
        }

        private static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        private void DisplaySeparator()
        {
            SetColor(ConsoleColor.Yellow);
            Console.WriteLine("------------------------------------");
        }
    }
}