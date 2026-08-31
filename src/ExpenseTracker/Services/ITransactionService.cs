namespace ExpenseTracker.Services
{
    using ExpenseTracker.Enums;
    using ExpenseTracker.Models;
    using ExpenseTracker.Models.DTOs;

    /// <summary>
    /// Manages common transaction operations for Transaction.
    /// </summary>
    internal interface ITransactionService
    {
        /// <summary>
        /// Retrieves all transactions handled by the service.
        /// </summary>
        /// <returns>A read-only list containing the available transactions.</returns>
        public IReadOnlyList<TransactionDto> GetAll();

        /// <summary>
        /// Retrieves a transaction using its display identifier.
        /// </summary>
        /// <param name="transactionId">The display identifier of the transaction.</param>
        /// <returns>The matching transaction if found; otherwise, null.</returns>
        public TransactionDto? Get(string transactionId);

        /// <summary>
        /// Deletes a transaction using its display identifier.
        /// </summary>
        /// <param name="transactionId">The display identifier of the transaction to delete.</param>
        public void Delete(string transactionId);
    }

    /// <summary>
    /// Manages transaction updates
    /// </summary>
    /// <typeparam name="TUpdateDto">Dto for </typeparam>
    internal interface ITransactionUpdateService<TUpdateDto>
    {
        /// <summary>
        /// Updates an existing transaction.
        /// </summary>
        /// <param name="transactionId">The transaction id of the transaction to be edited.</param>
        /// <param name="dto">Generic dto for updation</param>
        public void Edit(string transactionId, TUpdateDto dto);
    }
}
