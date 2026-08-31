using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Defines repository operations for a specific type of transaction.
    /// </summary>
    /// <typeparam name="TTransaction">The type of transaction managed by the repository.</typeparam>
    public interface ITransactionRepository<TTransaction>
        where TTransaction : Transaction
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
        public TTransaction? Get(Guid id);

        /// <summary>
        /// Retrieves a transaction using its unique identifier.
        /// </summary>
        /// <param name="id">The unique string identifier of the transaction</param>
        /// <returns>Guid of the transaction if found; otherwise, null.</returns>
        public Guid GetId(string id);

        /// <summary>
        /// Retrieves all the transaction.
        /// </summary>
        /// <returns>All transactions if found; otherwise, null.</returns>
        public IReadOnlyList<TTransaction> GetAll();

        /// <summary>
        /// Updates an existing transaction.
        /// </summary>
        /// <param name="id">The unique identifier of the transaction to update.</param>
        /// <param name="expenseDetails">The transaction containing updated values.</param>
        public void Update(Guid id, Transaction expenseDetails);

        /// <summary>
        /// Deletes existing transaction based on id
        /// </summary>
        /// <param name="id">Id of the transaction to be deleted.</param>
        public void Delete(Guid id);
    }
}