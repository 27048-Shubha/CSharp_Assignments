namespace Assignment16_AdvancedCSharp.Models
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
        internal Triangle(string color, double baseLength, double height)
            : base(color)
        {
            this.BaseLength = baseLength;
            this.Height = height;
        }

        private double BaseLength { get; set; }

        private double Height { get; set; }

        /// <summary>
        /// Calculates area of the triangle.
        /// </summary>
        /// <returns>Calculated area of the triangle.</returns>
        public override double CalculateArea()
        {
            return 0.5 * this.BaseLength * this.Height;
        }
    }
}