namespace ExpenseTracker.Repository
{
    using ExpenseTracker.Enums;

    /// <summary>
    /// Represents transactions model for json type files.
    /// </summary>
    internal class JsonTransaction
    {
        /// <summary>
        /// Gets or sets the unique identifier of the transaction.
        /// </summary>
        /// <value>A globally unique identifier assigned when the transaction is created.</value>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// Gets or Sets the transaction display identifier.
        /// </summary>
        /// <value>An identifier generated for display and user reference.</value>
        public string TransactionId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        /// <value>The amount associated with the transaction.</value>
        public decimal Amount {get; set; } = decimal.Zero;

        /// <summary>
        /// Gets or sets the date of the transaction.
        /// </summary>
        /// <value>The transaction date.</value>
        public string Date { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the source of the income.
        /// </summary>
        /// <value>The income source category.</value>
        public IncomeSource Source
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total income value.
        /// </summary>
        /// <value>The total income entered.</value>
        public decimal TotalIncome
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets total expense value.
        /// </summary>
        /// <value>The total expense entered.</value>
        public decimal TotalExpense
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the category of the expense.
        /// </summary>
        /// <value>The expense category.</value>
        public ExpenseCategory Category
        {
            get; set;
        }

        /// <summary>
        /// Gets or Sets the transaction type identifier.
        /// </summary>
        /// <value>Type of the transaction</value>
        public string TransactionType { get; set; } = string.Empty;
    }
}