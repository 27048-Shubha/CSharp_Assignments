namespace Assignments
{
    /// <summary>
    /// Manages main flow of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the program.
        /// </summary>
        public static void Main()
        {
            using (FileWriter writer = new FileWriter())
            {
                writer.WriteFile("Hello world!");
            }
        }
    }

    /// <summary>
    /// Manages file operations.
    /// </summary>
    public class FileWriter : IDisposable
    {
        private readonly string _filePath = "./TextFile.txt";
        private StreamWriter _writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// </summary>
        public FileWriter()
        {
            this._writer = new StreamWriter(this._filePath);
        }

        /// <summary>
        /// Writes text inside the file.
        /// </summary>
        /// <param name="text">Text to be written into the file.</param>
        public void WriteFile(string text)
        {
            this._writer.WriteLine(text);
        }

        /// <summary>
        /// Disposes file writer.
        /// </summary>
        public void Dispose()
        {
            this._writer.Dispose();
            this._writer.Close();
        }
    }
}