namespace Models
{
    internal class Circle : Shape
    {
        public Circle(string color, double radius)
            : base(color)
        {
            Radius = radius;
        }

        public double Radius { get; set; }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
