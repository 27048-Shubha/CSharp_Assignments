namespace Assignment3_InventoryManagement.Enums
{
    /// <summary>
    /// User Defined Exception when Inventory is found empty with no _products extended from Exception.
    /// </summary>
    internal enum SortMenuOptions
    {
        /// <summary>
        /// Represents sort option by _name.
        /// </summary>
        ByName = 1,

        /// <summary>
        /// Represents sort option by _price.
        /// </summary>
        ByPrice,

        /// <summary>
        /// Represents sort option by stock quantity.
        /// </summary>
        ByStockQuantity,

        /// <summary>
        /// Represents exit operation from the application.
        /// </summary>
        Exit,
    }
}