namespace Assignment2.Models.Task1
{
    using System;

    /// <summary>
    /// Abstract class of shapes containing color, area calculation, print method.
    /// </summary>
    public abstract class Shapes
    {
        private string? _color;
        private double _area;

        /// <summary>
        /// Gets or sets color of the shape.
        /// </summary>
        /// <value> The name of the color entered by the user. </value>
        public string? Color
        {
            get { return this._color; }
            set { this._color = value; }
        }

        /// <summary>
        /// Gets or sets area of the shape.
        /// </summary>
        /// <value> The name of the area entered by the user. </value>
        public double Area
        {
            get { return this._area; }
            set { this._area = value; }
        }

        /// <summary>
        /// Abstract method to calculate area.
        /// </summary>
        /// <returns> Area of the shape. </returns>
        public abstract double CalculateArea();

        /// <summary>
        /// Displays details of the shape.
        /// </summary>
        /// <returns> The details of the shape. </returns>
        public string PrintDetails()
        {
            return $"Shape Type: {this.GetType().Name} \nColor: {this.Color} \nArea: {Math.Round(this.Area, 2)}\n";
        }
    }
}