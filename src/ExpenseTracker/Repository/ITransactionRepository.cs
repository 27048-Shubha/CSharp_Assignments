using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    public interface ITransactionRepository
    {
        public void Delete(Guid id);
    }
    public interface ITransactionRepository<TTransaction, TCategory> : ITransactionRepository
    {
        public void Add(decimal amount, DateOnly date, TCategory category );
        public void Update(Guid id, TTransaction list);
        public TTransaction Get(Guid id);
    }
}
