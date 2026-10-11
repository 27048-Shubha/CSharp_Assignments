using System.Diagnostics;
using System.Text;

namespace Assignment15_FilesAndStream.Service
{
    /// <summary>
    /// Manages file data processing operations
    /// </summary>
    internal class SynchronousFileProcessor
    {
        private const int _bufferSize = 4096;

        private byte[] _buffer = new byte[_bufferSize];

        /// <summary>
        /// Gets or sets path of the source file.
        /// </summary>
        /// <value>Path of the source file.</value>
        public string SourcePath { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets path of the destination file.
        /// </summary>
        /// <value>Path of the destination file.</value>
        public string DestinationPath { get; set; } = string.Empty;

        /// <summary>
        /// Reads the file using file stream.
        /// </summary>
        public void ReadUsingFileStream()
        {
            using (FileStream fileStream = new FileStream(this.SourcePath, FileMode.Open, FileAccess.Read))
            {
                int bytesRead;
                while ((bytesRead = fileStream.Read(this._buffer, 0, _bufferSize)) > 0)
                {
                }
            }
        }

        /// <summary>
        /// Reads the file using buffered stream.
        /// </summary>
        public void ReadUsingBufferedStream()
        {
            using (FileStream fileStream = new FileStream(this.SourcePath, FileMode.Open, FileAccess.Read))

            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            {
                int bytesRead;
                while ((bytesRead = bufferedStream.Read(this._buffer, 0, _bufferSize)) > 0)
                {
                }
            }
        }

        /// <summary>
        /// Processes and writes data to the destination path.
        /// </summary>
        public void ProcessAndWriteData()
        {
            File.WriteAllText(this.DestinationPath, string.Empty);

            using (FileStream fileStream = new FileStream(this.SourcePath, FileMode.Open, FileAccess.Read))
            {
                int bytesRead;
                while ((bytesRead = fileStream.Read(this._buffer, 0, _bufferSize)) > 0)
                {
                    byte[] processedData = this.ProcessData(bytesRead);
                    this.WriteUsingMemoryStream(processedData);
                }
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
                using (FileStream fileStream = new FileStream(this.DestinationPath, FileMode.Append, FileAccess.Write))
                {
                    memoryStream.CopyTo(fileStream);
                }
            }
        }
    }
}
