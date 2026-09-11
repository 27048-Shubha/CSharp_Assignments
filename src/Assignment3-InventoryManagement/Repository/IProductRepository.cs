namespace Assignment3_InventoryManagement.Repository
{
    using Assignment3_InventoryManagement.Models;

    /// <summary>
    /// Interface that holds products operations.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Inserts new products.
        /// </summary>
        /// <param name="product">Product object holding user input.</param>
        public void Add(Product product);

        /// <summary>
        /// Updates _price of the products.
        /// </summary>
        /// <param name="pId">Guid of the products to be updated.</param>
        /// <param name="price">New Price to be updated.</param>
        public void UpdatePrice(Guid pId, decimal price);

        /// <summary>
        /// Updates stock quantity of the products.
        /// </summary>
        /// <param name="pId">Guid of the products to be updated.</param>
        /// <param name="stock">New stock value to be updated.</param>
        public void UpdateStock(Guid pId, decimal stock);

        /// <summary>
        /// Deletes existing _products.
        /// </summary>
        /// <param name="productId">Guid of the products to be deleted.</param>
        public void Delete(Guid productId);

        /// <summary>
        /// Lists list of all products.
        /// </summary>
        /// <returns>Returns clone copy of products.</returns>
        public List<Product> ViewAll();

        /// <summary>
        /// Search for the products based on the name.
        /// </summary>
        /// <param name="name">Details of the products.</param>
        /// <returns>Returns products details in the cloned copy.</returns>
        public List<Product> SearchByName(string name);

        /// <summary>
        /// Finds prodcut id based on the name.
        /// </summary>
        /// <param name="name">Name of the products whose Guid to be found.</param>
        /// <returns>Guid of the products.</returns>
        public Guid GetId(string name);
    }
}