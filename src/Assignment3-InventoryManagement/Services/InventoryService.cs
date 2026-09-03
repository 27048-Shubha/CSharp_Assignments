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
        /// <param name="name">Name of the products.</param>
        /// <param name="price">Price of the products.</param>
        /// <param name="stock">Stock Quantity of the products.</param>
        public void AddProduct(string name, decimal price, decimal stock)
        {
            if (price <= 0)
            {
                throw new ArgumentException("Invalid Input! Price must be a positive value.");
            }
            else if (stock < 0)
            {
                throw new ArgumentException("Invalid Input! Stock must be an non negative value.");
            }

            Product product = new Product(name, price, stock);
            this._repository.AddProduct(product);
        }

        /// <summary>
        /// Gets _products price from repository.
        /// </summary>
        /// <param name="pId">The id of the products.</param>
        /// <returns>The price of the products.</returns>
        public decimal GetProductPrice(Guid pId)
        {
            return this._repository.GetProductPrice(pId);
        }

        /// <summary>
        /// Gets stock of the products.
        /// </summary>
        /// <param name="pId">The id of the products.</param>
        /// <returns>The stock quanitity of the products.</returns>
        public decimal GetProductStock(Guid pId)
        {
            return this._repository.GetProductStock(pId);
        }

        /// <summary>
        /// Checks and Edits object to be stored in Product list.
        /// </summary>
        /// <param name="pId">Id of the products.</param>
        /// <param name="name">Name of the products.</param>
        /// <param name="price">Price of the products.</param>
        /// <param name="stock">Stock Quantity of the products.</param>
        public void EditProduct(Guid pId, string name, decimal price, decimal stock)
        {
            this.EditProductPrice(pId, price);
            this.EditStockQuantity(pId, stock);
        }

        /// <summary>
        /// Edits price of the products.
        /// </summary>
        /// <param name="pId">Product Id whose price to be edited.</param>
        /// <param name="price">New price value. </param>
        public void EditProductPrice(Guid pId, decimal price)
        {
            this._repository.UpdatePrice(pId, price);
        }

        /// <summary>
        /// Edits stock of the products.
        /// </summary>
        /// <param name="pId">Product Id whose price to be edited.</param>
        /// <param name="stock">New stock value. </param>
        public void EditStockQuantity(Guid pId, decimal stock)
        {
            this._repository.UpdateStock(pId, stock);
        }

        /// <summary>
        /// Gets Guid of the products and calls repo for deletion.
        /// </summary>
        /// <param name="name">Name of the products to be deleted.</param>
        public void RemoveProduct(string name)
        {
            Guid productId = this._repository.GetProductId(name);
            if (productId == Guid.Empty)
            {
                throw new NameNotFoundException("Product Name doesn't Exists");
            }
            else
            {
                this._repository.DeleteProduct(productId);
            }
        }

        /// <summary>
        /// Returns list of products in product list.
        /// </summary>
        /// <returns>List of products.</returns>
        public List<Product> ListProducts()
        {
            if (this.IsEmpty())
            {
                throw new EmptyInventoryException("Inventory is currently empty!");
            }
            else
            {
                return this._repository.ViewProducts();
            }
        }

        /// <summary>
        /// Calls repo to search for the products.
        /// </summary>
        /// <param name="name">Name of the products.</param>
        /// <returns>Product object holding details on _roducts to be searched.</returns>
        public List<Product> FindProduct(string name)
        {
            return this._repository.SearchProduct(name);
        }

        /// <summary>
        /// Checks if the products exists in the repository already.
        /// </summary>
        /// <param name="name">Name to be checked for existence.</param>
        /// <returns>True if exists else False.</returns>
        public bool IsExists(string name)
        {
            if (this._repository.GetProductId(name) == Guid.Empty)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Finds prodcut id based on the name.
        /// </summary>
        /// <param name="name">Name of the products whose Guid to be found.</param>
        /// <returns>Guid of the products.</returns>
        public Guid GetId(string name)
        {
            if (!this.IsExists(name))
            {
                throw new NameNotFoundException($"The {name} not found!");
            }

            Guid pId = this._repository.GetProductId(name);
            return pId;
        }

        /// <summary>
        /// Sorts _products list by name of the products.
        /// </summary>
        /// <returns>The sorted list of products.</returns>
        /// <exception cref="EmptyInventoryException">Thrown when inventory is empty. </exception>
        public List<Product> SortByName()
        {
            if (this.IsEmpty())
            {
                throw new EmptyInventoryException("Inventory is currently empty!");
            }
            else
            {
                List<Product> products = this.ListProducts();
                products.Sort((a, b) => a.Name.CompareTo(b.Name));
                return products;
            }
        }

        /// <summary>
        /// Sorts products list by _price of the products.
        /// </summary>
        /// <returns>The sorted list of products.</returns>
        /// <exception cref="EmptyInventoryException">Thrown when inventory is empty. </exception>
        public List<Product> SortByPrice()
        {
            if (this.IsEmpty())
            {
                throw new EmptyInventoryException("Inventory is currently empty!");
            }
            else
            {
                List<Product> products = this.ListProducts();
                products.Sort((a, b) => a.Price.CompareTo(b.Price));
                return products;
            }
        }

        /// <summary>
        /// Sorts _products list by stock quantity of the products.
        /// </summary>
        /// <returns>The sorted list of products.</returns>
        /// <exception cref="EmptyInventoryException">Thrown when inventory is empty. </exception>
        public List<Product> SortByStockQuantity()
        {
            if (this.IsEmpty())
            {
                throw new EmptyInventoryException("Inventory is currently empty!");
            }
            else
            {
                List<Product> products = this.ListProducts();
                products.Sort((a, b) => a.StockQuantity.CompareTo(b.StockQuantity));
                return products;
            }
        }

        /// <summary>
        /// Checks whether the list is empty.
        /// </summary>
        /// <returns>True if the list is empty, else False. </returns>
        public bool IsEmpty()
        {
            return this._repository.GetProductCount() == 0;
        }
    }
}