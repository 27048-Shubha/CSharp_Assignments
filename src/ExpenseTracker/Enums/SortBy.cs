namespace ExpenseTracker.Enums
{
    /// <summary>
    /// Represents the options available for sorting transactions based on specific criteria.
    /// </summary>
    public enum SortBy
    {
        /// <summary>
        /// Represents the option to sort transactions by their unique identifier.
        /// </summary>
        TransactionId = 1,

        /// <summary>
        /// Represents the option to sort transactions by their amount.
        /// </summary>
        Amount,

        /// <summary>
        /// Represents the option to sort transactions by their date.
        /// </summary>
        Date,

        /// <summary>
        /// Represents the option to sort transactions by their type (income or expense).
        /// </summary>
        Income,

        /// <summary>
        /// Represents the option to sort transactions by their expense type.
        /// </summary>
        Expense,

        /// <summary>
        /// Represents an invalid sort option.
        /// </summary>
        Invalid,
    }
}