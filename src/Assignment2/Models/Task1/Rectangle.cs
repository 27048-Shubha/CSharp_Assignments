namespace Assignment2.Models.Task1
{
    /// <summary>
    /// Handles _area calculation of the Rectangle inherited from the Shape.
    /// </summary>
    public class Rectangle : Shapes
    {
        private double _length;
        private double _breadth;

        /// <summary>
        /// Gets or sets _length of the rectangle.
        /// </summary>
        /// <value> The _length of the rectangle. </value>
        public double Length
        {
            get { return this._length; }
            set { this._length = value; }
        }

        /// <summary>
        /// Gets or sets _breadth of the rectangle.
        /// </summary>
        /// <value> The _breadth of the rectangle. </value>
        public double Breadth
        {
            get { return this._breadth; }
            set { this._breadth = value; }
        }

        /// <summary>
        /// Calculates _area of the rectangle.
        /// </summary>
        /// <returns> The calculated _area of the rectangle. </returns>
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