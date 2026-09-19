namespace Models
{
    /// <summary>
    /// Represents information about circle shape.
    /// </summary>
    internal class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="color">Color of the shape.</param>
        /// <param name="radius">Radius of the shape.</param>
        public Circle(string color, double radius)
            : base(color)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets radius of the shape.
        /// </summary>
        /// <value>Radius of the shape.</value>
        public double Radius { get; set; }

        /// <summary>
        /// Calculates area of the circle.
        /// </summary>
        /// <returns>Calculated area of the circle.</returns>
        public double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }
    }
}
