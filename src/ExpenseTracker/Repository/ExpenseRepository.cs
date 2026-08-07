using ExpenseTracker.Enums;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    internal class ExpenseRepository : ITransactionRepository<Expense, ExpenseCategory>
    {
        private static decimal _transactionCount = 0;
        private List<Expense> _expenseDetails;

        public IReadOnlyList<Expense> GetAll()
        {
            return _expenseDetails;
        }
        public static string GetTransactionId()
        {
            _transactionCount += 1;
            return _transactionCount.ToString();
        }

        public void Add(Transaction transaction)
        {
            _expenseDetails.Add((Expense)transaction);
        }

        public void Update(Guid id, Transaction expenseDetails)
        {
            Expense expense = (Expense)expenseDetails;
            foreach (var item in this._expenseDetails)
            {
                if (id == item.Id)
                {
                    item.Amount = expense.Amount;
                    item.Date = expense.Date;
                    item.Category = expense.Category;
                }
            }
        }

        public Expense Get(Guid id)
        {
            foreach (var expense in this._expenseDetails)
            {
                if (id == expense.Id)
                {
                    return expense;
                }
            }
            return null;
        }

        public Guid GetId(string transactionId)
        {
            foreach (var expense in this._expenseDetails)
            {
                if (expense.TransactionId == transactionId)
                {
                    return expense.Id;
                }
            }
            return Guid.Empty;
        }

        public Guid GetId(decimal amount)
        {
            foreach (var expense in this._expenseDetails)
            {
                if (expense.Amount == amount)
                {
                    return expense.Id;
                }
            }
            return Guid.Empty;
        }

        public Guid GetId(DateOnly date)
        {
            foreach (var expense in this._expenseDetails)
            {
                if (expense.Date == date)
                {
                    return expense.Id;
                }
            }
            return Guid.Empty;
        }

        public void Delete(Guid id)
        {
            foreach (var expense in this._expenseDetails)
            {
                if (id == expense.Id)
                {
                    _expenseDetails.Remove(expense);
                }
            }
        }
    }
}
