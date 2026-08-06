using ExpenseTracker.Models;

namespace ExpenseTracker.Services
{
    internal interface ITransactionService<T>
        where T : Transaction
    {
        public void Add(decimal amount, DateOnly date, Transaction category);

        public void Edit(Transaction transaction);

        public Transaction Get(string transactionId);

        public IReadOnlyList<Transaction> GetAll();

        public void DeleteTransaction(Transaction transaction);
    }
}
