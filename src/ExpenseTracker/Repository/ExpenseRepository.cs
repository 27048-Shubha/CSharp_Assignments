namespace ExpenseTracker.Repository
{
    using ExpenseTracker.Enums;
    using ExpenseTracker.Models;

    /// <summary>
    /// Provides in-memory storage and management operations for expense transactions.
    /// </summary>
    internal class ExpenseRepository : ITransactionRepository
    {
        private static decimal _transactionCount = 0;
        private List<Expense> _expenseDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseRepository"/> class.
        /// </summary>
        internal ExpenseRepository()
        {
            _expenseDetails = new List<Expense>();
        }

        /// <summary>
        /// Retrieves all stored expense transactions.
        /// </summary>
        /// <returns>A read-only list of expense transactions.</returns>
        public IReadOnlyList<Expense> GetAll()
        {
            return _expenseDetails;
        }

        /// <summary>
        /// Generates a unique display identifier for an expense transaction.
        /// </summary>
        /// <returns>A string identifier prefixed with the letter E </returns>
        public static string GetTransactionId()
        {
            _transactionCount += 1;
            return "E" + _transactionCount.ToString();
        }

        /// <summary>
        /// Adds a new expense transaction to the repository.
        /// </summary>
        /// <param name="transaction">The expense transaction to add.</param>
        public void Add(Transaction transaction)
        {
            _expenseDetails.Add((Expense)transaction);
        }

        /// <summary>
        /// Updates an existing expense transaction.
        /// </summary>
        /// <param name="id">The unique identifier of the expense to update.</param>
        /// <param name="expenseDetails">The expense containing updated values.</param>
        public void Update(Guid id, Transaction expenseDetails)
        {
            Expense expense = (Expense)expenseDetails;
            foreach (var item in this._expenseDetails)
            {
                if (id == item.Id)
                {
                    item.Amount = expense.Amount;
                    item.Date = expense.Date;
                    item.Category = expense.Category;
                }
            }
        }

        /// <summary>
        /// Retrieves an expense transaction using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the expense.</param>
        /// <returns>The matching expense if found; otherwise, null.</returns>
        public Expense Get(Guid id)
        {
            foreach (var expense in this._expenseDetails)
            {
                if (id == expense.Id)
                {
                    return expense;
                }
            }
            return null;
        }

        /// <summary>
        /// Retrieves Guid of given transactionId.
        /// </summary>
        /// <param name="transactionId">The unique identifier of the transaction.</param>
        /// <returns>Guid of the transaction</returns>
        public Guid GetId(string transactionId)
        {
            foreach (var expense in this._expenseDetails)
            {
                if (expense.TransactionId == transactionId)
                {
                    return expense.Id;
                }
            }
            return Guid.Empty;
        }

        /// <summary>
        /// Deletes an expense transaction using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the expense to delete.</param>
        public void Delete(Guid id)
        {
            _expenseDetails.RemoveAll(expense => expense.Id == id);
        }
    }
}
