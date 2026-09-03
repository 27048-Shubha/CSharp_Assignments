namespace Assignment2.Models
{
    /// <summary>
    /// Handles area calculation of the Rectangle inherited from the Shape.
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="color">Color of the shape</param>
        /// <param name="length">Length of the rectangle</param>
        /// <param name="breadth">Breadth of the rectangle</param>
        internal Rectangle(string color, double length, double breadth)
            : base(color)
        {
            this.Length = length;
            this.Breadth = breadth;
        }

        /// <summary>
        /// Gets or sets length of the rectangle.
        /// </summary>
        /// <value> The length of the rectangle. </value>
        public double Length { get; set; }

        /// <summary>
        /// Gets or sets breadth of the rectangle.
        /// </summary>
        /// <value> The breadth of the rectangle. </value>
        public double Breadth { get; set; }

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
            return base.PrintDetails();
        }
    }
}