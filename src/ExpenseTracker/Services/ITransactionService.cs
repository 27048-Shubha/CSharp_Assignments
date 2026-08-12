namespace ExpenseTracker.Services
{
    using ExpenseTracker.Enums;
    using ExpenseTracker.Models;

    /// <summary>
    /// Defines common operations for managing financial transactions.
    /// </summary>
    internal interface ITransactionService
    {
        /// <summary>
        /// Retrieves all transactions handled by the service.
        /// </summary>
        /// <returns>A read-only list containing the available transactions.</returns>
        public IReadOnlyList<Transaction> GetAll();

        /// <summary>
        /// Updates an existing transaction.
        /// </summary>
        /// <param name="transaction">The transaction containing the updated values.</param>
        public void Edit(Transaction transaction);

        /// <summary>
        /// Retrieves a transaction using its display identifier.
        /// </summary>
        /// <param name="transactionId">The display identifier of the transaction.</param>
        /// <returns>The matching transaction if found; otherwise, null.</returns>
        public Transaction Get(string transactionId);

        /// <summary>
        /// Deletes a transaction using its display identifier.
        /// </summary>
        /// <param name="transactionId">The display identifier of the transaction to delete.</param>
        public void Delete(string transactionId);

        /// <summary>
        /// Deletes a transaction using the transaction object.
        /// </summary>
        /// <param name="transaction">The transaction to delete.</param>
        public void DeleteTransaction(Transaction transaction);
    }
}
