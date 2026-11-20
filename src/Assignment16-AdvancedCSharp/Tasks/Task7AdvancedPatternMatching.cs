namespace Assignment16_AdvancedCSharp.Tasks
{
    using Assignment16_AdvancedCSharp.Models;

    /// <summary>
    /// Demonstrates task 7 with advanced pattern matching
    /// </summary>
    public class Task7AdvancedPatternMatching
    {
        /// <summary>
        /// Entry point of Task7 demonstration.
        /// </summary>
        public void Run()
        {
            List<Shape?> shapes = new List<Shape?>()
            {
                new Circle("Red", 5),
                new Rectangle("Yellow", 2, 3),
                new Triangle("Green", 4, 7),
                null,
            };

            foreach (Shape? shape in shapes)
            {
                DisplayShapeDetails(shape);
            }
        }

        private static void DisplayShapeDetails(Shape? shape)
        {
            string message = shape switch
            {
                Circle circle =>
                    FormatDetails(circle, "Circle"),

                Rectangle { Length: var length, Breadth: var breadth }
                    when length == breadth =>
                    FormatDetails(shape, "Square"),

                Rectangle rectangle =>
                    FormatDetails(rectangle, "Rectangle"),

                Triangle triangle =>
                    FormatDetails(triangle, "Triangle"),

                null =>
                    "The object is null and doesn't match any of the types",

                _ =>
                    "The object doesn't match any of the types",
            };

            Console.WriteLine($"{message}\n");
        }

        private static string FormatDetails(Shape shape, string description)
        {
            return
                $"Shape: {description}\n" +
                $"Color: {shape.Color}\n" +
                $"Area: {shape.CalculateArea():F2}";
        }
    }
}
