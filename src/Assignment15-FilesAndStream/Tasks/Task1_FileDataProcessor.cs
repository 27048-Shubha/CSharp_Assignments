using System.Diagnostics;
using System.Text;

namespace Assignment15_FilesAndStream.Tasks
{
    /// <summary>
    /// Manages file data processing operations
    /// </summary>
    internal class Task1_FileDataProcessor
    {
        private const int _bufferSize = 4096;

        private readonly string _sourcePath = Path.Combine(AppContext.BaseDirectory, "source.txt");

        private readonly string _destinationPath = "destination.txt";

        private byte[] _buffer = new byte[_bufferSize];
        private byte[] _processedDataBuffer = new byte[_bufferSize];

        /// <summary>
        /// Entry point of task 1
        /// </summary>
        public void Run()
        {
            if (!File.Exists(this._sourcePath))
            {
                this.GenerateFile();
            }

            Stopwatch stopwatch1 = Stopwatch.StartNew();
            this.ReadUsingFileStream();
            stopwatch1.Stop();
            Console.WriteLine($"Time taken to read using file stream: {stopwatch1.ElapsedMilliseconds} milliseconds");

            Stopwatch stopwatch2 = Stopwatch.StartNew();
            this.ReadUsingBufferedStream();
            stopwatch2.Stop();
            Console.WriteLine($"Time taken to read using buffered stream: {stopwatch2.ElapsedMilliseconds} milliseconds");

            File.WriteAllText(this._destinationPath, string.Empty);

            using (FileStream fileStream = new FileStream(this._sourcePath, FileMode.Open, FileAccess.Read))
            {
                Console.WriteLine("Processing data from file and writing to new destination file using memory stream...");

                int bytesRead;
                while ((bytesRead = fileStream.Read(this._buffer, 0, _bufferSize)) > 0)
                {
                    byte[] processedData = this.ProcessData(bytesRead);
                    this.WriteUsingMemoryStream(processedData);
                }

                Console.WriteLine("Data has been written successfully from file using memory stream");
            }
        }

        private void GenerateFile()
        {
            using StreamWriter writer = new StreamWriter(this._sourcePath);
            const int targetSize = 1024 * 1024 * 1024;
            Random random = new Random();
            int size = 0;

            while (size < targetSize)
            {
                char randomCharacter = (char)random.Next('a', 'z' + 1);
                writer.Write(randomCharacter);
                size++;
            }
        }

        private void ReadUsingFileStream()
        {
            using (FileStream fileStream = new FileStream(this._sourcePath, FileMode.Open, FileAccess.Read))
            {
                Console.WriteLine("Reading data from file using file stream...");

                int bytesRead;
                while ((bytesRead = fileStream.Read(this._buffer, 0, _bufferSize)) > 0)
                {
                }

                Console.WriteLine("Data read successfully from file using file stream");
            }
        }

        private void ReadUsingBufferedStream()
        {
            using (FileStream fileStream = new FileStream(this._sourcePath, FileMode.Open, FileAccess.Read))

            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            {
                Console.WriteLine("Reading data from file using buffered stream...");

                int bytesRead;
                while ((bytesRead = bufferedStream.Read(this._buffer, 0, _bufferSize)) > 0)
                {
                }

                Console.WriteLine("Data read successfully from file using buffered stream");
            }
        }

        private byte[] ProcessData(int bytesRead)
        {
            string content = Encoding.UTF8.GetString(this._buffer, 0, bytesRead);
            content = content.ToUpperInvariant();
            return Encoding.UTF8.GetBytes(content);
        }

        private void WriteUsingMemoryStream(byte[] processedData)
        {
            using (MemoryStream memoryStream = new MemoryStream(processedData))
            {
                using (FileStream fileStream = new FileStream(this._destinationPath, FileMode.Append, FileAccess.Write))
                {
                    memoryStream.CopyTo(fileStream);
                }
            }
        }
    }
}
