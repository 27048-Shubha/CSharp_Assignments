namespace Assignment3_InventoryManagement.Services
{
    using Assignment3_InventoryManagement.Exceptions;
    using Assignment3_InventoryManagement.Models;
    using Assignment3_InventoryManagement.Repository;

    /// <summary>
    /// Manages CRUD calls to Repository.
    /// </summary>
    public class InventoryService
    {
        private readonly ProductRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class.
        /// </summary>
        /// <param name="repository">Object for calling repository for operations.</param>
        public InventoryService(ProductRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Creates object to be stored in Product list.
        /// </summary>
        /// <param name="name">Name of the product.</param>
        /// <param name="price">Price of the product.</param>
        /// <param name="stock">Stock Quantity of the product.</param>
        public void AddProduct(string name, decimal price, decimal stock)
        {
            // if product name, price, stock are valid
            Product product = new Product(name, price, stock);
            this.repository.AddProduct(product);
        }

        /// <summary>
        /// Gets product price from repository.
        /// </summary>
        /// <param name="pId">The id of the product.</param>
        /// <returns>The price of the product.</returns>
        public decimal GetProductPrice(Guid pId)
        {
            return this.repository.GetProductPrice(pId);
        }

        /// <summary>
        /// Gets stock of the product.
        /// </summary>
        /// <param name="pId">The id of the product.</param>
        /// <returns>The stock quanitity of the product.</returns>
        public decimal GetProductStock(Guid pId)
        {
            return this.repository.GetProductStock(pId);
        }

        /// <summary>
        /// Checks and Edits object to be stored in Product list.
        /// </summary>
        /// <param name="pId">Id of the product.</param>
        /// <param name="name">Name of the product.</param>
        /// <param name="price">Price of the product.</param>
        /// <param name="stock">Stock Quantity of the product.</param>
        public void EditProduct(Guid pId, string name, decimal price, decimal stock)
        {
            this.EditProductPrice(pId, price);
            this.EditStockQuantity(pId, stock);
        }

        /// <summary>
        /// Edits price of the product.
        /// </summary>
        /// <param name="pId">Product Id whose price to be edited.</param>
        /// <param name="price">New price value. </param>
        public void EditProductPrice(Guid pId, decimal price)
        {
            this.repository.UpdatePrice(pId, price);
        }

        /// <summary>
        /// Edits stock of the product.
        /// </summary>
        /// <param name="pId">Product Id whose price to be edited.</param>
        /// <param name="stock">New stock value. </param>
        public void EditStockQuantity(Guid pId, decimal stock)
        {
            this.repository.UpdateStock(pId, stock);
        }

        /// <summary>
        /// Gets Guid of the product and calls repo for deletion.
        /// </summary>
        /// <param name="name">Name of the product to be deleted.</param>
        public void RemoveProduct(string name)
        {
            Guid productId = this.repository.GetProductId(name);
            if (productId == Guid.Empty)
            {
                throw new NameNotFound("Product Name doesn't Exists");
            }
            else
            {
                this.repository.DeleteProduct(productId);
            }
        }

        /// <summary>
        /// Returns list of Products in Product list.
        /// </summary>
        /// <returns>List of Products.</returns>
        public List<Product> ListProducts()
        {
            return this.repository.ViewProducts();
        }

        /// <summary>
        /// Calls repo to search for the product.
        /// </summary>
        /// <param name="name">Name of the product.</param>
        /// <returns>Product object holding details on product to be searched.</returns>
        public List<Product> FindProduct(string name)
        {
            return this.repository.SearchProduct(name);
        }

        /// <summary>
        /// Checks if the product exists in the repo already.
        /// </summary>
        /// <param name="name">Name to be checked for existence.</param>
        /// <returns>True if exists else False.</returns>
        public bool IsExists(string name)
        {
            if (this.repository.GetProductId(name) == Guid.Empty)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Finds prodcut id based on the name.
        /// </summary>
        /// <param name="name">Name of the product whose Guid to be found.</param>
        /// <returns>Guid of the product.</returns>
        public Guid GetId(string name)
        {
            if (!this.IsExists(name))
            {
                throw new NameNotFound("Name Not Exists");
            }

            Guid pId = this.repository.GetProductId(name);
            return pId;
        }
    }
}