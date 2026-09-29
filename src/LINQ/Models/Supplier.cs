namespace LINQ.Models
{
    /// <summary>
    /// Represents a supplier associated with a product.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Gets or sets the supplier identifier.
        /// </summary>
        /// <value>Id of the supplier.</value>
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the supplier name.
        /// </summary>
        /// <value>Name of the supplier.</value>
        public Enums.SupplierName SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the product supplied.
        /// </summary>
        /// <value>Id of the product.</value>
        public int ProductId { get; set; }
    }
}
