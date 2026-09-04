namespace Assignment3_InventoryManagement.Enums
{
    /// <summary>
    /// Represents CRUD operation menu for inventory system.
    /// </summary>
    internal enum MenuOptions
    {
        /// <summary>
        /// Represents addition of the new products.
        /// </summary>
        Add = 1,

        /// <summary>
        /// Represents updation of the existing products.
        /// </summary>
        Edit,

        /// <summary>
        /// Reperesents deletion of the existing products.
        /// </summary>
        Delete,

        /// <summary>
        /// Represents view operation of all the products.
        /// </summary>
        View,

        /// <summary>
        /// Represents search of a products.
        /// </summary>
        Search,

        /// <summary>
        /// Represents exit operation from the application.
        /// </summary>
        Exit,
    }
}
