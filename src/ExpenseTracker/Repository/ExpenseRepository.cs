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
    internal class ExpenseRepository : ITransactionRepository<Expense, ExpenseCategory>
    {
        private decimal _transactionCount = 0;
        private List<Expense> _expenses = new List<Expense>();
        public void Add(decimal amount, DateOnly date, ExpenseCategory category)
        {
            _transactionCount += 1;
            string transactionId = this._transactionCount.ToString();
            _expenses.Add(new Expense("E"+transactionId, amount, date, category));
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
                if (expense.Amount == amount)
                {
                    return expense.Id;
                }
            }
            return Guid.Empty;
        }

        public Guid GetId(DateOnly date)
        {
            foreach (var expense in this._expenses)
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
