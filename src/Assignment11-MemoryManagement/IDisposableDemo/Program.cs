namespace Assignments
{
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

    /// <summary>
    /// Manages file operations.
    /// </summary>
    public class FileHandler : IDisposable
    {
        private readonly string _filePath = "./TextFile.txt";
        private StreamWriter _writer;

        /// <summary>
        /// Writes text inside the file.
        /// </summary>
        /// <param name="text">Text to be written into the file.</param>
        public void WriteFile(string text)
        {
            this._writer = new StreamWriter(this._filePath);
            this._writer.WriteLine(text);
        }

        /// <summary>
        /// Disposes file writer.
        /// </summary>
        public void Dispose()
        {
            this._writer.Dispose();
        }
    }
}