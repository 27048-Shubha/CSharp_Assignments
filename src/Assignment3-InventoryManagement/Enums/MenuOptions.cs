namespace Assignment3_InventoryManagement.Enums
{
    /// <summary>
    /// Represents CRUD operation menu for inventory system.
    /// </summary>
    internal enum MenuOptions
    {
        /// <summary>
        /// Represents addition of the new product.
        /// </summary>
        Add = 1,

        /// <summary>
        /// Represents updation of the existing product.
        /// </summary>
        Edit,

        /// <summary>
        /// Reperesents deletion of the existing product.
        /// </summary>
        Delete,

        /// <summary>
        /// Represents view operation of all the products.
        /// </summary>
        View,

        /// <summary>
        /// Represents search of a product.
        /// </summary>
        Search,

        /// <summary>
        /// Represents exit operation from the application.
        /// </summary>
        Exit,
    }
}
