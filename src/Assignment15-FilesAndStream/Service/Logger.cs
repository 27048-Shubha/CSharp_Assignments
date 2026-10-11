namespace Assignment15_FilesAndStream.Service
{
    using System.Text;

    /// <summary>
    /// Demonstrates log operations.
    /// </summary>
    public class Logger
    {
        private static string _folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Task4");
        private static string _logFilePath = "log.txt";
        private static object _fileAccessLock = new object();

        /// <summary>
        /// Demonstrates error-ful code for log file demonstration.
        /// </summary>
        /// <param name="errorMessage">Error message.</param>
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

        /// <summary>
        /// Demonstrates error-less optimized code for log file demonstration.
        /// </summary>
        /// <param name="errorMessage">Error message to be displayed.</param>
        public static void LogErrorFree(string errorMessage)
        {
            using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append))
            {
                byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);
                fileStream.Write(errorBytes, 0, errorBytes.Length);
            }

            Console.WriteLine(errorMessage);
        }

        /// <summary>
        /// Demonstrates log file demonstration with lock.
        /// </summary>
        /// <param name="errorMessage">Error message to be displayed.</param>
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

        /// <summary>
        /// Demonstrates individual log file generation.
        /// </summary>
        /// <param name="errorMessage">Error message to be displayed.</param>
        public static void IndividualLogger(string errorMessage)
        {
            Directory.CreateDirectory(_folderPath);
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
