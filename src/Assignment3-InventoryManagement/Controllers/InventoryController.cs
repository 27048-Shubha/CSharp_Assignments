namespace Assignment3_InventoryManagement.Controllers
{
    using Assignment3_InventoryManagement.Exceptions;
    using Assignment3_InventoryManagement.Models;
    using Assignment3_InventoryManagement.Services;
    using Assignment3_InventoryManagement.Views;
    using System.Diagnostics;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    /// <summary>
    /// Manages Initializaiton and Menu for Inventory System.
    /// </summary>
    public class InventoryController
    {
        private readonly ConsoleView _view;
        private readonly InventoryService _service;
        int choice;
        string name;
        decimal price;
        decimal stockQuantity = 0;
        List<Product> products;

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
            do
            {
                _view.DisplayMenu();
                _view.GetUserChoice(out choice);
                switch (choice)
                {
                    case 1:
                        this.AddProduct();

                        break;

                    case 2:
                        this.EditProduct();
                        break;

                    case 3:
                        this.DeleteProduct();
                        break;

                    case 4:
                        // View
                        this.ViewProducts();
                        break;

                    case 5:
                        // Search By Name
                        this.GetProductByName();
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

        void AddProduct()
        {
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
        }

        void EditProduct()
        {
            _view.GetProductName(out name);
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
        }

        public void DeleteProduct()
        {
            _view.GetProductName(out name);
            try
            {
                _service.RemoveProduct(name);
                _view.DisplaySuccess("Deletion");
            }
            catch (NameNotFound e)
            {
                _view.DisplayMessage(e.Message);
            }

        }

        public void ViewProducts()
        {
            products = _service.ListProducts();
            _view.DisplayProducts(products);
        }

        public void GetProductByName()
        {
            _view.GetProductName(out name);
            products = _service.FindProduct(name);
            _view.DisplayProducts(products);
        }

    }
}
