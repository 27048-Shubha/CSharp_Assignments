using ExpenseTracker.Enums;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;
namespace ExpenseTracker.Services
{
    internal interface ITransactionService
    {
        public void Add(Transaction transaction);

        public IReadOnlyList<Transaction> GetAll();

        public void Edit(Transaction transaction);

        public Transaction Get(string transactionId);

        public void Delete(string transactionId);

        public void DeleteTransaction(Transaction transaction);
    }
}
