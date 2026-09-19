using System.Text;

namespace Assignment15_FilesAndStream.Service
{
    /// <summary>
    /// Demonstrates basic file usage.
    /// </summary>
    public class BasicFileUsage
    {
        /// <summary>
        /// Runs optimized code for file operations using stream.
        /// </summary>
        public static void Run()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "task3.txt");
            string data = "This is some test data";

            using (FileStream fileStream = new FileStream(path, FileMode.Create)) // Removal of MemoryStream
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data); // ASCII To UTF8
                fileStream.Write(buffer, 0, buffer.Length);
            }

            Console.WriteLine("Data inside the file: ");

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string text = Encoding.UTF8.GetString(buffer); // Removal ((char)buffer[i]);
                    Console.WriteLine(text);
                }
            }
        }
    }
}
