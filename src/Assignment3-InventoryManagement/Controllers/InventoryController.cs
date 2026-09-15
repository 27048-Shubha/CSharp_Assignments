namespace Assignment3_InventoryManagement.Controllers
{
    using Assignment3_InventoryManagement.Enums;
    using Assignment3_InventoryManagement.Exceptions;
    using Assignment3_InventoryManagement.Models;
    using Assignment3_InventoryManagement.Services;
    using Assignment3_InventoryManagement.Views;

    /// <summary>
    /// Coordinates user interaction flow between the console view and the inventory service.
    /// </summary>
    public class InventoryController
    {
        private readonly ConsoleView _view;
        private readonly InventoryService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryController"/> class.
        /// </summary>
        /// <param name="service">Object for calling services.</param>
        /// <param name="view">Object for calling console operations.</param>
        public InventoryController(InventoryService service, ConsoleView view)
        {
            this._service = service;
            this._view = view;
        }

        /// <summary>
        /// Handles user menu operation calls.
        /// </summary>
        public void Run()
        {
            int choice;

            while (true)
            {
                try
                {
                    this._view.DisplayMenu();
                    choice = this._view.GetUserChoice();

                    switch ((MenuOptions)choice)
                    {
                        case MenuOptions.Add:
                            this.AddProduct();
                            break;

                        case MenuOptions.Edit:
                            this.EditProduct();
                            break;

                        case MenuOptions.Delete:
                            this.DeleteProduct();
                            break;

                        case MenuOptions.View:
                            this.ViewProducts();
                            break;

                        case MenuOptions.Search:
                            this.GetProductByName();
                            break;

                        case MenuOptions.Sort:
                            this.SortProduct();
                            break;

                        case MenuOptions.Exit:
                            this._view.DiplayExitMessage();
                            return;

                        default:
                            this._view.DisplayDefault();
                            break;
                    }

                    this._view.PauseAndClear();
                }
                catch (NameNotFoundException exception)
                {
                    this._view.DisplayMessage(exception.Message);
                }
                catch (EmptyInventoryException exception)
                {
                    this._view.DisplayMessage(exception.Message);
                }
                catch (ArgumentException e)
                {
                    this._view.DisplayInvalidInput(e.Message);
                }
            }
        }

        private void AddProduct()
        {
            string name;
            decimal price;
            decimal stockQuantity = 0;

            this._view.GetProductName(out name);
            this._view.GetProductPrice(out price);
            this._view.GetProductStock(out stockQuantity);
            {
                this._service.AddProduct(name, price, stockQuantity);
                this._view.DisplaySuccess("Insertion");
            }
        }

        private void EditProduct()
        {
            string name;
            decimal price;
            decimal stockQuantity = 0;

            if (this._service.IsEmpty())
            {
                throw new EmptyInventoryException("Inventory is currently empty!");
            }

            this.ViewProducts();
            this._view.DisplaySkipMessage();
            this._view.GetProductName(out name);
            Guid pId = this._service.GetId(name);
            if (!this._view.GetProductPrice(out price) && (price == 0))
            {
                price = this._service.GetProductPrice(pId);
            }

            if (!this._view.GetProductStock(out stockQuantity))
            {
                stockQuantity = this._service.GetProductStock(pId);
            }

            this._service.EditProduct(pId, name, price, stockQuantity);
            this._view.DisplaySuccess("Updation");
        }

        private void DeleteProduct()
        {
            string name;

            if (this._service.IsEmpty())
            {
                throw new EmptyInventoryException("Inventory is currently empty!");
            }

            this._view.GetProductName(out name);
            this._service.RemoveProduct(name);
            this._view.DisplaySuccess("Deletion");
        }

        private void ViewProducts()
        {
            if (this._service.IsEmpty())
            {
                throw new EmptyInventoryException("Inventory is currently empty!");
            }

            List<Product> products = this._service.ListProducts();
            this._view.DisplayProducts(products);
        }

        private void GetProductByName()
        {
            string name;

            if (this._service.IsEmpty())
            {
                throw new EmptyInventoryException("Inventory is currently empty!");
            }

            this._view.GetProductName(out name);
            List<Product> products = this._service.FindProduct(name);
            this._view.DisplayProducts(products);
        }

        private void SortProduct()
        {
            List<Product> products;
            this._view.DisplaySortMenu();
            int sortChoice = this._view.GetUserChoice();
            switch ((SortMenuOptions)sortChoice)
            {
                case SortMenuOptions.ByName:
                    products = this._service.SortByName();
                    this._view.DisplayProducts(products);
                    break;

                case SortMenuOptions.ByPrice:
                    products = this._service.SortByPrice();
                    this._view.DisplayProducts(products);
                    break;

                case SortMenuOptions.ByStockQuantity:
                    products = this._service.SortByStockQuantity();
                    this._view.DisplayProducts(products);
                    break;

                case SortMenuOptions.Exit:
                    return;

                default:
                    this._view.DisplayDefault();
                    break;
            }
        }
    }
}
