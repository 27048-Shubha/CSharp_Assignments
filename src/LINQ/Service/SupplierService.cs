namespace LINQ.Service
{
    using LINQ.Models;
    using LINQ.Repository;

    /// <summary>
    /// Provides business operations for managing suppliers.
    /// </summary>
    public class SupplierService
    {
        private readonly SupplierRepository _supplierRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierService"/> class.
        /// </summary>
        /// <param name="supplierRepository">The repository used for supplier data persistence.</param>
        internal SupplierService(SupplierRepository supplierRepository)
        {
            this._supplierRepository = supplierRepository;
        }

        /// <summary>
        /// Creates and stores a new supplier.
        /// </summary>
        /// <param name="supplierId">The unique identifier of the supplier.</param>
        /// <param name="supplierName">The supplier name.</param>
        /// <param name="productId">The identifier of the product supplied.</param>
        public void Add(int supplierId, Enums.SupplierName supplierName, int productId)
        {
            Supplier supplier = new Supplier()
            {
                SupplierId = supplierId,
                SupplierName = supplierName,
                ProductId = productId,
            };

            this._supplierRepository.Add(supplier);
        }

        /// <summary>
        /// Retrieves all suppliers.
        /// </summary>
        /// <returns>A read-only collection of suppliers.</returns>
        public IReadOnlyList<Supplier> GetAll()
        {
            return this._supplierRepository.GetAll();
        }

        /// <summary>
        /// Removes all supplier data from storage.
        /// </summary>
        public void ClearFile() => this._supplierRepository.ClearFile();
    }
}
