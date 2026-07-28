namespace Assignment3_InventoryManagement.Views
{
    using Assignment3_InventoryManagement.Helper;
    using Assignment3_InventoryManagement.Models;

    /// <summary>
    /// Manages console operations of inventory system
    /// </summary>
    public class ConsoleView
    {
        /// <summary>
        /// Displays Menu for Inventory System
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to Inventory Management System!\n");

            Console.WriteLine("1. Add New Product\n2. Edit a Product\n3. Delete a Product\n4. View All Products\n5. Search Product by Name");
        }

        /// <summary>
        /// Gets User's choice for Menu gunctions.
        /// </summary>
        /// <param name="choice">Choice entered by the user.</param>
        /// <returns>True if user enters valid integer else False</returns>
        public bool GetUserChoice(out int choice)
        {
            string value = Console.ReadLine();
            if (!TypeValidation.IsValidInt(value, out choice))
            {
                this.DisplayInvalidChoice();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Get value of name of the product
        /// </summary>
        /// <param name="name">Reference to stock of the product</param>
        public void GetProductName(out string name)
        {
            this.Display("name");
            name = Console.ReadLine();
        }

        /// <summary>
        /// Get value of price of the product
        /// </summary>
        /// <param name="price">Reference to price of the product</param>
        /// <returns>True if price value entered is valid else False</returns>
        public bool GetProductPrice(out decimal price)
        {
            this.Display("price");
            string value = Console.ReadLine();
            if (!TypeValidation.IsValidDecimal(value, out price))
            {
                this.DisplayInvalidPrice();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get value of stock of the product
        /// </summary>
        /// <param name="stock">Reference to stock of the product</param>
        /// <returns>True if Stock value is valid else False</returns>
        public bool GetProductStock(out int stock)
        {
            this.Display("stock");
            string value = Console.ReadLine();
            if (!TypeValidation.IsValidInt(value, out stock))
            {
                this.DisplayInvalidStock();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Displays information abouta product.
        /// </summary>
        /// <param name="products">Product list tot be displayed</param>
        public void DisplayProducts(List<Product> products)
        {
            if(products == null)
            {
                this.DisplayEmpty();
            }
            else
            {
                foreach (Product item in products)
                {
                    Console.WriteLine($"{item.Id} - {item.Name} - {item.Price} - {item.StockQuantity}\n");
                }
            }
        }

        /// <summary>
        /// Displays Invalid Input warning.
        /// </summary>
        public void DisplayDefault()
        {
            Console.WriteLine(
                "Kindly Enter Valid Inputs Only!"
            );
        }

        /// <summary>
        /// Displays name not found message
        /// </summary>
        /// <param name="name">User input name to be searchewd</param>
        public void DisplayNameNotFound(string name)
        {
            Console.WriteLine($"The product {name} is not found in the inventory!");
        }

        /// <summary>
        /// Displays price invalid message.
        /// </summary>
        public void DisplayInvalidPrice()
        {
            Console.WriteLine("Invalid price entered! Price must be a positive decimal!");
        }

        /// <summary>
        /// Displays stock invalid message.
        /// </summary>
        public void DisplayInvalidStock()
        {
            Console.WriteLine("Invalid stock quantity entered! Stock Quantity must be an integer!");
        }

        /// <summary>
        /// Displays choice invalid message.
        /// </summary>
        public void DisplayInvalidChoice()
        {
            Console.WriteLine("Invalid Choice!");
        }

        /// <summary>
        /// Displays choice invalid message.
        /// </summary>
        /// <param name="message">Input variable name to be entered</param>
        public void Display(string message)
        {
            Console.WriteLine($"Enter {message}: ");
        }

        /// <summary>
        /// Displays Messages to the console
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine($"{message}: ");
        }

        /// <summary>
        /// Displays success message for CRUD operations
        /// </summary>
        /// <param name="operation">Succeeded operation</param>
        public void DisplaySuccess(string operation)
        {
            Console.WriteLine($"{operation} successful!");
        }

        /// <summary>
        /// Displays inventory empty warning
        /// </summary>
        public void DisplayEmpty()
        {
            Console.WriteLine("Inventory is empty!");
        }
    }
}