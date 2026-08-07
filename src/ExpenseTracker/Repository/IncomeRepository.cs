using ExpenseTracker.Enums;
using ExpenseTracker.Models;
using System.Reflection.Metadata;

namespace ExpenseTracker.Repository
{
    internal class IncomeRepository : ITransactionRepository<Income, IncomeSource>
    {
        private static decimal _transactionCount = 0;
        private List<Income> _incomeDetails;

        public static string GetTransactionId()
        {
            _transactionCount += 1;
            return _transactionCount.ToString();
        }

        public IReadOnlyList<Income> GetAll()
        {
            return _incomeDetails;
        }

        public void Add(Transaction transaction)
        {
            _incomeDetails.Add((Income)transaction);
        }

        public void Update(Guid id, Transaction incomeDetails)
        {
            Income income = (Income)incomeDetails;
            foreach (var item in this._incomeDetails)
            {
                if (id == item.Id)
                {
                    item.Amount = income.Amount;
                    item.Date = income.Date;
                    item.Source = income.Source;
                }
            }
        }

        public Income Get(Guid id)
        {
            foreach (var expense in this._incomeDetails)
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
            foreach (var item in this._incomeDetails)
            {
                if (item.TransactionId == transactionId)
                {
                    return item.Id;
                }
            }
            return Guid.Empty;
        }

        public Guid GetId(DateOnly date)
        {
            foreach (var item in this._incomeDetails)
            {
                if (item.Date == date)
                {
                    return item.Id;
                }
            }

            return Guid.Empty;
        }

        public void Delete(Guid id)
        {
            foreach (var item in this._incomeDetails)
            {
                if (id == item.Id)
                {
                    _incomeDetails.Remove(item);
                }
            }
        }
    }
}
