using ExpenseTracker.Enums;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    internal class IncomeRepository: ITransactionRepository
    {
        private List<Income> _incomeDetails;
        public void Add(decimal amount, DateOnly date, IncomeSource category)
        {
            _incomeDetails.Add(new Expense(amount, date, category));
        }

        public void Update(Guid id, Expense incomeDetails)
        {
            foreach (var income in this._incomeDetails)
            {
                if (id == income.Id)
                {
                    income.Amount = incomeDetails.Amount;
                    income.Date = incomeDetails.Date;
                    income.Category = incomeDetails.Category;
                }
            }
        }

        public Expense Get(Guid id)
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

        public Guid GetId(decimal amount)
        {
            foreach (var item in this._incomeDetails)
            {
                if (item.amount.Contains(amount, StringComparison.OrdinalIgnoreCase))
                {
                    return this.item.Id;
                }
            }
            return Guid.Empty;
        }

        public Guid GetId(DateOnly date)
        {
            foreach (var item in this._incomeDetails)
            {
                if (item.date.Contains(date, StringComparison.OrdinalIgnoreCase))
                {
                    return this.item.Id;
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
