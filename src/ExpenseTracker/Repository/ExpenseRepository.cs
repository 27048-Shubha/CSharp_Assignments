using ExpenseTracker.Enums;
using ExpenseTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExpenseTracker.Repository
{
    internal class ExpenseRepository : ITransactionRepository<>
    {
        private List<Expense> _expenses;
        public void Add<T>(decimal amount, DateOnly date, T category)
        {
            _expenses.Add(new Expense(amount, date, (ExpenseCategory)(object)category) );
        }

        public void Update(Guid id, Expense expenseDetails)
        {
            foreach (var expense in this._expenses)
            {
                if (id == expense.Id)
                {
                    expense.Amount = expenseDetails.Amount;
                    expense.Date = expenseDetails.Date;
                    expense.Category = expenseDetails.Category;
                }
            }
        }

        public Expense Get(Guid id)
        {
            foreach (var expense in this._expenses)
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
            foreach (var expense in this._expenses)
            {
                if (expense.amount.Contains(amount, StringComparison.OrdinalIgnoreCase))
                {
                    return this.expense.Id;
                }
            }
            return Guid.Empty;
        }

        public Guid GetId(DateOnly date)
        {
            foreach (var expense in this._expenses)
            {
                if (expense.date.Contains(date, StringComparison.OrdinalIgnoreCase))
                {
                    return this.expense.Id;
                }
            }
            return Guid.Empty;
        }

        public void Delete(Guid id)
        {
            foreach (var expense in this._expenses)
            {
                if (id == expense.Id)
                {
                    _expenses.Remove(expense);
                }
            }
        }
    }
}
