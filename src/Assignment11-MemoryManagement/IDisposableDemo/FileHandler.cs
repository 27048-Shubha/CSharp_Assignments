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
    public class FileHandler : IDisposable
    {
        private readonly string _filePath = "./TextFile.txt";
        private StreamWriter? _writer = null;

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
