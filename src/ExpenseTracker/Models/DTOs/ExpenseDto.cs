using ExpenseTracker.Enums;

namespace ExpenseTracker.Models.DTOs
{
    /// <summary>
    /// Represents the values that can be updated for an existing expense.
    /// </summary>
    internal class ExpenseDto
    {
        /// <summary>
        /// Gets or sets the identifier of the expense transaction.
        /// </summary>
        /// <value>
        /// The unique display identifier of the expense.
        /// </value>
        public string TransactionId { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the updated expense amount.
        /// </summary>
        /// <value>
        /// The monetary amount of the expense.
        /// </value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the updated date of the expense transaction.
        /// </summary>
        /// <value>
        /// The date on which the expense occurred.
        /// </value>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Gets or sets the updated category of the expense.
        /// </summary>
        /// <value>
        /// The category assigned to the expense.
        /// </value>
        public Enums.ExpenseCategory Category { get; set; }
    }
}