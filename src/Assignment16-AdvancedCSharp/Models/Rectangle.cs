namespace Models
{
    internal class Rectangle : Shape
    {
        public Rectangle(string color, double length, double breadth)
                                    : base(color)
        {
            Length = length;
            Breadth = breadth;
        }

        public double Length { get; set; }

        public double Breadth { get; set; }

        public double CalculateArea()
        {
            return Length * Breadth;
        }
    }
}
