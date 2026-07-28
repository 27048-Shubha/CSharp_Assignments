using System;
using Assignment3_InventoryManagement.Models;
namespace Assignment3_InventoryManagement.Views
{
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
            Console.WriteLine(
                "Welcome to Inventory Management System!\n"
            );
            Console.WriteLine(
                "1. Add New Product\n2.Edit a Product\n3. Delete a Product\n4. View All Products\n5.Search Product by Name"
            );
        }

        /// <summary>
        /// Gets User's choice for Menu gunctions.
        /// </summary>
        /// <returns>Input from the user.</returns>
        public int GetUserChoice()
        {
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Gets Name of the product from the user.
        /// </summary>
        /// <returns>Input from the user.</returns>
        public string GetProductName()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets Price of the product from the user.
        /// </summary>
        /// <returns>Input from the user.</returns>
        public decimal GetProductPrice()
        {
            return decimal.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Gets Product's stock quantity from user
        /// </summary>
        /// <returns>Input from the user.</returns>
        public int GetProductStock()
        {
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Displays information abouta product.
        /// </summary>
        /// <param name="products">Product list tot be displayed</param>
        public void DisplayProducts(List<Product> products)
        {
            foreach (Product item in products)
            {
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Price} - {item.StockQuantity}\n");
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
    }
}