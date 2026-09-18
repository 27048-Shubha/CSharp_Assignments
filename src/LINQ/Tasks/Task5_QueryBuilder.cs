namespace LINQ.Tasks
{
    using System.Linq.Expressions;
    using LINQ.Models;
    using LINQ.Models.DTOs;

    /// <summary>
    /// Provides a fluent API for building product queries using filtering, sorting, and joining operations.
    /// </summary>
    public class Task5_QueryBuilder
    {
        private IReadOnlyList<Product> _products;
        private IReadOnlyList<Supplier> _suppliers;
        private IEnumerable<Product> _productQuery;
        private IEnumerable<Supplier> _supplierQuery;
        private IEnumerable<ProductSupplierInfoDTO> _productSupplierQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="Task5_QueryBuilder"/> class.
        /// </summary>
        /// <param name="products">The source product collection.</param>
        /// <param name="suppliers">The source supplier collection.</param>
        internal Task5_QueryBuilder(IReadOnlyList<Product> products, IReadOnlyList<Supplier> suppliers)
        {
            this._products = products;
            this._suppliers = suppliers;
            this._productQuery = this._products;
            this._supplierQuery = this._suppliers;
            this._productSupplierQuery = new List<ProductSupplierInfoDTO>();
        }

        /// <summary>
        /// Filters products based on the specified condition.
        /// </summary>
        /// <param name="predicate">The filter condition.</param>
        /// <returns>The current query builder instance.</returns>
        public Task5_QueryBuilder Filter(Func<Product, bool> predicate)
        {
            this._productQuery = this._productQuery.Where(predicate);
            return this;
        }

        /// <summary>
        /// Sorts products using the specified key selector.
        /// </summary>
        /// <typeparam name="TKey">The type of the sorting key.</typeparam>
        /// <param name="predicate">The key selector used for sorting.</param>
        /// <returns>The current query builder instance.</returns>
        public Task5_QueryBuilder SortBy<TKey>(Func<Product, TKey> predicate)
        {
            this._productQuery = this._productQuery.OrderBy(predicate);
            return this;
        }

        /// <summary>
        /// Joins products and suppliers using the specified condition.
        /// </summary>
        /// <param name="predicate">The join condition.</param>
        /// <returns>The current query builder instance.</returns>
        public Task5_QueryBuilder Join(Func<Product, Supplier, bool> predicate)
        {
            // Func<Product, Supplier, bool> joinCondition = predicate.Compile();
            this._productSupplierQuery = this._productQuery.SelectMany(
                    product => this._suppliers
                    .Where(supplier => predicate(product, supplier)), 
                    (product, supplier) => new ProductSupplierInfoDTO
                    {
                         ProductId = product.Id,
                         ProductName = product.Name,
                         SupplierId = supplier.SupplierId,
                         SupplierName = supplier.SupplierName,
                    });
            return this;
        }

        /// <summary>
        /// Executes the configured query and returns the results.
        /// </summary>
        /// <returns>A list containing product and supplier information.</returns>
        public List<ProductSupplierInfoDTO> Execute()
        {
            return this._productSupplierQuery.ToList();
        }
    }
}