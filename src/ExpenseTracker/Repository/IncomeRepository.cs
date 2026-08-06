using ExpenseTracker.Enums;
using ExpenseTracker.Models;
using System.Reflection.Metadata;

namespace ExpenseTracker.Repository
{
    internal class IncomeRepository : ITransactionRepository<Income, IncomeSource>
    {
        private List<Income> _incomeDetails;
        public IReadOnlyList<Income> GetAll()
        {
            return _incomeDetails;
        }
        public void Add(decimal amount, DateOnly date, IncomeSource category)
        {
            _incomeDetails.Add(new Income(amount, date, category));
        }

        public void Update(Guid id, Income incomeDetails)
        {
            foreach (var income in this._incomeDetails)
            {
                if (id == income.Id)
                {
                    income.Amount = incomeDetails.Amount;
                    income.Date = incomeDetails.Date;
                    income.Source = incomeDetails.Source;
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
