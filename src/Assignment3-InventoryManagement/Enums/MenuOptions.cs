namespace Assignment3_InventoryManagement.Enums
{
    /// <summary>
    /// Represents CRUD operation menu for inventory system.
    /// </summary>
    internal enum MenuOptions
    {
        /// <summary>
        /// Represents addition of the new _products.
        /// </summary>
        Add = 1,

        /// <summary>
        /// Represents updation of the existing _products.
        /// </summary>
        Edit,

        /// <summary>
        /// Reperesents deletion of the existing _products.
        /// </summary>
        Delete,

        /// <summary>
        /// Represents _view operation of all the _products.
        /// </summary>
        View,

        /// <summary>
        /// Represents search of a _products.
        /// </summary>
        Search,

        /// <summary>
        /// Represents exit operation from the application.
        /// </summary>
        Exit,
    }
}
