namespace Assignment2.Models
{
    using System;

    /// <summary>
    /// Abstract class of shapes containing color, area calculation, print method.
    /// </summary>
    public abstract class Shapes
    {
        /// <summary>
        /// Gets or sets color of the shape.
        /// </summary>
        /// <value> The _name of the color entered by the user. </value>
        public string Color { get; set; } = string.Empty;

        /// <summary>
        /// Calculates the area of the shape using the dimensions specific to the shape type.
        /// </summary>
        /// <returns> The calculated area of the shape. </returns>
        public abstract double CalculateArea();
        public abstract double CalculateArea();

        /// <summary>
        /// Displays details of the shape.
        /// </summary>
        /// <returns> The details of the shape. </returns>
        public string PrintDetails()
        {
            return $"Shape Type: {this.GetType().Name} \nColor: {this.Color} \nArea: {Math.Round(this.CalculateArea(), 2)}\n";
        }
    }
}