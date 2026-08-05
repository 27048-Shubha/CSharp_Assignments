using ExpenseTracker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    internal class Income : ICashFlow
    {
        private decimal totalIncome;
        private IncomeSource source;

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
