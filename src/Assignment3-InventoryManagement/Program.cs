using Assignment3_InventoryManagement.Controllers;
using Assignment3_InventoryManagement.Repository;
using Assignment3_InventoryManagement.Services;
using Assignment3_InventoryManagement.Views;

namespace Assignments
{
    /// <summary>
    /// Start of the program & maintains functional dependency
    /// </summary>
    internal class Program
    {
        private static ConsoleView _view = new ConsoleView();
        private static ProductRepository _repo = new ProductRepository();
        private static InventoryService _service = new InventoryService(_repo);
        private static InventoryController _controller = new InventoryController(_view, _service);

        /// <summary>
        /// Serves as start of Execution, Calls controller.
        /// </summary>
        /// <param name="args">Command Line arguments.</param>
        public static void Main(string[] args)
        {
            _controller.Initialize();
        }
}
}