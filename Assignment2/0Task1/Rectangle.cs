using Assignment2;
using System;

namespace Assignment2.Task1
{
    /// <summary>
    /// Holds Attributes and Methods of Rectangle Inherited from Shapes
    /// </summary>
    public class Rectangle : Shapes
    {
        private double _length, _breadth;

        /// <summary>
        /// Gets or sets Length of the Rectangle
        /// </summary>
        /// <value> Length of the Rectangle </value>
        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        /// <summary>
        /// Gets or sets Breadth of the Rectangle
        /// </summary>
        /// <value> Breadth of the Rectangle </value>
        public double Breadth
        {
            get { return _breadth; }
            set { _breadth = value; }
        }

        /// <summary>
        /// Calculates Area of the Rectangle
        /// </summary>
        /// <returns> Area of the Rectangle </returns>
        public override double CalculateArea()
        {
            return Length * Breadth;
        }

        /// <summary>
        /// Displays details of Rectangle
        /// </summary>
        protected void PrintDetails()
        {
            base.PrintDetails();
        }
    }
}