using ExpenseTracker.Enums;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Services
{
    internal class ExpenseService : ITransactionService
    {
        private ExpenseRepository _repository;
        public ExpenseService(ExpenseRepository expenseRepository)
        {
            this._repository = expenseRepository;
        }

        public void Add(Transaction expense)
        {
            //negative amount validation
            //future date validation
            _repository.Add((Expense) expense);
        }

        public IReadOnlyList<Transaction> GetAll()
        {
            return _repository.GetAll();
        }

        public void Edit(Transaction transaction)
        {
            Guid id = _repository.GetId(transaction.TransactionId);
            _repository.Update(id, (Expense) transaction);
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
        public static string GetTransactionId()
        {
            return IncomeRepository.GetTransactionId();
        }
    }
}
