namespace Assignments
{
    using IDisposableDemo.FileHandler;

    /// <summary>
    /// Manages main flow of the application.
    /// </summary>
    public class Program
    {
        private static readonly string _content = "Hello World!";

        /// <summary>
        /// Entry point of the program.
        /// </summary>
        public static void Main()
        {
            Console.WriteLine($"Content to be written to the file: {_content}");

            using (FileHandler handler = new FileHandler())
            {
                handler.WriteFile("Hello world!");
                Console.WriteLine($"Content read from the file: {handler.ReadFile()}");
            }
        }
    }
}