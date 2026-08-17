using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Defines common operations for managing transactions in a repository.
    /// </summary>
    public interface ITransactionRepository
    {
        /// <summary>
        /// Deletes a transaction using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction to delete.</param>
        public void Delete(Guid id);
    }

    /// <summary>
    /// Defines repository operations for a specific type of transaction.
    /// </summary>
    /// <typeparam name="TTransaction">The type of transaction managed by the repository.</typeparam>
    public interface ITransactionRepository<TTransaction> : ITransactionRepository
    {
        /// <summary>
        /// Adds a new transaction to the repository.
        /// </summary>
        /// <param name="transaction">The transaction to add.</param>
        public void Add(Transaction transaction);

        /// <summary>
        /// Retrieves a transaction using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction</param>
        /// <returns>The matching transaction if found; otherwise, null.</returns>
        public TTransaction Get(Guid id);

        /// <summary>
        /// Updates an existing transaction.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction to update.</param>
        /// <param name="expenseDetails">The transaction containing updated values.</param>
        public void Update(Guid id, Transaction expenseDetails);
    }
}