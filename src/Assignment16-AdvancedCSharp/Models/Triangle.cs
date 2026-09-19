namespace Models
{
    /// <summary>
    /// Represents information about triangle shape.
    /// </summary>
    internal class Triangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="color">Color of the triangle</param>
        /// <param name="baseLength">Base length of the triangle.</param>
        /// <param name="height">Height of the triangle.</param>
        public Triangle(string color, double baseLength, double height)
            : base(color)
        {
            this.Base = baseLength;
            this.Height = height;
        }

        private double Base { get; set; }

        private double Height { get; set; }

        /// <summary>
        /// Calculates area of the rectangle.
        /// </summary>
        /// <returns>Calculated area of the rectangle.</returns>
        public double CalculateArea()
        {
            return 0.5 * this.Base * this.Height;
        }
    }
}
