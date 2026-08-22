using ExpenseTracker.Enums;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Provides repository operations for managing income transactions.
    /// </summary>
    internal class InMemoryIncome : ITransactionRepository<Income>
    {
        private static int _transactionCount = 0;
        private List<Income> _incomeDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="InMemoryIncome"/> class.
        /// </summary>
        internal InMemoryIncome()
        {
            this._incomeDetails = new List<Income>();
        }

        /// <summary>
        /// Generates a unique transaction identifier for an income transaction.
        /// </summary>
        /// <returns>
        /// A unique transaction identifier prefixed with the letter.
        /// </returns>
        public static string GetTransactionId()
        {
            _transactionCount += 1;
            return "I" + _transactionCount.ToString();
        }

        /// <summary>
        /// Retrieves all income transactions from the repository.
        /// </summary>
        /// <returns>A read-only list of all income transactions.</returns>
        public IReadOnlyList<Income> GetAll()
        {
            return this._incomeDetails;
        }

        /// <summary>
        /// Adds an income transaction to the repository.
        /// </summary>
        /// <param name="transaction">The income transaction to add.</param>
        public void Add(Transaction transaction)
        {
            this._incomeDetails.Add((Income)transaction);
        }

        /// <summary>
        /// Updates an existing income transaction.
        /// </summary>
        /// <param name="id">The unique identifier of the income transaction to update.</param>
        /// <param name="incomeDetails">The income transaction containing updated values.</param>
        public void Update(Guid id, Transaction incomeDetails)
        {
            Income income = (Income)incomeDetails;

            var item = this._incomeDetails.FirstOrDefault(x => x.Id == id);

            if (item != null)
            {
                item.Amount = income.Amount;
                item.Date = income.Date;
                item.Source = income.Source;
                return;
            }
        }

        /// <summary>
        /// Retrieves an income transaction using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the income transaction to retrieve.</param>
        /// <returns>The matching income transaction if found; otherwise, null.</returns>
        public Income? Get(Guid id)
        {
            foreach (var income in this._incomeDetails)
            {
                if (id == income.Id)
                {
                    return income;
                }
            }

            return null;
        }

        /// <summary>
        /// Retrieves the unique identifier of an income transaction using its transaction identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier of the income transaction.</param>
        /// <returns>The unique identifier if found; otherwise, Guid.Empty.</returns>
        public Guid GetId(string transactionId)
        {
            foreach (var item in this._incomeDetails)
            {
                if (item.TransactionId == transactionId)
                {
                    return item.Id;
                }
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Deletes an income transaction using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the income transaction to delete.</param>
        public void Delete(Guid id)
        {
            var income = this._incomeDetails.FirstOrDefault(x => x.Id == id);

            if (income != null)
            {
                this._incomeDetails.Remove(income);
            }
        }
    }
}