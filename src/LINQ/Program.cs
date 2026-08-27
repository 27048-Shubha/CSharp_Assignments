using LINQ.Controllers;
using LINQ.Repository;
using LINQ.Service;
using LINQ.Views;

namespace Assignments
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleView console = new ConsoleView();

            ProductRepository productRepository = new ProductRepository();
            SupplierRepository supplierRepository = new SupplierRepository();
            OrderRepository orderRepository = new OrderRepository();

            ProductService productService = new ProductService(productRepository);
            SupplierService supplierService = new SupplierService(supplierRepository);
            OrderService orderService = new OrderService(orderRepository);

            TaskController taskController = new TaskController(productService, supplierService, orderService, console);

            MainController mainController = new MainController(taskController, productService, supplierService, orderService);
            mainController.Initialize();
        }
    }
}