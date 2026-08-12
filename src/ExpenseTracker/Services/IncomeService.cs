using ExpenseTracker.Enums;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Services
{
    /// <summary>
    /// rovides business operations for income transactions.
    /// </summary>
    internal class IncomeService : ITransactionService
    {
        private IncomeRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="IncomeService"/> class.
        /// </summary>
        /// <param name="incomeRepository">The repository used to store and retrieve income transactions.</param>
        public IncomeService(IncomeRepository incomeRepository)
        {
            this._repository = incomeRepository;
        }

        /// <summary>
        /// Adds a new income to the transaction
        /// </summary>
        /// <param name="transactionId">Id of the transaction</param>
        /// <param name="amount">Income amount</param>
        /// <param name="date">Date of transaction</param>
        /// <param name="incomeSource">Source of income amount</param>
        public void Add(string transactionId, decimal amount, DateOnly date, IncomeSource incomeSource)
        {
            // negative amount validation
            // future date validation
            _repository.Add((Income)new (transactionId, amount, date, incomeSource));
        }

        /// <summary>
        ///  Retrieves all income transactions.
        /// </summary>
        /// <returns> A read-only list containing the income transactions.</returns>
        public IReadOnlyList<Transaction> GetAll()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// Updates an existing income transaction.
        /// </summary>
        /// <param name="transaction">The income transaction containing the updated values.</param>
        public void Edit(Transaction transaction)
        {
            Guid id = _repository.GetId(transaction.TransactionId);
            _repository.Update(id, (Income)transaction);
        }

        /// <summary>
        /// Generates a unique display identifier for an income transaction.
        /// </summary>
        /// <returns> A string identifier prefixed with the letter I.</returns>
        public static string GetTransactionId()
        {
            return IncomeRepository.GetTransactionId();
        }

        /// <summary>
        /// Retrieves an income transaction using its transaction identifier.
        /// </summary>
        /// <param name="transactionId">The display identifier of the transaction.</param>
        /// <returns>The matching income transaction if found; otherwise, null.</returns>
        public Transaction Get(string transactionId)
        {
            Guid id = _repository.GetId(transactionId);
            return _repository.Get(id);
        }

        /// <summary>
        /// Deletes an income transaction using the transaction identifier.
        /// </summary>
        /// <param name="transactionId">The display identifier of the transaction to delete.</param>
        public void Delete(string transactionId)
        {
            Guid id = _repository.GetId(transactionId);
            _repository.Delete(id);
        }

        /// <summary>
        /// Deletes an income transaction using the transaction object.
        /// </summary>
        /// <param name="transaction">The income transaction to delete.</param>
        public void DeleteTransaction(Transaction transaction)
        {
            Guid id = _repository.GetId(transaction.TransactionId);
            _repository.Delete(id);
        }
    }
}
