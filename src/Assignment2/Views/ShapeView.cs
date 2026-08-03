namespace Assignment2.Views
{
    /// <summary>
    /// Hanldes console operations of shape system.
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
            Console.WriteLine("[Q] to quit: ");
            this.DisplayLineBreaker();
            Console.ResetColor();
        }

        /// <summary>
        /// Gets color of the shape.
        /// </summary>
        /// <returns> The color as input from user. </returns>
        public string GetShapeColor()
        {
            Console.WriteLine("Enter Color: ");
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Gets radius of the circle.
        /// </summary>
        /// <returns> The radius as input from user. </returns>
        public string GetRadius()
        {
            Console.WriteLine("Enter Radius: ");
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Gets length of the rectangle.
        /// </summary>
        /// <returns> The length as input from user. </returns>
        public string GetLength()
        {
            Console.WriteLine("Enter Length: ");
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Gets breadth of the rectangle.
        /// </summary>
        /// <returns> The breadth as input from user. </returns>
        public string GetBreadth()
        {
            Console.WriteLine("Enter Breadth: ");
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