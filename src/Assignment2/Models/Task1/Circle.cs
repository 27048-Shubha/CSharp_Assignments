namespace Assignment2.Models.Task1
{
    /// <summary>
    /// Handles area calculation of the Circle inherited from the Shape.
    /// </summary>
    internal class Circle : Shapes
    {
        private double _radius;

        /// <summary>
        /// Gets or sets radius of the circle.
        /// </summary>
        /// <value> The radius of the circle. </value>
        public double Radius
        {
            get { return this._radius; }
            set { this._radius = value; }
        }

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