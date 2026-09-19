namespace Assignment16_AdvancedCSharp.Tasks
{
    using Models;

    internal class Task7_AdvancedPatternMatching
    {
        public void Run()
        {
            List<Shape> shapes = new List<Shape>()
            {
                new Circle("Red", 5),
                new Rectangle("Yellow", 2, 3),
                new Triangle("Green", 4, 7),
                null
            };

            foreach (Shape shape in shapes)
            {
                this.DisplayShapeDetails(shape);
            }
        }

        private void DisplayShapeDetails(Shape shape)
        {
            switch (shape)
            {
                case Circle circle:
                    Console.WriteLine(
                        $"\nShape: Circle\n"+
                        $"Color: {circle.Color}\n" +
                        $"Area: {circle.CalculateArea()}"
                    );
                    break;

                case Rectangle rectangle:
                    Console.WriteLine(
                        $"\nShape: Rectangle\n" +
                        $"Color: {rectangle.Color}\n" +
                        $"Area: {rectangle.CalculateArea()}"
                    );
                    break;

                case Triangle triangle:
                    Console.WriteLine(
                        $"\nShape: Triangle\n" +
                        $"Color: {triangle.Color}\n" +
                        $"Area: {triangle.CalculateArea()}"
                    );
                    break;

                case null:
                    Console.WriteLine("\nThe object is null and doesnt match any of the types");
                    break;

                default:
                    Console.WriteLine("The object doesn't match any of the types");
                    break;
            }
        }
    }
}
