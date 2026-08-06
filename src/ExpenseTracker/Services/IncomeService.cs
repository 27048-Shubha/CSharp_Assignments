using ExpenseTracker.Enums;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Services
{
    internal class IncomeService : ITransactionService
    {
        private IncomeRepository _repository = new IncomeRepository();
        public void Add(decimal amount, DateOnly date, IncomeSource category)
        {
            //negative amount validation
            //future date validation
            _repository.Add(amount, date, category);
        }

        public IReadOnlyList<Income> GetAll()
        {
            return _repository.GetAll();
        }

        public void Edit(Income transaction)
        {
            Guid id = _repository.GetId(transaction.TransactionId);
            _repository.Update(id, transaction);
        }

        public Income Get(string transactionId)
        {
            Guid id = _repository.GetId(transactionId);
            return _repository.Get(id);
        }

        public void Delete(string transactionId)
        {
            Guid id = _repository.GetId(transactionId);
            _repository.Delete(id);
        }

        public void DeleteTransaction(Income transaction)
        {
            Guid id = _repository.GetId(transactionId);
            _repository.Delete(id);
        }
    }
}
