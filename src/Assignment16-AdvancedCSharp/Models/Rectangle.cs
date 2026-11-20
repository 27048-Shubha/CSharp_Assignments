namespace Assignment16_AdvancedCSharp.Models
{
    /// <summary>
    /// Represents information about rectangle shape.
    /// </summary>
    internal class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="color">Color of the rectangle</param>
        /// <param name="length">Length of the rectangle.</param>
        /// <param name="breadth">Breadth of the rectangle.</param>
        internal Rectangle(string color, double length, double breadth)
            : base(color)
        {
            this.Length = length;
            this.Breadth = breadth;
        }

        /// <summary>
        /// Gets the length of the rectangle.
        /// </summary>
        /// <value>Length of the rectangle.</value>
        public double Length { get; }

        /// <summary>
        /// Gets the breadth of the rectangle.
        /// </summary>
        /// <value>Breadth of the rectangle.</value>
        public double Breadth { get; }

        /// <summary>
        /// Calculates area of the rectangle.
        /// </summary>
        /// <returns>Area of the rectangle.</returns>
        public override double CalculateArea()
        {
            return this.Length * this.Breadth;
        }
    }
}
