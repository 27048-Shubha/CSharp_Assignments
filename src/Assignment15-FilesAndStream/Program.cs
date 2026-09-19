using Assignment15_FilesAndStream.Service;

namespace Assignments
{
    /// <summary>
    /// Manages entry point of the application
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// </summary>
        /// <returns>Task representing asynchronous operation.</returns>
        public static async Task Main()
        {
            TaskController taskController = new TaskController();
            taskController.Run();
        }
    }
}