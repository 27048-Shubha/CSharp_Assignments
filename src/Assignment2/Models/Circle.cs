namespace Assignment2.Models
{
    /// <summary>
    /// Handles area calculation of the Circle inherited from the Shape.
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="color">Color of the shape</param>
        /// <param name="radius">Radius of the circle</param>
        internal Circle(string color, double radius)
            :base(color)
        {
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets radius of the circle.
        /// </summary>
        /// <value> The radius of the circle. </value>
        public double Radius { get;  set; }

        /// <summary>
        /// Calculates area of the circle.
        /// </summary>
        /// <returns> The area of the circle. </returns>
        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }

        /// <summary>
        /// Displays details of circle.
        /// </summary>
        /// <returns> The details of the cirle. </returns>
        public new string PrintDetails()
        {
            return base.PrintDetails();
        }
    }
}