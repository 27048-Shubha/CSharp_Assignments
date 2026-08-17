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
        /// <param name="transactionId">The display identifier of the transaction to retrieve.</param>
        /// <returns>A <see cref="TransactionDto"/> representing the transaction when found; otherwise, <see langword="null"/>.</returns>
        public TransactionDto? Get(string transactionId);
        /// <summary>
        /// Deletes a transaction using its display identifier.
        /// </summary>
        /// <param name="transactionId">The display identifier of the transaction to delete.</param>
        public void Delete(string transactionId);

        /// <summary>
        /// Sorts the transactions based on the specified order.
        /// </summary>
        /// <param name="order">The order in which to sort the transactions.</param>
        /// <returns>A read-only list of transactions sorted according to the specified order.</returns>
        public IReadOnlyList<TransactionDto> SortByAmount(Enums.Order order);

        /// <summary>
        /// Sorts the transactions based on the specified order.
        /// </summary>
        /// <param name="order">The order in which to sort the transactions.</param>
        /// <returns>A read-only list of transactions sorted according to the specified order.</returns>
        public IReadOnlyList<TransactionDto> SortByTransactionId(Enums.Order order);

        /// <summary>
        /// Sorts the transactions based on the specified order.
        /// </summary>
        /// <param name="order">The order in which to sort the transactions.</param>
        /// <returns>A read-only list of transactions sorted according to the specified order.</returns>
        public IReadOnlyList<TransactionDto> SortByDate(Enums.Order order);
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