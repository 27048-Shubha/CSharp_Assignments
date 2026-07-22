using System;

namespace Assignment2.Task1
{
    /// <summary>
    /// Abstract Class that holds 
    /// </summary>
    public abstract class Shapes
    {
        private string _color;
        private double _area;
        /// <summary>
        /// Gets or sets Color of the Shape
        /// </summary>
        /// <value> Name of the Color entered by the user </value>
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        /// <summary>
        /// Gets or sets Area of the Shape
        /// </summary>
        /// <value> Holds value of the area </value>
        public double Area
        {
            get { return _area; }
            set { _area = value; }
        }

        /// <summary>
        /// Abstract Method to calculate area
        /// </summary>
        /// <returns> Area of the respective shapes after calculation </returns>
        public abstract double CalculateArea();

        /// <summary>
        /// Displays Details of the Shape
        /// </summary>
        public void PrintDetails()
        {
            Console.WriteLine($"Shape Type: {this.GetType().Name} \nColor: {Color} \nArea: {Math.Round(Area, 2)}\n");
        }
    }
}