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
            Console.WriteLine($"Content to be written to the file: {Program._content}");

            using (FileHandler handler1 = new FileHandler())
            {
                handler1.WriteFile("Hello world!");
            }

            using StreamReader reader = new StreamReader("./TextFile.txt");
            Console.WriteLine($"Content read from the file: {reader.ReadLine()}");
        }
    }
}