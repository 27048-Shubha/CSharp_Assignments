namespace Assignment2.Views
{
    /// <summary>
    /// Hanldes _console operations of shape system.
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
        /// Gets _color of the shape.
        /// </summary>
        /// <returns> The _color as input from user. </returns>
        public string GetShapeColor()
        {
            Console.WriteLine("Enter color: ");
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Gets _radius of the circle.
        /// </summary>
        /// <returns> The _radius as input from user. </returns>
        public string GetRadius()
        {
            Console.WriteLine("Enter radius: ");
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Gets _length of the rectangle.
        /// </summary>
        /// <returns> The _length as input from user. </returns>
        public string GetLength()
        {
            Console.WriteLine("Enter length: ");
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Gets _breadth of the rectangle.
        /// </summary>
        /// <returns> The _breadth as input from user. </returns>
        public string GetBreadth()
        {
            Console.WriteLine("Enter breadth: ");
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Displays message received from the user.
        /// </summary>
        /// <param name="message"> The message received from the user. </param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}