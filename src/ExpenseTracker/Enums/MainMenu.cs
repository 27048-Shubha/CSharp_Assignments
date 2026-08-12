namespace ExpenseTracker.Enums
{
    /// <summary>
    /// Represents the options available in the application's main menu.
    internal enum MainMenu
    {
        /// <summary>
        /// Allows the user to add a new transaction.
        /// </summary>
        Add = 1,

        /// <summary>
        /// Allows the user to manage existing transactions.
        /// </summary>
        Manage,

        /// <summary>
        /// Generates a financial summary.
        /// </summary>
        Summary,

        /// <summary>
        /// Exits the application.
        /// </summary>
        Exit,
    }
}
