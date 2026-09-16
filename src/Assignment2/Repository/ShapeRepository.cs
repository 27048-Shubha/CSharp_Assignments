namespace Assignment2.Repository
{
    using Assignment2.Models;

    /// <summary>
    /// Handles repository operations of the shape hierarchy application.
    /// </summary>
    public class ShapeRepository
    {
        /// <summary>
        /// Intantiates and initializes object values of rectangle.
        /// </summary>
        /// <param name="color">The color of the rectangle. </param>
        /// <param name="length">The length of the rectangle. </param>
        /// <param name="breadth">The breadth of the rectangle. </param>
        /// <returns>The details of rectangle created. </returns>
        public string AddRectangle(string color, double length, double breadth)
        {
            Rectangle rectangle = new Rectangle(color, length, breadth);
            return rectangle.PrintDetails();
        }

        /// <summary>
        /// Intantiates and initializes object values of circle.
        /// </summary>
        /// <param name="color">The color of the circle. </param>
        /// <param name="radius">The radius of the circle. </param>
        /// <returns>The details of circle created. </returns>
        public string AddCircle(string color, double radius)
        {
            Circle circle = new Circle(color, radius);
            return circle.PrintDetails();
        }
    }
}