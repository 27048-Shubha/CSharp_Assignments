namespace Assignment15_FilesAndStream.Controller
{
    using Assignment15_FilesAndStream.Helper;
    using Assignment15_FilesAndStream.Service;

    public class SyncAsynController
    {
        private readonly SynchronousFileProcessor _syncFileProcessor;
        private readonly AsynchronousFileProcessor _asyncFileProcessor;

        internal SyncAsynController(SynchronousFileProcessor syncFileProcessor, AsynchronousFileProcessor asyncFileProcessor)
        {
            this._syncFileProcessor = syncFileProcessor;
            this._asyncFileProcessor = asyncFileProcessor;
        }

        public async Task ExecuteFileProcessingComparison()
        {
            Timer timer = new();
            timer.StartTimer();

            this.ExecuteSynchornousProcessing("source1.txt", "destination1.txt");
            this.ExecuteSynchornousProcessing("source2.txt", "destination2.txt");
            this.ExecuteSynchornousProcessing("source3.txt", "destination3.txt");

            timer.StopTimer();

            long timeTakenSync = timer.GetTimeTaken();
            Console.WriteLine($"Time take to read, process, write 3 files synchronously: {timeTakenSync} milliseconds\n");

            timer = new();
            timer.StartTimer();

            await this.ExecuteAsynchornousProcessing();

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

        private void ExecuteSynchornousProcessing(string sourcePath, string destinationPath)
        {
            this._syncFileProcessor.SourcePath = Path.Combine(AppContext.BaseDirectory, sourcePath);
            this._syncFileProcessor.DestinationPath = Path.Combine(AppContext.BaseDirectory, destinationPath);

            this._syncFileProcessor.ReadUsingFileStream();
            this._syncFileProcessor.ProcessAndWriteData();

            Console.WriteLine($"[Sync] Completed: {sourcePath} to {destinationPath}");
        }

        private async Task ExecuteAsynchornousProcessing()
        {
            Task task1 = this._asyncFileProcessor.CallAsync("source1.txt", "destination1.txt", "Task1");
            Task task2 = this._asyncFileProcessor.CallAsync("source2.txt", "destination2.txt", "Task2");
            Task task3 = this._asyncFileProcessor.CallAsync("source3.txt", "destination3.txt", "Task3");

            await Task.WhenAll(task1, task2, task3);
        }
    }
}
