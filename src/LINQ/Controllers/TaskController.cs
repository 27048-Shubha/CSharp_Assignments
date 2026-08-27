using LINQ.Models;
using LINQ.Models.DTOs;
using LINQ.Service;
using LINQ.Tasks;
using LINQ.Views;

namespace LINQ.Controllers
{
    public class TaskController
    {
        private IReadOnlyList<Product> _products;
        private IReadOnlyList<Supplier> _suppliers;
        private IReadOnlyList<Order> _orders;
        private ProductService _productService;
        private SupplierService _supplierService;
        private OrderService _orderService;
        private ConsoleView _console;

        internal TaskController(ProductService productService, SupplierService supplierService, OrderService orderService, ConsoleView console)
        {
            this._productService = productService;
            this._supplierService = supplierService;
            this._orderService = orderService;
            this._console = console;
        }

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

        public void LoadProducts() => this._products = this._productService.GetAll();

        public void LoadSuppliers() => this._suppliers = this._supplierService.GetAll();

        public void LoadOrders() => this._orders = this._orderService.GetAll();

        public void RunTask1()
        {
            Task1 task1 = new Task1();
            List<FilterProductsDTO> filteredProducts = task1.FilterProducts(this._products);
            this._console.Display(filteredProducts);
            List<FilterProductsDTO> sortedProducts = task1.SortProducts(filteredProducts);
            this._console.Display(sortedProducts);
            decimal average = task1.FindAverage(sortedProducts);
        }

        public void RunTask2()
        {
            Task2 task2 = new Task2();
            List<CategorySummaryDTO> filteredProducts = task2.FilterProducts(this._products);
            this._console.Display(filteredProducts);
            List<ProductSupplierInfoDTO> joinedInfo = task2.PerformInnerJoin(this._products, this._suppliers);
            this._console.Display(joinedInfo);
        }

        public void RunTask3()
        {
            Task3 task3 = new Task3();
            int secondHighestNumber = task3.FindSecondHighestNumber();
            this._console.Display(secondHighestNumber);
            List<PairDTO> joinedInfo = task3.UniquePairsAddUptoTarget();
            this._console.Display(joinedInfo);
        }

        public void RunTask4()
        {
            Task4 task4 = new Task4();
            List<Product> sortedProducts = task4.SortProduct(this._products);
            this._console.Display(sortedProducts);
            sortedProducts = task4.OptimizedSortProduct(this._products);
            this._console.Display(sortedProducts);
        }

        public void RunTask5()
        {
            QueryBuilder queryBuilder = new QueryBuilder();
            List<ProductSupplierInfoDTO> result = queryBuilder.Filter(p => p.Price > 500).SortBy(p => p.Price).Join((p, s) => p.Id == s.SupplierId).Execute();
            this._console.Display(result);
        }
    }
}
