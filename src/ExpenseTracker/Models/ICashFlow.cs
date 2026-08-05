using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class ICashFlow
    {
        public decimal amount;
        public DateOnly date;

        public decimal Amount
        {
            get; set;
        }

        public decimal Date
        {
            get; set;
        }
    }
}
