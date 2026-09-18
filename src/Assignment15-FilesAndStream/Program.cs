using Assignment15_FilesAndStream.Service;

namespace Assignments
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            TaskController taskController = new TaskController();
            taskController.Run();
        }
    }
}