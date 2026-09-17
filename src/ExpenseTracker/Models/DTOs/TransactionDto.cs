using ExpenseTracker.Enums;

namespace ExpenseTracker.Models.DTOs
{
    /// <summary>
    /// Represents transaction information for display purposes.
    /// </summary>
    internal class TransactionDto
    {
        /// <summary>
        /// Gets or sets the display identifier of the transaction.
        /// </summary>
        /// <value>
        /// A unique identifier generated for the transaction.
        /// </value>
        public string TransactionId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the monetary amount of the transaction.
        /// </summary>
        /// <value>
        /// The amount associated with the transaction.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the date of the transaction.
        /// </summary>
        /// <value>
        /// The date on which the transaction occurred.
        /// </value>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        /// <value>
        /// The transaction type, such as income or expense.
        /// </value>
        public TransactionType Type { get; set; }

        /// <summary>
        /// Gets or sets the expense category or income source.
        /// </summary>
        /// <value>
        /// A display-friendly description of the category or source.
        /// </value>
        public string CategoryOrSource { get; set; } = string.Empty;
    }
}