namespace Assignment16_AdvancedCSharp.Tasks
{
    using Models;

    /// <summary>
    /// Demonstrates task 7 with advanced pattern matching
    /// </summary>
    internal class Task7_AdvancedPatternMatching
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
                this.DisplayShapeDetails(shape);
            }
        }

        private void DisplayShapeDetails(Shape? shape)
        {
            string message = shape switch
            {
                Circle circle =>
                    $"Shape: Circle\n" +
                    $"Color: {circle.Color}\n" +
                    $"Area: {circle.CalculateArea()}",

                Rectangle rectangle =>
                    $"Shape: Rectangle\n" +
                    $"Color: {rectangle.Color}\n" +
                    $"Area: {rectangle.CalculateArea()}",

                Triangle triangle =>
                    $"Shape: Triangle\n" +
                    $"Color: {triangle.Color}\n" +
                    $"Area: {triangle.CalculateArea()}",

                null =>
                    "The object is null and doesn't match any of the types",

                _ =>
                    "The object doesn't match any of the types",
            };

            Console.WriteLine(message);
        }
    }
}
