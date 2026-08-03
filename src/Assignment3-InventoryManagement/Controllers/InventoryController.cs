namespace Assignment3_InventoryManagement.Controllers
{
    using Assignment3_InventoryManagement.Enums;
    using Assignment3_InventoryManagement.Exceptions;
    using Assignment3_InventoryManagement.Models;
    using Assignment3_InventoryManagement.Services;
    using Assignment3_InventoryManagement.Views;

    /// <summary>
    /// Manages Initializaiton and Menu for Inventory System.
    /// </summary>
    public class InventoryController
    {
        private readonly ConsoleView view;
        private readonly InventoryService service;

        private int choice;
        private string name;
        private decimal price;
        private decimal stockQuantity = 0;

        private List<Product> products;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryController"/> class.
        /// </summary>
        /// <param name="view">Object for calling console operations.</param>
        /// <param name="service">Object for calling services.</param>
        public InventoryController(ConsoleView view, InventoryService service)
        {
            this.view = view;
            this.service = service;
        }

        /// <summary>
        /// Handles user menu operation calls.
        /// </summary>
        public void Initialize()
        {
            do
            {
                this.view.DisplayDash();
                this.view.DisplayMenu();
                this.view.GetUserChoice(out this.choice);
                switch ((MenuOptions)this.choice)
                {
                    case MenuOptions.Add:
                        this.AddProduct();
                        this.view.ClearConsole();
                        break;

                    case MenuOptions.Edit:
                        this.EditProduct();
                        this.view.ClearConsole();
                        break;

                    case MenuOptions.Delete:
                        this.DeleteProduct();
                        this.view.ClearConsole();
                        break;

                    case MenuOptions.View:
                        // View
                        this.ViewProducts();
                        this.view.ClearConsole();
                        break;

                    case MenuOptions.Search:
                        // Search By Name
                        this.GetProductByName();
                        this.view.ClearConsole();
                        break;

                    case MenuOptions.Exit:
                        this.view.DiplayExitMessage();
                        this.view.ClearConsole();
                        break;

                    default:
                        this.view.DisplayDefault();
                        this.view.ClearConsole();
                        break;
                }
            }
            while (this.choice != 6);
        }

        /// <summary>
        /// Adds new product to the product list.
        /// </summary>
        public void AddProduct()
        {
            this.view.GetProductName(out this.name);
            if (!this.view.GetProductPrice(out this.price))
            {
                this.view.DisplayInvalidInput("Invalid Input! Price must be a positive value.");
            }
            else if (!this.view.GetProductStock(out this.stockQuantity))
            {
                this.view.DisplayInvalidInput("Invalid Input! Stock must be an non negative value.");
            }
            else
            {
                try
                {
                    this.service.AddProduct(this.name, this.price, this.stockQuantity);
                    this.view.DisplaySuccess("Insertion");
                }
                catch (ArgumentException e)
                {
                    this.view.DisplayInvalidInput(e.Message);
                }
            }
        }

        /// <summary>
        /// Edits existing product fields.
        /// </summary>
        public void EditProduct()
        {
            this.view.DisplayMessage("Current inventory:");
            try
            {
                if (this.service.IsEmpty())
                {
                    throw new EmptyInventoryException("Inventory is currently empty!");
                }

                this.ViewProducts();
                this.view.DisplayMessage("Click enter to skip editing values");
                this.view.GetProductName(out this.name);
                Guid pId;
                try
                {
                    pId = this.service.GetId(this.name);
                    if (!this.view.GetProductPrice(out this.price) && (this.price == 0))
                    {
                        this.price = this.service.GetProductPrice(pId);
                    }

                    if (!this.view.GetProductStock(out this.stockQuantity))
                    {
                        this.stockQuantity = this.service.GetProductStock(pId);
                    }

                    this.service.EditProduct(pId, this.name, this.price, this.stockQuantity);
                    this.view.DisplaySuccess("Updation");
                }
                catch (NameNotFoundException e)
                {
                    this.view.DisplayMessage(e.Message);
                }
            }
            catch (EmptyInventoryException e)
            {
                this.view.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Deletes existing product from the product list.
        /// </summary>
        public void DeleteProduct()
        {
            this.view.GetProductName(out this.name);
            try
            {
                this.service.RemoveProduct(this.name);
                this.view.DisplaySuccess("Deletion");
            }
            catch (NameNotFoundException e)
            {
                this.view.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Sends product list to the view.
        /// </summary>
        public void ViewProducts()
        {
            try
            {
                this.products = this.service.ListProducts();
                this.view.DisplayProducts(this.products);
            }
            catch (EmptyInventoryException e)
            {
                this.view.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Gets product by name.
        /// </summary>
        public void GetProductByName()
        {
            this.view.GetProductName(out this.name);
            this.products = this.service.FindProduct(this.name);
            this.view.DisplayProducts(this.products);
        }

        /// <summary>
        /// Sorts product list by user's choice.
        /// </summary>
        /// <exception cref="EmptyInventoryException">Thrown when inventory is empty. </exception>
        public void SortProduct()
        {
            int sortChoice;
            this.view.DisplaySortMenu();
            this.view.GetUserChoice(out sortChoice);
            try
            {
                switch ((SortMenuOptions)sortChoice)
                {
                    case SortMenuOptions.ByName:
                        this.products = this.service.SortByName();
                        this.view.DisplayProducts(this.products);
                        break;

                    case SortMenuOptions.ByPrice:
                        this.products = this.service.SortByPrice();
                        this.view.DisplayProducts(this.products);
                        break;

                    case SortMenuOptions.ByStockQuantity:
                        this.products = this.service.SortByStockQuantity();
                        this.view.DisplayProducts(this.products);
                        break;

                    case SortMenuOptions.Exit:
                        break;

                    default:
                        this.view.DisplayDefault();
                        this.SortProduct();
                        break;
                }
            }
            catch (NameNotFoundException e)
            {
                this.view.DisplayMessage(e.Message);
            }
        }
    }
}
