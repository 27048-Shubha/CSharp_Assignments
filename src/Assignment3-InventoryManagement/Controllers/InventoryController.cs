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
                switch ((MenuOption)this.choice)
                {
                    case MenuOption.Add:
                        this.AddProduct();

                        break;

                    case MenuOption.Edit:
                        this.EditProduct();
                        break;

                    case MenuOption.Delete:
                        this.DeleteProduct();
                        break;

                    case MenuOption.View:
                        // View
                        this.ViewProducts();
                        break;

                    case MenuOption.Search:
                        // Search By Name
                        this.GetProductByName();
                        break;

                    case MenuOption.Exit:
                        this.view.DiplayExitMessage();
                        break;

                    default:
                        this.view.DisplayDefault();
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
                this.view.DisplayInvalidPrice();
            }
            else if (!this.view.GetProductStock(out this.stockQuantity))
            {
                this.view.DisplayInvalidStock();
            }
            else
            {
                this.service.AddProduct(this.name, this.price, this.stockQuantity);
                this.view.DisplaySuccess("Insertion");
            }
        }

        /// <summary>
        /// Edits existing product fields.
        /// </summary>
        public void EditProduct()
        {
            this.view.DisplayMessage("Current inventory:");
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
            catch
            {
                this.view.DisplayNameNotFound(this.name);
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
            catch (NameNotFound e)
            {
                this.view.DisplayMessage(e.Message);
            }
        }

        /// <summary>
        /// Sends product list to the view.
        /// </summary>
        public void ViewProducts()
        {
            this.products = this.service.ListProducts();
            this.view.DisplayProducts(this.products);
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
    }
}
