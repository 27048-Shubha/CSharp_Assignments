namespace ExpenseTracker.Enums
{
    /// <summary>
    /// Represents the possible sources of income for a transaction.
    /// </summary>
    internal enum IncomeSource
    {
        /// <summary>
        /// Represents income received from the primary income source.
        /// </summary>
        MainSource = 1,

        /// <summary>
        /// Represents additional income received as a bonus.
        /// </summary>
        Bonus,

        /// <summary>
        /// Represents money received as pocket money.
        /// </summary>
        PocketMoney,

        /// <summary>
        /// Represents income received from an unspecified source.
        /// </summary>
        Others
    }
}
