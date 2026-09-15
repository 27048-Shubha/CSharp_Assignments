namespace Assignments
{
    using Assignment3_InventoryManagement.Controllers;
    using Assignment3_InventoryManagement.Repository;
    using Assignment3_InventoryManagement.Services;
    using Assignment3_InventoryManagement.Views;

    /// <summary>
    /// Application entry point and composition root.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Serves as start of execution, calls controller.
        /// </summary>
        public static void Main()
        {
            ConsoleView view = new ConsoleView();
            IProductRepository repository = new ProductRepository();
            InventoryService service = new InventoryService(repository, view);
            InventoryController controller = new InventoryController(service, view);

            controller.Run();
        }
    }
}