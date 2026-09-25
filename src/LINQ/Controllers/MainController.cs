namespace LINQ.Controllers
{
    using LINQ.Service;

    /// <summary>
    /// Coordinates application startup, loads sample data, and initiates task execution.
    /// </summary>
    public class MainController
    {
        private readonly TaskController _taskController;
        private readonly ProductService _productService;
        private readonly SupplierService _supplierService;
        private readonly OrderService _orderService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainController"/> class.
        /// </summary>
        /// <param name="taskController">Controller responsible for executing tasks.</param>
        /// <param name="productService">Service used to manage products.</param>
        /// <param name="supplierService">Service used to manage suppliers.</param>
        /// <param name="orderService">Service used to manage orders.</param>
        internal MainController(TaskController taskController, ProductService productService, SupplierService supplierService, OrderService orderService)
        {
            this._taskController = taskController;
            this._productService = productService;
            this._supplierService = supplierService;
            this._orderService = orderService;
        }

        /// <summary>
        /// Loads seed data into the application and starts task execution.
        /// </summary>
        public void Initialize()
        {
            this.LoadData();
            this._taskController.RunTasks();
        }

        /// <summary>
        /// Loads sample products, suppliers, and orders into storage.
        /// </summary>
        public void LoadData()
        {
            // Products
            this._productService.ClearFile();
            this._productService.Add(1, "Mouse", 500, Enums.ProductCategory.Electronics);
            this._productService.Add(2, "Keyboard", 1200, Enums.ProductCategory.Electronics);
            this._productService.Add(3, "Monitor", 8000, Enums.ProductCategory.Electronics);
            this._productService.Add(4, "Headphones", 1500, Enums.ProductCategory.Audio);
            this._productService.Add(5, "Speaker", 2500, Enums.ProductCategory.Audio);
            this._productService.Add(6, "Webcam", 2000, Enums.ProductCategory.Electronics);
            this._productService.Add(7, "Laptop Stand", 900, Enums.ProductCategory.Accessories);
            this._productService.Add(8, "USB Drive", 700, Enums.ProductCategory.Storage);
            this._productService.Add(9, "Clean Code", 1500, Enums.ProductCategory.Books);
            this._productService.Add(10, "C# in Depth", 1200, Enums.ProductCategory.Books);
            this._productService.Add(11, "Design Patterns", 2000, Enums.ProductCategory.Books);
            this._productService.Add(12, "Refactoring", 1800, Enums.ProductCategory.Books);
            this._productService.Add(13, "The Pragmatic Programmer", 2200, Enums.ProductCategory.Books);

            // Suppliers
            this._supplierService.ClearFile();
            this._supplierService.Add(1, Enums.SupplierName.Logitech, 1);
            this._supplierService.Add(2, Enums.SupplierName.Zebronics, 2);
            this._supplierService.Add(3, Enums.SupplierName.HP, 3);
            this._supplierService.Add(4, Enums.SupplierName.Boat, 4);
            this._supplierService.Add(5, Enums.SupplierName.JBL, 5);
            this._supplierService.Add(6, Enums.SupplierName.Canon, 6);
            this._supplierService.Add(7, Enums.SupplierName.Lenovo, 7);
            this._supplierService.Add(8, Enums.SupplierName.Logitech, 8);
            this._supplierService.Add(9, Enums.SupplierName.HP, 9);
            this._supplierService.Add(10, Enums.SupplierName.Lenovo, 10);
            this._supplierService.Add(11, Enums.SupplierName.Canon, 11);
            this._supplierService.Add(12, Enums.SupplierName.Zebronics, 12);
            this._supplierService.Add(13, Enums.SupplierName.Logitech, 13);

            // Orders
            this._orderService.ClearFile();
            this._orderService.Add(1, "2026-08-11", Enums.OrderStatus.Processing);
            this._orderService.Add(2, "2026-08-12", Enums.OrderStatus.Shipped);
            this._orderService.Add(3, "2026-08-14", Enums.OrderStatus.Cancelled);
            this._orderService.Add(4, "2026-08-15", Enums.OrderStatus.Returned);
            this._orderService.Add(5, "2026-08-16", Enums.OrderStatus.Delivered);
            this._orderService.Add(6, "2026-08-18", Enums.OrderStatus.Delivered);
            this._orderService.Add(7, "2026-08-19", Enums.OrderStatus.Processing);
            this._orderService.Add(8, "2026-08-20", Enums.OrderStatus.Shipped);
            this._orderService.Add(9, "2026-08-21", Enums.OrderStatus.Delivered);
            this._orderService.Add(10, "2026-08-22", Enums.OrderStatus.Processing);
        }
    }
}
