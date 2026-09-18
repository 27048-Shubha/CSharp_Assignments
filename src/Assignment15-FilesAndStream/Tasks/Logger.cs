using System.Text;

namespace Assignment15_FilesAndStream.Tasks
{
    public class Logger
    {
        private static string _folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Task4");
        private static string _logFilePath = "log.txt";
        private static object _fileAccessLock = new object();
        public static void LogError(string errorMessage)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);
                memoryStream.Write(errorBytes, 0, errorBytes.Length);

                using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append))
                {
                    memoryStream.WriteTo(fileStream);
                }
            }
            Console.WriteLine(errorMessage);
        }

        public static void LogErrorFree(string errorMessage)
        {
            using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append))
            {
                byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);
                fileStream.Write(errorBytes, 0, errorBytes.Length);
            }
            Console.WriteLine(errorMessage);
        }

        public static void LockLogger(string errorMessage)
        {
            lock (Logger._fileAccessLock)
            {
                using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append))
                {
                    byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);
                    fileStream.Write(errorBytes, 0, errorBytes.Length);
                }
                Console.WriteLine(errorMessage);
            }
        }

        public static void IndividualLogger(string errorMessage)
        {
            Directory.CreateDirectory(_folderPath);
            lock (Logger._fileAccessLock)
            {
                _logFilePath = Path.Combine(_folderPath, $"Log{System.Threading.Thread.CurrentThread.ManagedThreadId}.txt");
                using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append))
                {
                    byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);
                    fileStream.Write(errorBytes, 0, errorBytes.Length);
                }

                Console.WriteLine(errorMessage);
            }
        }
    }
}
