namespace Models
{
    /// <summary>
    /// Represents information about shape.
    /// </summary>
    public class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        /// <param name="color">Color of the shape.</param>
        public Shape(string color)
        {
            this.Color = color;
        }

        /// <summary>
        /// Gets or sets color of the shape.
        /// </summary>
        /// <value>Color of the shape.</value>
        public string Color { get; set; }
    }
}
