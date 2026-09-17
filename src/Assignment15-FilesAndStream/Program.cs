using Assignment15_FilesAndStream.Tasks;

namespace Assignments
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            //Task1_FileDataProcessor task1 = new Task1_FileDataProcessor();
            //task1.Run();

            Task2_AsyncFileDataProcessor task2 = new Task2_AsyncFileDataProcessor();
            await task2.RunTasks();
        }
    }
}