namespace Assignment2.Models.Task1
{
    using System;

    /// <summary>
    /// Handles area calculation of the Rectangle inherited from the Shape.
    /// </summary>
    public class Rectangle : Shapes
    {
        private double length;
        private double breadth;

        /// <summary>
        /// Gets or sets length of the rectangle.
        /// </summary>
        /// <value> The length of the rectangle. </value>
        public double Length
        {
            get { return this.length; }
            set { this.length = value; }
        }

        /// <summary>
        /// Gets or sets breadth of the rectangle.
        /// </summary>
        /// <value> The breadth of the rectangle. </value>
        public double Breadth
        {
            get { return this.breadth; }
            set { this.breadth = value; }
        }

        /// <summary>
        /// Calculates area of the rectangle.
        /// </summary>
        /// <returns> The calculated area of the rectangle. </returns>
        public override double CalculateArea()
        {
            return this.Length * this.Breadth;
        }

        /// <summary>
        /// Displays details of Rectangle.
        /// </summary>
        /// <returns> The details of the rectangle. </returns>
        public new string PrintDetails()
        {
            return this.PrintDetails();
        }
    }
}