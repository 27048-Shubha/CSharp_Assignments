namespace Assignment16_AdvancedCSharp.Models
{
    /// <summary>
    /// Represents information about shape.
    /// </summary>
    internal abstract class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="color">Color of the shape</param>
        protected Shape(string color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Gets color of the shape.
        /// </summary>
        /// <value>Color of the shape</value>
        public string Color { get; }

        /// <summary>
        /// Calculates area of the shape.
        /// </summary>
        /// <returns>Area of the shape.</returns>
        public abstract double CalculateArea();
    }
}