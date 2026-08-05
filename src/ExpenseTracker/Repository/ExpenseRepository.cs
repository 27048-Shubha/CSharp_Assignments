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
    internal class ExpenseRepository : ITransactionRepository
    {
        public List<Expense> expenses;
        public void Add(decimal amount, DateOnly date, ExpenseCategory category)
        {
            Expense.Add(new Expense(amount, date, category));
        }

        public void Update(Guid id, Expense expenseDetails)
        {
            foreach (var expense in this.expenses)
            {
                if (id == expense.Id)
                {
                    expense.Amount = expenseDetails.Amount;
                    expense.Date = expenseDetails.Date;
                    expense.Category = expenseDetails.Category;
                }
            }
        }

        public Guid GetId(decimal amount)
        {
            foreach (var expense in this.expenses)
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
            foreach (var expense in this.expenses)
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
            foreach (var expense in this.expenses)
            {
                if (id == expense.Id)
                {
                    expenses.Remove(expense);
                }
            }
        }

        public void Summary()
        {

        }
    }
}
