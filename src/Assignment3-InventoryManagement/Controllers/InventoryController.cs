namespace Assignment3_InventoryManagement.Controllers
{
    using Assignment3_InventoryManagement.Enums;
    using Assignment3_InventoryManagement.Exceptions;
    using Assignment3_InventoryManagement.Models;
    using Assignment3_InventoryManagement.Services;
    using Assignment3_InventoryManagement.Views;

    /// <summary>
    /// Manages initializaiton and menu for inventory system.
    /// </summary>
    public class InventoryController
    {
        private readonly ConsoleView _view;
        private readonly InventoryService _service;

        private int _choice;
        private string _name;
        private decimal _price;
        private decimal _stockQuantity = 0;

        private List<Product> _products;

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
            try
            {
                do
                {
                    this._view.DisplayMenu();
                    this._view.GetUserChoice(out this._choice);
                    switch ((MenuOptions)this._choice)
                    {
                        case MenuOptions.Add:
                            this.AddProduct();
                            this._view.ClearConsole();
                            break;

                        case MenuOptions.Edit:
                            this.EditProduct();
                            this._view.ClearConsole();
                            break;

                        case MenuOptions.Delete:
                            this.DeleteProduct();
                            this._view.ClearConsole();
                            break;

                        case MenuOptions.View:
                            // View
                            this.ViewProducts();
                            this._view.ClearConsole();
                            break;

                        case MenuOptions.Search:
                            // Search By Name
                            this.GetProductByName();
                            this._view.ClearConsole();
                            break;

                        case MenuOptions.Exit:
                            this._view.DiplayExitMessage();
                            this._view.ClearConsole();
                            break;

                        default:
                            this._view.DisplayDefault();
                            this._view.ClearConsole();
                            break;
                    }
                }
                while (this._choice != 6);
            }
            catch (NameNotFoundException exception)
            {
                this._view.DisplayMessage(exception.Message);
            }
            catch (EmptyInventoryException exception)
            {
                this._view.DisplayMessage(exception.Message);
            }
            catch (Exception exception)
            {
                this._view.DisplayMessage(exception.Message);
            }
        }

        /// <summary>
        /// Adds new products to the products list.
        /// </summary>
        public void AddProduct()
        {
            this._view.GetProductName(out this._name);
            if (!this._view.GetProductPrice(out this._price))
            {
                this._view.DisplayInvalidInput("Invalid Input! Price must be a positive value.");
            }
            else if (!this._view.GetProductStock(out this._stockQuantity))
            {
                this._view.DisplayInvalidInput("Invalid Input! Stock must be an non negative value.");
            }
            else
            {
                try
                {
                    this._service.AddProduct(this._name, this._price, this._stockQuantity);
                    this._view.DisplaySuccess("Insertion");
                }
                catch (ArgumentException e)
                {
                    this._view.DisplayInvalidInput(e.Message);
                }
            }
        }

        /// <summary>
        /// Edits existing products fields.
        /// </summary>
        public void EditProduct()
        {
            if (this._service.IsEmpty())
            {
                throw new EmptyInventoryException("Inventory is currently empty!");
            }

            this._view.DisplayMessage("Current inventory:");
            try
            {
                this.ViewProducts();
                this._view.DisplayMessage("Click enter to skip editing values");
                this._view.GetProductName(out this._name);
                Guid pId;
                try
                {
                    pId = this._service.GetId(this._name);
                    if (!this._view.GetProductPrice(out this._price) && (this._price == 0))
                    {
                        this._price = this._service.GetProductPrice(pId);
                    }

                    if (!this._view.GetProductStock(out this._stockQuantity))
                    {
                        this._stockQuantity = this._service.GetProductStock(pId);
                    }

                    this._service.EditProduct(pId, this._name, this._price, this._stockQuantity);
                    this._view.DisplaySuccess("Updation");
                }
                catch (NameNotFoundException e)
                {
                    this._view.DisplayMessage(e.Message);
                }
            }
            catch (EmptyInventoryException e)
            {
                this._view.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Deletes existing products from the products list.
        /// </summary>
        public void DeleteProduct()
        {
            if (this._service.IsEmpty())
            {
                throw new EmptyInventoryException("Inventory is currently empty!");
            }

            this._view.GetProductName(out this._name);
            try
            {
                this._service.RemoveProduct(this._name);
                this._view.DisplaySuccess("Deletion");
            }
            catch (NameNotFoundException e)
            {
                this._view.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Sends products list to the view.
        /// </summary>
        public void ViewProducts()
        {
            try
            {
                if (this._service.IsEmpty())
                {
                    throw new EmptyInventoryException("Inventory is currently empty!");
                }

                this._products = this._service.ListProducts();
                this._view.DisplayProducts(this._products);
            }
            catch (EmptyInventoryException e)
            {
                this._view.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Gets products by name.
        /// </summary>
        public void GetProductByName()
        {
            if (this._service.IsEmpty())
            {
                this._view.DisplayEmpty();
                return;
            }

            this._view.GetProductName(out this._name);
            this._products = this._service.FindProduct(this._name);
            this._view.DisplayProducts(this._products);
        }

        /// <summary>
        /// Sorts products list by user's choice.
        /// </summary>
        public void SortProduct()
        {
            int sortChoice;
            this._view.DisplaySortMenu();
            this._view.GetUserChoice(out sortChoice);
            try
            {
                switch ((SortMenuOptions)sortChoice)
                {
                    case SortMenuOptions.ByName:
                        this._products = this._service.SortByName();
                        this._view.DisplayProducts(this._products);
                        break;

                    case SortMenuOptions.ByPrice:
                        this._products = this._service.SortByPrice();
                        this._view.DisplayProducts(this._products);
                        break;

                    case SortMenuOptions.ByStockQuantity:
                        this._products = this._service.SortByStockQuantity();
                        this._view.DisplayProducts(this._products);
                        break;

                    case SortMenuOptions.Exit:
                        break;

                    default:
                        this._view.DisplayDefault();
                        this.SortProduct();
                        break;
                }
            }
            catch (NameNotFoundException e)
            {
                this._view.DisplayMessage(e.Message);
            }
        }
    }
}
