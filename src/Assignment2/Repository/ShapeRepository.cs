namespace Assignment2.Repository
{
    using Assignment2.Models.Task1;

    /// <summary>
    /// Handles repository operations of the shape hierarchy application.
    /// </summary>
    public class ShapeRepository
    {
        /// <summary>
        /// Intantiates and initializes object values of rectangle.
        /// </summary>
        /// <param name="color">The _color of the rectangle. </param>
        /// <param name="length">The _length of the rectangle. </param>
        /// <param name="breadth">The _breadth of the rectangle. </param>
        /// <returns>The details of rectangle created. </returns>
        public string AddRectangle(string color, double length, double breadth)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Color = color;
            rectangle.Length = length;
            rectangle.Breadth = breadth;
            rectangle.Area = rectangle.CalculateArea();
            return rectangle.PrintDetails();
        }

        /// <summary>
        /// Intantiates and initializes object values of circle.
        /// </summary>
        /// <param name="color">The _color of the circle. </param>
        /// <param name="radius">The _radius of the circle. </param>
        /// <returns>The details of circle created. </returns>
        public string AddCircle(string color, double radius)
        {
            Circle circle = new Circle();
            circle.Color = color;
            circle.Radius = radius;
            circle.Area = circle.CalculateArea();
            return circle.PrintDetails();
        }
    }
}