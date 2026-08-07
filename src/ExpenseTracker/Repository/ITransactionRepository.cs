using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public interface ITransactionRepository
    {
        public void Delete(Guid id);
    }
    public interface ITransactionRepository<TTransaction, TCategory> : ITransactionRepository
    {
        public void Add(Transaction transaction);
        public TTransaction Get(Guid id);
        public void Delete(Guid id);
        public void Update(Guid id, Transaction expenseDetails);
    }
}
