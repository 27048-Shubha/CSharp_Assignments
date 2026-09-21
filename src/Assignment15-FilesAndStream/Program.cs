using Assignment15_FilesAndStream.Service;

namespace Assignments
{
    using Assignment15_FilesAndStream.Controller;
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
            try
            {
                TaskController taskController = new TaskController();
                taskController.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}