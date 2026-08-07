using ExpenseTracker.Enums;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Services
{
    internal class IncomeService : ITransactionService
    {
        private IncomeRepository _repository;

        public IncomeService(IncomeRepository incomeRepository)
        {
            this._repository = incomeRepository;
        }

        public void Add(Transaction income)
        {
            //negative amount validation
            //future date validation
            _repository.Add((Income) income);
        }

        public IReadOnlyList<Transaction> GetAll()
        {
            return _repository.GetAll();
        }

        public void Edit(Transaction transaction)
        {
            Guid id = _repository.GetId(transaction.TransactionId);
            _repository.Update(id, (Income)transaction);
        }

        public static string GetTransactionId()
        {
            return IncomeRepository.GetTransactionId();
        }

        public Transaction Get(string transactionId)
        {
            Guid id = _repository.GetId(transactionId);
            return _repository.Get(id);
        }

        public void Delete(string transactionId)
        {
            Guid id = _repository.GetId(transactionId);
            _repository.Delete(id);
        }

        public void DeleteTransaction(Transaction transaction)
        {
            Guid id = _repository.GetId(transaction.TransactionId);
            _repository.Delete(id);
        }
    }
}
