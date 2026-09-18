namespace Assignment15_FilesAndStream.Tasks
{
    using System.Diagnostics;
    using Assignment15_FilesAndStream.Helper;

    public class TaskController
    {
        private readonly FileDataProcessorSync _syncHandler;
        private readonly FileDataProcessorAsync _asyncHandler;

        internal TaskController()
        {
            this._syncHandler = new FileDataProcessorSync();
            this._asyncHandler = new FileDataProcessorAsync();
        }

        public void Run()
        {
            while (true)
            {
                switch (2)
                {
                    case 1:
                        this.RunTask1();
                        break;

                    case 2:
                        this.InitializeFiles();
                        this.RunTask2().GetAwaiter().GetResult();
                        return;

                    case 3:
                        break;

                    case 4:
                        break;

                    case 5:
                        return;

                    default:
                        break;
                }
            }
        }

        public void InitializeFiles()
        {
            this.GenerateFile("source1.txt", 1024 * 1024);
            this.GenerateFile("source2.txt", 1024 * 1024);
            this.GenerateFile("source3.txt", 1024 * 1024);
        }

        private void RunTask1()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "source.txt");
            if (!File.Exists(filePath))
            {
                this.GenerateFile(filePath, 1024 * 1024 * 1024);
            }

            Stopwatch stopwatch1 = Stopwatch.StartNew();
            this._syncHandler.ReadUsingFileStream();
            stopwatch1.Stop();
            Console.WriteLine($"Time taken to read using file stream: {stopwatch1.ElapsedMilliseconds} milliseconds");

            Stopwatch stopwatch2 = Stopwatch.StartNew();
            this._syncHandler.ReadUsingBufferedStream();
            stopwatch2.Stop();
            Console.WriteLine($"Time taken to read using buffered stream: {stopwatch2.ElapsedMilliseconds} milliseconds");

            this._syncHandler.ProcessAndWriteData();
        }

        private void GenerateFile(string sourcePath, long targetSize)
        {
            if (!File.Exists(sourcePath))
            {
                using StreamWriter writer = new StreamWriter(sourcePath);
                Random random = new Random();
                int size = 0;

                while (size < targetSize)
                {
                    char randomCharacter = (char)random.Next('a', 'z' + 1);
                    writer.Write(randomCharacter);
                    size++;
                }
            }
        }

        private async Task RunTask2()
        {
            Timer timer = new ();
            timer.StartTimer();

            this.RunSyncFile("source1.txt", "destination1.txt");
            this.RunSyncFile("source2.txt", "destination2.txt");
            this.RunSyncFile("source3.txt", "destination3.txt");

            timer.StopTimer();

            long timeTakenSync = timer.GetTimeTaken();
            Console.WriteLine($"Time take to read, process, write 3 files synchronously: {timeTakenSync} milliseconds\n");

            timer = new ();
            timer.StartTimer();

            await this.RunAsyncFile();

            timer.StopTimer();

            long timeTakenAsync = timer.GetTimeTaken();
            Console.WriteLine($"Time take to read, process, write 3 files asynchronously: {timeTakenAsync} milliseconds");

            if (timeTakenAsync < timeTakenSync)
            {
                Console.WriteLine("Asynchronous file processing is faster than Synchronous file processing");
            }
            else
            {
                Console.WriteLine("Synchronous file processing is faster than Asynchronous file processing");
            }
        }

        private void RunSyncFile(string sourcePath, string destinationPath)
        {
            this._syncHandler.SourcePath = Path.Combine(AppContext.BaseDirectory, sourcePath);
            this._syncHandler.DestinationPath = Path.Combine(AppContext.BaseDirectory, destinationPath);

            this._syncHandler.ReadUsingFileStream();
            this._syncHandler.ProcessAndWriteData();

            Console.WriteLine($"[Sync] Completed: {sourcePath} to {destinationPath}");
        }

        private async Task RunAsyncFile()
        {
            Task task1 = this._asyncHandler.CallAsync("source1.txt", "destination1.txt", "Task1");
            Task task2 = this._asyncHandler.CallAsync("source2.txt", "destination2.txt", "Task2");
            Task task3 = this._asyncHandler.CallAsync("source3.txt", "destination3.txt", "Task3");

            await Task.WhenAll(task1, task2, task3);
        }
    }
}