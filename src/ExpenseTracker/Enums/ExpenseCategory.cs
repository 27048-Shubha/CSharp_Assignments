namespace ExpenseTracker.Enums
{
    /// <summary>
    /// Represents the available categories for expense transactions.
    /// </summary>
    public enum ExpenseCategory
    {
        /// <summary>
        /// Represents expenses related to food.
        /// </summary>
        Food = 1,

        /// <summary>
        /// Represents expenses related to clothing.
        /// </summary>
        Clothing,

        /// <summary>
        /// Represents general shopping expenses.
        /// </summary>
        Shopping,

        /// <summary>
        /// Represents expenses for essential items.
        /// </summary>
        Essentials,

        /// <summary>
        /// Represents rental expenses.
        /// </summary>
        Rent,

        /// <summary>
        /// Represents expenses related to electronic gadgets.
        /// </summary>
        Gadgets,

        /// <summary>
        /// Represents expenses that do not belong to a predefined category.
        /// </summary>
        Others,
    }
}