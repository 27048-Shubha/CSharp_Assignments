namespace Assignment2.Models.Task1
{
    /// <summary>
    /// Handles _area calculation of the Circle inherited from the Shape.
    /// </summary>
    internal class Circle : Shapes
    {
        private double _radius;

        /// <summary>
        /// Gets or sets _radius of the circle.
        /// </summary>
        /// <value> The _radius of the circle. </value>
        public double Radius
        {
            get { return this._radius; }
            set { this._radius = value; }
        }

        /// <summary>
        /// Calculates _area of the circle.
        /// </summary>
        /// <returns> The _area of the circle. </returns>
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