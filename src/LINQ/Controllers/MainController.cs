using LINQ.Service;

namespace LINQ.Controllers
{
    public class MainController
    {
        private readonly TaskController _taskController;
        private readonly ProductService _productService;
        private readonly SupplierService _supplierService;
        private readonly OrderService _orderService;

        internal MainController(TaskController taskController, ProductService productService, SupplierService supplierService, OrderService orderService)
        {
            this._taskController = taskController;
            this._productService = productService;
            this._supplierService = supplierService;
            this._orderService = orderService;
        }

        public void Initialize()
        {
            this.LoadData();
            this._taskController.RunTasks();
        }

        public void LoadData()
        {
            // Products

            _productService.Add(1, "Mouse", 500, Enums.ProductCategory.Electronics);
            _productService.Add(2, "Keyboard", 1200, Enums.ProductCategory.Electronics);
            _productService.Add(3, "Monitor", 8000, Enums.ProductCategory.Electronics);
            _productService.Add(4, "Headphones", 1500, Enums.ProductCategory.Audio);
            _productService.Add(5, "Speaker", 2500, Enums.ProductCategory.Audio);
            _productService.Add(6, "Webcam", 2000, Enums.ProductCategory.Electronics);
            _productService.Add(7, "Laptop Stand", 900, Enums.ProductCategory.Accessories);
            _productService.Add(8, "USB Drive", 700, Enums.ProductCategory.Storage);

            // Suppliers

            _supplierService.Add(1, Enums.SupplierName.Logitech, 1);
            _supplierService.Add(2, Enums.SupplierName.Zebronics, 2);
            _supplierService.Add(3, Enums.SupplierName.HP, 3);
            _supplierService.Add(4, Enums.SupplierName.Boat, 4);
            _supplierService.Add(5, Enums.SupplierName.JBL, 5);
            _supplierService.Add(6, Enums.SupplierName.Canon, 6);
            _supplierService.Add(7, Enums.SupplierName.Lenovo, 7);
            _supplierService.Add(8, Enums.SupplierName.Logitech, 8);

            // Orders

            _orderService.Add(1, "2026-08-11", Enums.OrderStatus.Processing);
            _orderService.Add(2, "2026-08-12", Enums.OrderStatus.Shipped);
            _orderService.Add(3, "2026-08-14", Enums.OrderStatus.Cancelled);
            _orderService.Add(4, "2026-08-15", Enums.OrderStatus.Returned);
            _orderService.Add(5, "2026-08-16", Enums.OrderStatus.Delivered);
            _orderService.Add(6, "2026-08-18", Enums.OrderStatus.Delivered);
            _orderService.Add(7, "2026-08-19", Enums.OrderStatus.Processing);
            _orderService.Add(8, "2026-08-20", Enums.OrderStatus.Shipped);
        }
    }
}
