using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableDemo.FileHandler
{
    /// <summary>
    /// Manages file operations.
    /// </summary>
    public sealed class FileHandler : IDisposable
    {
        private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "TextFile.txt");
        private bool _disposed = false;

        /// <summary>
        /// Reads text inside the file.
        /// </summary>
        /// <returns>Content read from the file.</returns>
        public string ReadFile()
        {
            using StreamReader reader = new StreamReader(this._filePath);
            return reader.ReadToEnd();
        }

        /// <summary>
        /// Writes text inside the file.
        /// </summary>
        /// <param name="text">Text to be written into the file.</param>
        public void WriteFile(string text)
        {
            if (this._disposed)
            {
                return;
            }

            using (StreamWriter writer = new StreamWriter(this._filePath))
            {
                writer.WriteLine(text);
            }
        }

        /// <summary>
        /// Disposes file writer.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}
