namespace ExpenseTracker.Enums
{
    /// <summary>
    /// Represents the options available for searching transactions based on specific criteria.
    /// </summary>
    public enum SearchBy
    {
        /// <summary>
        /// Represents the option to search transactions by their unique identifier.
        /// </summary>
        TransactionId = 1,

        /// <summary>
        /// Represents the option to search transactions by their amount.
        /// </summary>
        IncomeSource,

        /// <summary>
        /// Represents the option to search transactions by their category.
        /// </summary>
        ExpenseCategory,

        /// <summary>
        /// Represents an invalid search option.
        /// </summary>
        Invalid,
    }
}