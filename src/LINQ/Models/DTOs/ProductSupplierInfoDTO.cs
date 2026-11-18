namespace LINQ.Models.DTOs
{
    /// <summary>
    /// Represents combined product and supplier information.
    /// </summary>
    public class ProductSupplierInfoDTO
    {
        /// <summary>
        /// Gets or sets the product identifier.
        /// </summary>
        /// <value>Id of the product.</value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        /// <value>Name of the product.</value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product price.
        /// </summary>
        /// <value>Price of the product.</value>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Gets or sets the product category.
        /// </summary>
        /// <value>Category of the produdct.</value>
        public Enums.ProductCategory ProductCategory { get; set; }

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
    }
}
