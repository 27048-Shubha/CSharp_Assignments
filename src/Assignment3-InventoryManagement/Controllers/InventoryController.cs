namespace Assignment3_InventoryManagement.Controllers
{
    using Assignment3_InventoryManagement.Models;
    using Assignment3_InventoryManagement.Services;
    using Assignment3_InventoryManagement.Views;

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
            int choice;
            string name;
            decimal price;
            int editMode = 0;
            decimal stockQuantity = 0;
            List<Product> products;

            do
            {
                _view.DisplayMenu();
                _view.GetUserChoice(out choice);
                switch (choice)
                {
                    case 1:
                        _view.GetProductName(out name);
                        if (!_view.GetProductPrice(out price))
                        {
                            _view.DisplayInvalidPrice();
                        }
                        else if (!_view.GetProductStock(out stockQuantity))
                        {
                            _view.DisplayInvalidStock();
                        }
                        else
                        {
                            _service.AddProduct(name, price, stockQuantity);
                            _view.DisplaySuccess("Insertion");
                        }

                        break;

                    case 2:
                        _view.GetProductName(out name);
                        editMode = 1;
                        Guid pId;
                        try
                        {
                            pId = _service.GetId(name);
                            if (!_view.GetProductPrice(out price) && (price == 0))
                            {
                                price = _service.GetProductPrice(pId);
                            }
                            if (!_view.GetProductStock(out stockQuantity))
                            {
                                stockQuantity = _service.GetProductStock(pId);
                            }
                            _service.EditProduct(pId, name, price, stockQuantity);
                            _view.DisplaySuccess("Updation");

                        }
                        catch
                        {
                            _view.DisplayNameNotFound(name);
                        }
                        break;

                    case 3:
                        // Delete
                        _view.GetProductName(out name);
                        try
                        {
                            _service.RemoveProduct(name);
                            _view.DisplaySuccess("Deletion");
                        }
                        catch (Exception e)
                        {
                            _view.DisplayMessage(e.Message);
                        }

                        break;

                    case 4:
                        // View
                        products = _service.ListProducts();
                        _view.DisplayProducts(products);
                        break;

                    case 5:
                        // Search By Name
                        _view.GetProductName(out name);
                        products = _service.FindProduct(name);
                        _view.DisplayProducts(products);
                        break;

                    case 6:
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
