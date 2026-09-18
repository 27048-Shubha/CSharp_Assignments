using System.Diagnostics;
using System.Text;

namespace Assignment15_FilesAndStream.Tasks
{
    /// <summary>
    /// Manages file data processing operations
    /// </summary>
    internal class FileDataProcessorSync
    {
        private const int _bufferSize = 4096;

        private byte[] _buffer = new byte[_bufferSize];

        public string SourcePath { get; set; }

        public string DestinationPath { get; set; }

        /// <summary>
        /// Entry point of task 1
        /// </summary>
        public void GenerateFile()
        {
            using StreamWriter writer = new StreamWriter(this.SourcePath);
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

        public void ReadUsingFileStream()
        {
            using (FileStream fileStream = new FileStream(this.SourcePath, FileMode.Open, FileAccess.Read))
            {
                // Console.WriteLine("Reading data from file using file stream...");

                int bytesRead;
                while ((bytesRead = fileStream.Read(this._buffer, 0, _bufferSize)) > 0)
                {
                }

                // Console.WriteLine("Data read successfully from file using file stream\n");
            }
        }

        public void ReadUsingBufferedStream()
        {
            using (FileStream fileStream = new FileStream(this.SourcePath, FileMode.Open, FileAccess.Read))

            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            {
                // Console.WriteLine("Reading data from file using buffered stream...");

                int bytesRead;
                while ((bytesRead = bufferedStream.Read(this._buffer, 0, _bufferSize)) > 0)
                {
                }

                // Console.WriteLine("Data read successfully from file using buffered stream\n");
            }
        }

        public void ProcessAndWriteData()
        {
            File.WriteAllText(this.DestinationPath, string.Empty);

            using (FileStream fileStream = new FileStream(this.SourcePath, FileMode.Open, FileAccess.Read))
            {
                // Console.WriteLine("Processing data from file and writing to new destination file using memory stream...");

                int bytesRead;
                while ((bytesRead = fileStream.Read(this._buffer, 0, _bufferSize)) > 0)
                {
                    byte[] processedData = this.ProcessData(bytesRead);
                    this.WriteUsingMemoryStream(processedData);
                }

                // Console.WriteLine("Data has been written successfully from file using memory stream\n");
            }
        }

        public byte[] ProcessData(int bytesRead)
        {
            string content = Encoding.UTF8.GetString(this._buffer, 0, bytesRead);
            content = content.ToUpperInvariant();
            return Encoding.UTF8.GetBytes(content);
        }

        public void WriteUsingMemoryStream(byte[] processedData)
        {
            using (MemoryStream memoryStream = new MemoryStream(processedData))
            {
                using (FileStream fileStream = new FileStream(this.DestinationPath, FileMode.Append, FileAccess.Write))
                {
                    memoryStream.CopyTo(fileStream);
                }
            }
        }
    }
}
