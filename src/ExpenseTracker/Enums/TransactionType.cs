namespace ExpenseTracker.Enums
{
    /// <summary>
    /// Represents the type of a financial transaction.
    /// </summary>
    internal enum TransactionType
    {
        /// <summary>
        /// Represents money received by the user.
        /// </summary>
        Income = 1,

        /// <summary>
        /// Represents money spent by the user.
        /// </summary>
        Expense = 2,

        /// <summary>
        /// Indicates an invalid transaction type.
        /// </summary>
        Invalid = 4,
    }
}