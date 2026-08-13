using ExpenseTracker.Enums;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents money spent by the user.
    /// </summary>
    public class Expense : Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// </summary>
        /// <param name="transactionId">The identifier assigned to the transaction.</param>
        /// <param name="amount">The amount spent.</param>
        /// <param name="date">The date on which the expense occurred.</param>
        /// <param name="category">The category of the expense.</param>
        public Expense(string transactionId, decimal amount, DateOnly date, ExpenseCategory category)
            : base(transactionId, amount, date)
        {
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
    }
}
