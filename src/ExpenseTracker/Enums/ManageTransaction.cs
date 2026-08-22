namespace ExpenseTracker.Enums
{
    /// <summary>
    /// Represents the operations available for managing transactions.
    /// </summary>
    internal enum ManageTransaction
    {
        /// <summary>
        /// Displays transactions belonging to the selected transaction type.
        /// </summary>
        View = 1,

        /// <summary>
        /// Updates an existing transaction.
        /// </summary>
        Update = 2,

        /// <summary>
        /// Deletes an existing transaction.
        /// </summary>
        Delete = 3,

        /// <summary>
        /// Returns to the previous menu.
        /// </summary>
        Back = 4,

        /// <summary>
        /// Indicates an invalid menu selection.
        /// </summary>
        Invalid,
    }
}