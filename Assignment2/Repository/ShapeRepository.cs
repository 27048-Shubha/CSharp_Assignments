using Assignment2.Models.Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Repository
{
    /// <summary>
    /// Handles Object Creation of Rectangle and Circle class
    /// </summary>
    public class ShapeRepository
    {
        /// <summary>
        /// Creates object for Rectangle
        /// </summary>
        /// <param name="color"> color of the Rectangle </param>
        /// <returns> Details of Rectangle </returns>
        public string AddRectangle(string color)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.color = color;
            rectangle.CalculateArea();
            return rectangle.PrintDetails();
        }

        /// <summary>
        /// Creates object for Circle
        /// </summary>
        /// <param name="color"> color of the Circle </param>
        /// <returns> Details of Circle </returns>
        public string AddCircle(string color)
        {
            Circle circle = new Circle();
            circle.color = color;
            circle.CalculateArea();
            return circle.PrintDetails();
        }
    }
}
