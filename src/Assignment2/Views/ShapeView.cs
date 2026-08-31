namespace Assignment2.Views
{
    using Assignment2.Validators;
    using System.Drawing;

    /// <summary>
    /// Handles console operations of shape system.
    /// </summary>
    public class ShapeView : MainView
    {
        /// <summary>
        /// Displays start up menu for shape system.
        /// </summary>
        public void DisplayShapesMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            this.DisplayLineBreaker();
            Console.WriteLine("Welcome to shape system\n");
            Console.WriteLine("[R] to enter details of rectangle: ");
            Console.WriteLine("[C] to enter details of circle: ");
            Console.WriteLine("[B] to back to main menu: ");
            this.DisplayLineBreaker();
            Console.ResetColor();
        }

        /// <summary>
        /// Gets color of the shape.
        /// </summary>
        /// <returns> The color as input from user. </returns>
        public string GetShapeColor()
        {
            string color;
            while (true)
            {
                Console.WriteLine("Enter color: ");
                color = Console.ReadLine() ?? string.Empty;
                if (Validator.IsValidAlphabeticInput(color))
                {
                    return color;
                }
                else
                {
                    Console.WriteLine("Invalid input for color! No numbers or special characters allowed");
                }
            }

            return color;
        }

        /// <summary>
        /// Gets radius of the circle.
        /// </summary>
        /// <returns> The radius as input from user. </returns>
        public double GetRadius()
        {
            while (true)
            {
                Console.WriteLine("Enter radius: ");
                if (Validator.IsValidDouble(Console.ReadLine(), out double radius))
                {
                    return radius;
                }
                else
                {
                    Console.WriteLine("Invalid input! Length must be valid numbers!");
                }
            }
        }

        /// <summary>
        /// Gets length of the rectangle.
        /// </summary>
        /// <returns> The length as input from user. </returns>
        public double GetLength()
        {
            while (true)
            {
                Console.WriteLine("Enter length: ");
                if (Validator.IsValidDouble(Console.ReadLine(), out double length))
                {
                    return length;
                }
                else
                {
                    Console.WriteLine("Invalid input! Length must be a valid number!");
                }
            }
        }

        /// <summary>
        /// Gets breadth of the rectangle.
        /// </summary>
        /// <returns> The breadth as input from user. </returns>
        public double GetBreadth()
        {
            while (true)
            {
                Console.WriteLine("Enter breadth: ");
                if (Validator.IsValidDouble(Console.ReadLine(), out double breadth))
                {
                    return breadth;
                }
                else
                {
                    Console.WriteLine("Invalid input! Breadth must be a valid number!");
                }
            }
        }

        /// <summary>
        /// Displays message received from the user.
        /// </summary>
        /// <param name="message"> The message received from the user. </param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}