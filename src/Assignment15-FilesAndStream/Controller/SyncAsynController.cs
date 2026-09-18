using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment15_FilesAndStream.Controller
{
    internal class SyncAsynController
    {
        private async Task RunTask2()
        {
            Timer timer = new();
            timer.StartTimer();

            this.RunSyncFile("source1.txt", "destination1.txt");
            this.RunSyncFile("source2.txt", "destination2.txt");
            this.RunSyncFile("source3.txt", "destination3.txt");

            timer.StopTimer();

            long timeTakenSync = timer.GetTimeTaken();
            Console.WriteLine($"Time take to read, process, write 3 files synchronously: {timeTakenSync} milliseconds\n");

            timer = new();
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
