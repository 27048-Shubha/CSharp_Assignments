using ExpenseTracker.Enums;

namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents money received by the user.
    /// </summary>
    internal class Income : Transaction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Income"/> class.
        /// </summary>
        /// <param name="transactionId">The identifier assigned to the transaction.</param>
        /// <param name="amount">The amount received.</param>
        /// <param name="date">The date on which the income occurred.</param>
        /// <param name="source">The source of the income.</param>
        public Income(string transactionId, decimal amount, DateOnly date, IncomeSource source)
            : base(transactionId, amount, date)
        {
        }

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
    }
}
