namespace LINQ.Service
{
    using LINQ.Models;
    using LINQ.Repository;

    /// <summary>
    /// Provides business operations for managing products.
    /// </summary>
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepository">The repository used for product data persistence.</param>
        internal ProductService(ProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        /// <summary>
        /// Creates and stores a new product.
        /// </summary>
        /// <param name="productId">The unique identifier of the product.</param>
        /// <param name="productName">The name of the product.</param>
        /// <param name="productPrice">The price of the product.</param>
        /// <param name="category">The category of the product.</param>
        public void Add(int productId, string productName, int productPrice, Enums.ProductCategory category)
        {
            Product product = new Product()
            {
                Id = productId,
                Name = productName,
                Price = productPrice,
                Category = category,
            };

            this._productRepository.Add(product);
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        /// <returns>A read-only collection of products.</returns>
        public IReadOnlyList<Product> GetAll()
        {
            return this._productRepository.GetAll();
        }

        /// <summary>
        /// Removes all product data from storage.
        /// </summary>
        public void ClearFile() => this._productRepository.ClearFile();
    }
}
