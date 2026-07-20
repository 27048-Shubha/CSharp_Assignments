using System;

using Assignment2.Task1;

namespace Assignment2
{
    /// <summary>
    /// Start of the Execution
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function where the execution begins
        /// </summary>
        /// <param name="args">Command Line Arguments</param>
        public static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle();
            Circle circle = new Circle();

            Console.WriteLine("Enter Color of Rectangle:");
            rectangle.Color = Console.ReadLine();

            Console.WriteLine("Enter Length of Rectangle:");
            rectangle.Length = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Breadth of Rectangle:");
            rectangle.Breadth = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Color of Circle:");
            circle.Color = Console.ReadLine();

            Console.WriteLine("Enter Radius of Circle:");
            circle.Radius = double.Parse(Console.ReadLine());

            rectangle.Area = rectangle.CalculateArea();
            circle.Area = circle.CalculateArea();

            rectangle.PrintDetails();
            circle.PrintDetails();
        }
    }
}