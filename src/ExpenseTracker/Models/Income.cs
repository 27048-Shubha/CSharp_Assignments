using ExpenseTracker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    internal class Income : Transaction
    {
        private decimal _totalIncome;
        private IncomeSource _source;
        public Income(string transactionId, decimal amount, DateOnly date, IncomeSource soruce)
            : base(transactionId, amount, date)
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
