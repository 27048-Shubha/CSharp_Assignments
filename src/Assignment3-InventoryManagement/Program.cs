namespace Assignments
{
    using Assignment3_InventoryManagement.Controllers;
    using Assignment3_InventoryManagement.Repository;
    using Assignment3_InventoryManagement.Services;
    using Assignment3_InventoryManagement.Views;

    /// <summary>
    /// Start of the program & maintains functional dependency.
    /// </summary>
    internal class Program
    {
        private static ConsoleView view = new ConsoleView();
        private static ProductRepository repo = new ProductRepository();
        private static InventoryService service = new InventoryService(repo);
        private static InventoryController controller = new InventoryController(view, service);

        /// <summary>
        /// Serves as start of Execution, Calls controller.
        /// </summary>
        /// <param name="args">Command Line arguments.</param>
        public static void Main(string[] args)
        {
            controller.Initialize();
        }
}
}