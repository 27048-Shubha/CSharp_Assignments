using ExpenseTracker.Enums;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Services
{
    /// <summary>
    /// Provides business operations for expense transactions.
    /// </summary>
    internal class ExpenseService : ITransactionService
    {
        private ExpenseRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseService"/> class.
        /// </summary>
        /// <param name="expenseRepository">The repository used to store and retrieve expense transactions.</param>
        public ExpenseService(ExpenseRepository expenseRepository)
        {
            this._repository = expenseRepository;
        }

        /// <summary>
        /// Adds a new income to the transaction
        /// </summary>
        /// <param name="transactionId">Id of the transaction</param>
        /// <param name="amount">Income amount</param>
        /// <param name="date">Date of transaction</param>
        /// <param name="expenseCategory">Source of income amount</param>
        public void Add(string transactionId, decimal amount, DateOnly date, ExpenseCategory expenseCategory)
        {
            // negative amount validation
            // future date validation
            _repository.Add((Expense)new (transactionId, amount, date, expenseCategory));
        }

        /// <summary>
        /// Retrieves all expense transactions.
        /// </summary>
        /// <returns>A read-only list containing the expense transactions.</returns>
        public IReadOnlyList<Transaction> GetAll()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// Updates an existing expense transaction.
        /// </summary>
        /// <param name="transaction">The expense transaction containing the updated values.</param>
        public void Edit(Transaction transaction)
        {
            Guid id = _repository.GetId(transaction.TransactionId);
            _repository.Update(id, (Expense)transaction);
        }

        /// <summary>
        /// Retrieves an expense transaction using its transaction identifier.
        /// </summary>
        /// <param name="transactionId">The display identifier of the transaction.</param>
        /// <returns>The matching expense transaction if found; otherwise, null.</returns>
        public Transaction Get(string transactionId)
        {
            Guid id = _repository.GetId(transactionId);
            return _repository.Get(id);
        }

        /// <summary>
        /// Deletes an expense transaction using its transaction identifier.
        /// </summary>
        /// <param name="transactionId">The display identifier of the transaction to delete.</param>
        public void Delete(string transactionId)
        {
            Guid id = _repository.GetId(transactionId);
            _repository.Delete(id);
        }

        /// <summary>
        /// Deletes an expense transaction using the transaction object.
        /// </summary>
        /// <param name="transaction">The expense transaction to delete.</param>
        public void DeleteTransaction(Transaction transaction)
        {
            Guid id = _repository.GetId(transaction.TransactionId);
            _repository.Delete(id);
        }

        /// <summary>
        /// Generates a unique display identifier for an expense transaction.
        /// </summary>
        /// <returns>A string identifier prefixed with the letter E</returns>
        public static string GetTransactionId()
        {
            return IncomeRepository.GetTransactionId();
        }
    }
}
