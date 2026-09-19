namespace Models
{
    internal class Triangle : Shape
    {
        public Triangle(string color, double baseValue, double height)
            : base(color)
        {
            Base = baseValue;
            Height = height;
        }
        public double Base { get; set; }

        public double Height { get; set; }

        public double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
    }
}
