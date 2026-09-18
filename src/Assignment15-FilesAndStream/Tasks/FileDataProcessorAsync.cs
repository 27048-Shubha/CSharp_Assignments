using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Assignment15_FilesAndStream.Tasks
{
    /// <summary>
    /// Manages file data processing operations
    /// </summary>
    internal class FileDataProcessorAsync
    {
        private const int _bufferSize = 4096;

        public async Task CallAsync(string sourcePath, string destinationPath, string taskName)
        {
            byte[] buffer = new byte[_bufferSize];

            try
            {
                File.WriteAllText(destinationPath, string.Empty);

                using (FileStream fileStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                {
                    // Console.WriteLine($"{taskName}: Processing data from file and writing to new destination file using memory stream...");

                    int bytesRead;
                    while ((bytesRead = await fileStream.ReadAsync(buffer, 0, _bufferSize)) > 0)
                    {
                        byte[] processedData = this.ProcessData(bytesRead, buffer);
                        await this.WriteUsingMemoryStream(destinationPath, processedData);
                    }

                    Console.WriteLine($"[Async] Completed: {sourcePath} to {destinationPath}");

                    // Console.WriteLine($"{taskName}: Data has been written successfully from file using memory stream\n");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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
                using (FileStream fileStream = new FileStream(destinationPath, FileMode.Append, FileAccess.Write, FileShare.Read, bufferSize: _bufferSize, FileOptions.Asynchronous))
                {
                    await memoryStream.CopyToAsync(fileStream);
                }
            }
        }
    }
}
