namespace Assignment15_FilesAndStream.Controller
{
    using Assignment15_FilesAndStream.Helper;
    using Assignment15_FilesAndStream.Service;

    internal class FileProcessorController
    {
        private const long OneGb = 1024L * 1024 * 1024;

        private readonly SynchronousFileProcessor _fileProcessor;

        internal FileProcessorController(SynchronousFileProcessor fileProcessor)
        {
            this._fileProcessor = fileProcessor;
        }

        public void ExecuteBufferComparison()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "source.txt");
            if (!File.Exists(filePath))
            {
                FileGenerator.GenerateFile(filePath, OneGb);
            }

            Timer timer = new();
            timer.StartTimer();
            this._fileProcessor.ReadUsingFileStream();
            timer.StopTimer();
            Console.WriteLine($"Time taken to read using file stream: {timer.GetTimeTaken()} milliseconds");

            timer.StartTimer();
            this._fileProcessor.ReadUsingBufferedStream();
            timer.StopTimer();
            Console.WriteLine($"Time taken to read using buffered stream: {timer.GetTimeTaken()} milliseconds");

            this._fileProcessor.ProcessAndWriteData();
        }
    }
}
