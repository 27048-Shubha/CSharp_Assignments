using ExpenseTracker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    internal class IncomeRepository : Transaction
    {
        private decimal totalIncome;
        private IncomeSource source;
        public IncomeRepository(decimal amount, DateOnly date, IncomeSource soruce)
            : base(amount, date)
        {
        }

        public IncomeSource Source
        {
            get; set;
        }

        public decimal TotalIncome
        {
            get; set;
        }
    }
}
