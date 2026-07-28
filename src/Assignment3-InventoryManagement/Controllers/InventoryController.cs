using Assignment3_InventoryManagement.Models;
using Assignment3_InventoryManagement.Services;
using Assignment3_InventoryManagement.Views;

namespace Assignment3_InventoryManagement.Controllers
{
    /// <summary>
    /// Manages Initializaiton and Menu for Inventory System.
    /// </summary>
    public class InventoryController
    {
        private readonly ConsoleView _view;
        private readonly InventoryService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryController"/> class.
        /// </summary>
        /// <param name="view">Object for calling console operations.</param>
        /// <param name="service">Object for calling services.</param>
        public InventoryController(ConsoleView view, InventoryService service)
        {
            this._view = view;
            this._service = service;
        }

        /// <summary>
        /// Handles user menu operation calls.
        /// </summary>
        public void Initialize()
        {
            _view.DisplayMenu();

            int choice = _view.GetUserChoice();
            string name;
            do
            {
                switch (choice)
                {
                    case '1':
                        name = _view.GetProductName();
                        decimal price = _view.GetProductPrice();
                        int stock = _view.GetProductStock();
                        _service.AddProduct(name, price, stock);
                        break;
                    case '2':
                        //Edit
                        break;
                    case '3':
                        //Delete
                        name = _view.GetProductName();
                        _service.RemoveProduct(name);
                        break;
                    case '4':
                        //View
                        List<Product> products = _service.ListProducts();
                        _view.DisplayProducts(products);
                        break;
                    case '5':
                        //Search By Name
                        name = _view.GetProductName();
                        Product product = _service.FindProduct(name);
                        break;

                    default:
                        _view.DisplayDefault();
                        break;
                }
            }
            while (choice != 6);
        }
    }
}
