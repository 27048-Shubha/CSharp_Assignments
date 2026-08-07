using ExpenseTracker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class Expense : Transaction
    {
        private decimal _totalExpense;
        private ExpenseCategory _category;

        public Expense(string transactionId, decimal amount, DateOnly date, ExpenseCategory category)
            : base(transactionId, amount, date)
        {
        }

        public decimal TotalExpense
        {
            get; set;
        }

        public ExpenseCategory Category
        {
            get; set;
        }
    }
}
