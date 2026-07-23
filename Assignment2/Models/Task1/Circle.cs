namespace Assignment2.Models.Task1
{
    /// <summary>
    /// Holds Attributes and Methods of Circle Inherited from Shapes
    /// </summary>
    internal class Circle : Shapes
    {
        private double _radius;

        /// <summary>
        /// Gets or sets Radius of the Circle
        /// </summary>
        /// <value> Radius of the Circle </value>
        public double Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        /// <summary>
        /// Calculates Area of the Circle
        /// </summary>
        /// <returns> Area of the Circle </returns>
        public override double CalculateArea()
        {
            return 3.17 * Radius * Radius;
        }

        /// <summary>
        /// Displays details of Circle
        /// </summary>
        /// <returns> Details of the Circle </returns>
        public new string PrintDetails()
        {
            return base.PrintDetails();
        }
    }
}