namespace Assignment15_FilesAndStream.Controller
{
    using Assignment15_FilesAndStream.Helper;
    using Assignment15_FilesAndStream.Service;

    /// <summary>
    /// Demonstrates file operations using different file streams.
    /// </summary>
    internal class FileProcessorController
    {
        private const long OneGb = 1024L * 1024 * 1024;

        private readonly SynchronousFileProcessor _fileProcessor;

        private readonly string _sourcePath = Path.Combine(AppContext.BaseDirectory, "source.txt");
        private readonly string _destinationPath = Path.Combine(AppContext.BaseDirectory, "processed.txt");

        /// <summary>
        /// Initializes a new instance of the <see cref="FileProcessorController"/> class.
        /// </summary>
        /// <param name="fileProcessor">Object to handle synchronous file tasks.</param>
        internal FileProcessorController(SynchronousFileProcessor fileProcessor)
        {
            this._fileProcessor = fileProcessor;
        }

        /// <summary>
        /// Runs comparison of file stream and buffer stream.
        /// </summary>
        public void ExecuteStreamComparison()
        {
            this.ConfigureProcessor();

            if (!File.Exists(this._sourcePath))
            {
                FileGenerator.GenerateFile(this._sourcePath, OneGb);
            }

            this.MeasureAndDisplay("Read using file stream", () => this._fileProcessor.ReadUsingFileStream());
            this.MeasureAndDisplay("Process data", () => this._fileProcessor.ReadUsingFileStream());

            this.MeasureAndDisplay("Read using buffered stream", () => this._fileProcessor.ReadUsingFileStream());
            this.MeasureAndDisplay("Process data", () => this._fileProcessor.ReadUsingFileStream());
        }

        private void ConfigureProcessor()
        {
            this._fileProcessor.SourcePath = this._sourcePath;
            this._fileProcessor.DestinationPath = this._destinationPath;
        }

        private void MeasureAndDisplay(string operationName, Action action)
        {
            Timer timer = new ();
            timer.StartTimer();
            action();
            timer.StopTimer();

            Console.WriteLine($"{operationName}: {timer.GetTimeTaken()} milliseconds");
        }
    }
}
