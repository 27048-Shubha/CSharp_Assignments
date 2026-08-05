using ExpenseTracker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    internal class Expense : ICashFlow
    {
        private decimal totalExpense;
        private ExpenseCategory category;

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
