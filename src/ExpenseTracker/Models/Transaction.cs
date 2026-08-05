using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class Transaction
    {
        private Guid id;
        private decimal amount;
        private DateOnly date;

        public Transaction(decimal amount, DateOnly date)
        {
            this.id = new Guid();
            this.amount = amount;
            this.date = date;
        }

        public Guid Id 
        { 
            get { return id; }
        }

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
