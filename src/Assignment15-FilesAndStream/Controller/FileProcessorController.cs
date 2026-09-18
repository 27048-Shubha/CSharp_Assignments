using Assignment15_FilesAndStream.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment15_FilesAndStream.Controller
{
    using Assignment15_FilesAndStream.Tasks;
    internal class FileProcessorController
    {
        private readonly FileDataProcessorSync _fileHandler;
        internal FileProcessorController(FileDataProcessorSync fileHandler)
        {
            this._fileHandler = fileHandler;
        }

        public void RunTask1()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "source.txt");
            if (!File.Exists(filePath))
            {
                FileGenerator.GenerateFile(filePath, 1024 * 1024 * 1024);
            }

            Stopwatch stopwatch1 = Stopwatch.StartNew();
            new FileDataProcessorSync().ReadUsingFileStream();
            stopwatch1.Stop();
            Console.WriteLine($"Time taken to read using file stream: {stopwatch1.ElapsedMilliseconds} milliseconds");

            Stopwatch stopwatch2 = Stopwatch.StartNew();
            new FileDataProcessorSync().ReadUsingBufferedStream();
            stopwatch2.Stop();
            Console.WriteLine($"Time taken to read using buffered stream: {stopwatch2.ElapsedMilliseconds} milliseconds");

            new FileDataProcessorSync().ProcessAndWriteData();
        }
    }
}
