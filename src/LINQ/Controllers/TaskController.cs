namespace LINQ.Controllers
{
    using LINQ.Models;
    using LINQ.Models.DTOs;
    using LINQ.Service;
    using LINQ.Tasks;
    using LINQ.Views;

    /// <summary>
    /// Handles execution of all LINQ tasks and manages product, supplier, and order data retrieval.
    /// </summary>
    public class TaskController
    {
        private IReadOnlyList<Product> _products;
        private IReadOnlyList<Supplier> _suppliers;
        private IReadOnlyList<Order> _orders;
        private ProductService _productService;
        private SupplierService _supplierService;
        private OrderService _orderService;
        private ConsoleView _console;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="productService">Product data service.</param>
        /// <param name="supplierService">Supplier data service.</param>
        /// <param name="orderService">Order data service.</param>
        /// <param name="console">Console view used for user interaction.</param>
        internal TaskController(ProductService productService, SupplierService supplierService, OrderService orderService, ConsoleView console)
        {
            this._productService = productService;
            this._supplierService = supplierService;
            this._orderService = orderService;
            this._console = console;
        }

        /// <summary>
        /// Loads all required data and displays the task menu continuously.
        /// </summary>
        public void RunTasks()
        {
            this.LoadProducts();
            this._console.Display("Loaded products list successfully");
            this._console.Display(this._products);
            this._console.Continue();

            this.LoadSuppliers();
            this._console.Display("Loaded suppliers list successfully");
            this._console.Display(this._suppliers);
            this._console.Continue();

            this.LoadOrders();
            this._console.Display("Loaded orders list successfully");
            this._console.Display(this._orders);

            while (true)
            {
                this._console.Continue();
                Enums.TaskMenu choice = this._console.GetUserChoice();
                switch (choice)
                {
                    case Enums.TaskMenu.Task1:
                        this.RunTask1();
                        break;

                    case Enums.TaskMenu.Task2:
                        this.RunTask2();
                        break;

                    case Enums.TaskMenu.Task3:
                        this.RunTask3();
                        break;

                    case Enums.TaskMenu.Task4:
                        this.RunTask4();
                        break;

                    case Enums.TaskMenu.Task5:
                        this.RunTask5();
                        break;
                }
            }
        }

        /// <summary>
        /// Loads all products from the product service.
        /// </summary>
        public void LoadProducts() => this._products = this._productService.GetAll();

        /// <summary>
        /// Loads all suppliers from the supplier service.
        /// </summary>
        public void LoadSuppliers() => this._suppliers = this._supplierService.GetAll();

        /// <summary>
        /// Loads all orders from the order service.
        /// </summary>
        public void LoadOrders() => this._orders = this._orderService.GetAll();

        /// <summary>
        /// Filters electronics products, sorts them by price, and calculates the average price.
        /// </summary>
        public void RunTask1()
        {
            Task1 task1 = new Task1();
            List<FilterProductsDTO> filteredProducts = task1.FilterProducts(this._products);
            this._console.Display("\n=== Electronics Products (Price > 500) ===");
            this._console.Display(filteredProducts);

            List<FilterProductsDTO> sortedProducts = task1.SortProducts(filteredProducts);
            this._console.Display("\n=== Electronics Products Sorted By Price (Descending) ===");
            this._console.Display(sortedProducts);

            decimal average = task1.FindAverage(sortedProducts);
            this._console.Display("\n=== Average Price Of Electronics Products (Price > 500) ===");
            this._console.Display($"{average}");
        }

        /// <summary>
        /// Generates category summaries and performs an inner join between products and suppliers.
        /// </summary>
        public void RunTask2()
        {
            Task2 task2 = new Task2();
            List<CategorySummaryDTO> filteredProducts = task2.FilterProducts(this._products);
            this._console.Display("\n=== Category summary (Count & most expensive product) ===");
            this._console.Display(filteredProducts);

            List<ProductSupplierInfoDTO> joinedInfo = task2.PerformInnerJoin(this._products, this._suppliers);
            this._console.Display("\n=== Product-Supplier details (Inner join) ===");
            this._console.Display(joinedInfo);
        }

        /// <summary>
        /// Finds the second highest number and displays unique pairs whose sum matches the target value.
        /// </summary>
        public void RunTask3()
        {
            Task3 task3 = new Task3();

            int[] array = task3.GetArray();
            this._console.Display("\n=== Source array ===");
            this._console.Display(array);

            int secondHighestNumber = task3.FindSecondHighestNumber();
            this._console.Display("\n=== Second highest number in array ===");
            this._console.Display(secondHighestNumber);

            List<PairDTO> joinedInfo = task3.UniquePairsAddUptoTarget();
            this._console.Display("\n=== Unique pairs matching target sum ===");
            this._console.Display(joinedInfo);
        }

        /// <summary>
        /// Demonstrates sorting books by price using both standard and optimized LINQ queries.
        /// </summary>
        public void RunTask4()
        {
            Task4 task4 = new Task4(_console);

            List<Product> sortedProducts = task4.FilterFirstApproach(this._products);
            task4.NoLINQApproach(this._products);
            task4.ManualFilterThenQueryApproach(this._products);
            task4.LookUpBasedApproach(this._products);

            this._console.Display("\n=== Books sorted by price ===");
            this._console.Display(sortedProducts);
        }

        /// <summary>
        /// Demonstrates the custom QueryBuilder implementation using filtering, sorting, and joining operations.
        /// </summary>
        public void RunTask5()
        {
            Task5_QueryBuilder queryBuilder = new Task5_QueryBuilder(this._products, this._suppliers);
            this._console.Display("\n=== Demonstration of filtering, sorting, joining using custom query builder ===");

            this._console.Display("\n=== Filter products of price greater than 500 & Sort by price then perform join based on supplier id ===");
            List<ProductSupplierInfoDTO> result = queryBuilder.Filter(p => p.Price > 500).SortBy(p => p.Price).Join((p, s) => p.Id == s.SupplierId).Execute();
            this._console.Display($"");
            this._console.Display(result);

            this._console.Display("\n=== Filter products that starts with \"C\" & Sort by price then perform join based on supplier id ===");
            result = queryBuilder.Filter(p => p.Name.StartsWith("C")).SortBy(p => p.Price).Join((p, s) => p.Id == s.SupplierId).Execute();
            this._console.Display($"");
            this._console.Display(result);
        }
    }
}
