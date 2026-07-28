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
        private readonly ProductRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class.
        /// </summary>
        /// <param name="repository">Object for calling repository for operations.</param>
        public InventoryService(ProductRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Creates object to be stored in Product list.
        /// </summary>
        /// <param name="name">Name of the product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="stock">Stock Quantity of the product</param>
        public void AddProduct(string name, decimal price, int stock)
        {
            // if product name, price, stock are valid
            Product product = new Product(name, price, stock);
            _repository.AddProduct(product);
        }

        /// <summary>
        /// Checks and Edits object to be stored in Product list.
        /// </summary>
        /// <param name="name">Name of the product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="stock">Stock Quantity of the product</param>
        public void EditProduct(string name, decimal price, int stock)
        {
            if (!this.IsExists(name))
            {
                throw new Exception("Name Not Exists");
            }

            Guid pId = _repository.GetProductId(name);
            this.EditProductPrice(pId, price);
            this.EditStockQuantity(pId, stock);
        }

        /// <summary>
        /// Edits price of the product
        /// </summary>
        /// <param name="pId">Product Id whose price to be edited</param>
        /// <param name="price">New price value </param>
        public void EditProductPrice(Guid pId, decimal price)
        {
            _repository.UpdatePrice(pId, price);
        }

        /// <summary>
        /// Edits stock of the product
        /// </summary>
        /// <param name="pId">Product Id whose price to be edited</param>
        /// <param name="stock">New stock value </param>
        public void EditStockQuantity(Guid pId, int stock)
        {
            _repository.UpdateStock(pId, stock);
        }
        /// <summary>
        /// Gets Guid of the product and calls repo for deletion
        /// </summary>
        /// <param name="name">Name of the product to be deleted.</param>
        public void RemoveProduct(string name)
        {
            Guid productId = _repository.GetProductId(name);
            if (productId == Guid.Empty)
            {
                throw new NameNotFound("Product Name doesn't Exists");
            }
            else
            {
                _repository.DeleteProduct(productId);
            }
        }

        /// <summary>
        /// Returns list of Products in Product list.
        /// </summary>
        /// <returns>List of Products</returns>
        public List<Product> ListProducts()
        {
            return _repository.ViewProducts();
        }

        /// <summary>
        /// Calls repo to search for the product.
        /// </summary>
        /// <param name="name">Name of the product.</param>
        /// <returns>Product object holding details on product to be searched.</returns>
        public List<Product> FindProduct(string name)
        {
            return _repository.SearchProduct(name);
        }

        /// <summary>
        /// Checks if the product exists in the repo already
        /// </summary>
        /// <param name="name">Name to be checked for existence</param>
        /// <returns>True if exists else False</returns>
        public bool IsExists(string name)
        {
            if (_repository.GetProductId(name) == Guid.Empty)
            {
                return false;
            }

            return true;
        }
    }
}