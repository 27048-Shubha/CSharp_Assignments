using System.Text;

namespace Assignment15_FilesAndStream.Tasks
{
    public class BasicFileUsage
    {
        public static void Run()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "task3.txt");
            string data = "This is some test data";

            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] buffer = Encoding.ASCII.GetBytes(data);
                memoryStream.Write(buffer, 0, buffer.Length);

                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    byte[] writeBuffer = memoryStream.ToArray();
                    fileStream.Write(writeBuffer, 0, writeBuffer.Length);
                }
            }

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    for (int i = 0; i < bytesRead; i++)
                    {
                        Console.WriteLine(i);
                        Thread.Sleep(10);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
