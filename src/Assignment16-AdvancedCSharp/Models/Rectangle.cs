namespace Models
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
        public Rectangle(string color, double length, double breadth)
                                    : base(color)
        {
            this.Length = length;
            this.Breadth = breadth;
        }

        private double Length { get; set; }

        private double Breadth { get; set; }

        /// <summary>
        /// Calculates area of the rectangle.
        /// </summary>
        /// <returns>Area of the rectangle.</returns>
        public double CalculateArea()
        {
            return this.Length * this.Breadth;
        }
    }
}
