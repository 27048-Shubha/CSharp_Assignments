using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Assignment15_FilesAndStream.Tasks
{
    /// <summary>
    /// Manages file data processing operations
    /// </summary>
    internal class Task2_AsyncFileDataProcessor
    {
        private const int _bufferSize = 4096;

        /// <summary>
        /// Runs tasks concurrently
        /// </summary>
        /// <returns>Asynchronous task</returns>
        public async Task RunTasks()
        {
            Task task1 = this.CallAsync("source1.txt", "destination1.txt", "Task1");
            Task task2 = this.CallAsync("source2.txt", "destination2.txt", "Task2");
            Task task3 = this.CallAsync("source3.txt", "destination3.txt", "Task3");

            await Task.WhenAll(task1, task2, task3);
        }

        private async Task CallAsync(string sourcePath, string destinationPath, string taskName)
        {
            byte[] buffer = new byte[_bufferSize];

            try
            {
                if (!File.Exists(sourcePath))
                {
                    this.GenerateFile(sourcePath);
                }

                await this.ReadUsingBufferedStream(sourcePath, buffer);

                File.WriteAllText(destinationPath, string.Empty);

                using (FileStream fileStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                {
                    Console.WriteLine($"{taskName}: Processing data from file and writing to new destination file using memory stream...");

                    int bytesRead;
                    while ((bytesRead = fileStream.Read(buffer, 0, _bufferSize)) > 0)
                    {
                        byte[] processedData = this.ProcessData(bytesRead, buffer);
                        await this.WriteUsingMemoryStream(destinationPath, processedData);
                    }

                    Console.WriteLine($"{taskName}: Data has been written successfully from file using memory stream");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void GenerateFile(string sourcePath)
        {
            using StreamWriter writer = new StreamWriter(sourcePath);
            const int targetSize = 1024 * 10;
            Random random = new Random();
            int size = 0;

            while (size < targetSize)
            {
                char randomCharacter = (char)random.Next('a', 'z' + 1);
                writer.Write(randomCharacter);
                size++;
            }
        }

        private async Task ReadUsingBufferedStream(string sourcePath, byte[] buffer)
        {
            using (FileStream fileStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))

            using (BufferedStream bufferedStream = new BufferedStream(fileStream))
            {
                int bytesRead;
                while ((bytesRead = await bufferedStream.ReadAsync(buffer, 0, _bufferSize)) > 0)
                {
                }
            }
        }

        private byte[] ProcessData(int bytesRead, byte[] buffer)
        {
            string content = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            content = content.ToUpperInvariant();
            return Encoding.UTF8.GetBytes(content);
        }

        private async Task WriteUsingMemoryStream(string destinationPath, byte[] processedData)
        {
            await using (MemoryStream memoryStream = new MemoryStream(processedData))
            {
                using (FileStream fileStream = new FileStream(destinationPath, FileMode.Append, FileAccess.Write))
                {
                    await memoryStream.CopyToAsync(fileStream);
                }
            }
        }
    }
}
