using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Views
{
    /// <summary>
    /// Hanldes Console Operations of Shape System
    /// </summary>
    internal class ShapeView
    {
        /// <summary>
        /// Displays StartUp Menu for Shape System
        /// </summary>
        public void DisplayShapesMenu()
        {
            Console.WriteLine("Welcome to Shape SYSTEM\n");
            Console.WriteLine("[R] to enter details of Rectangle: ");
            Console.WriteLine("[C] to enter details of Circle: ");
        }

        /// <summary>
        /// Gets Choice for Menu
        /// </summary>
        /// <returns> User's Choice </returns>
        public char GetShapeMenuInput()
        {
            return Char.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Gets Color of the Shape
        /// </summary>
        /// <returns> Color as Input from user </returns>
        public string GetShapeColor()
        {
            Console.WriteLine("Enter Color: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets Radius of the Circle
        /// </summary>
        /// <returns> Radius as Input from user </returns>
        public int GetRadius()
        {
            Console.WriteLine("Enter Radius: ");
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Gets Length of the Rectangle
        /// </summary>
        /// <returns> Length as Input from user </returns>
        public int GetLength()
        {
            Console.WriteLine("Enter Length: ");
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Gets Breadth of the Rectangle
        /// </summary>
        /// <returns> Breadth as Input from user </returns>
        public int GetBreadth()
        {
            Console.WriteLine("Enter Breadth: ");
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Displays Invalid Input Message
        /// </summary>
        public void DisplayDefault()
        {
            Console.WriteLine("Kindly Enter valid inputs only");
        }

        /// <summary>
        /// Displays Message received.
        /// </summary>
        /// <param name="message"> User Details or Error Message as string </param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
