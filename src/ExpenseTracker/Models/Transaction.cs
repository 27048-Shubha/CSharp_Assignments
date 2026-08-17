namespace ExpenseTracker.Models
{
    /// <summary>
    /// Represents the common information of a financial transaction.
    /// </summary>
    public class Transaction
    {
        private Guid _id;

        /// <summary>
        /// Initializes a new instance of the <see cref="Transaction"/> class.
        /// </summary>
        /// <param name="transactionId">The display identifier of the transaction.</param>
        /// <param name="amount">The monetary value of the transaction.</param>
        /// <param name="date">The date on which the transaction occurred.</param>
        public Transaction(string transactionId, decimal amount, DateOnly date)
        {
            this._id = Guid.NewGuid();
            this.TransactionId = transactionId;
            this.Amount = amount;
            this.Date = date;
        }

        /// <summary>
        /// Gets the unique identifier of the transaction.
        /// </summary>
        /// <value>A globally unique identifier assigned when the transaction is created.</value>
        public Guid Id
        {
            get { return this._id; }
        }

        /// <summary>
        /// Gets or Sets the transaction display identifier.
        /// </summary>
        /// <value>An identifier generated for display and user reference.</value>
        public string TransactionId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        /// <value>The amount associated with the transaction.</value>
        public decimal Amount
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the date of the transaction.
        /// </summary>
        /// <value>The transaction date.</value>
        public DateOnly Date
        {
            get; set;
        }
    }
}