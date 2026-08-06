using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class Transaction
    {
        private Guid _id;
        private string _transactionId;
        private decimal _amount;
        private DateOnly _date;

        public Transaction(string transactionId, decimal amount, DateOnly date)
        {
            this._id = new Guid();
            TransactionId = transactionId;
            Amount = amount;
            Date = date;
        }

        public Guid Id
        { 
            get { return _id; }
        }

        public decimal Amount
        {
            get; set;
        }

        public DateOnly Date
        {
            get; set;
        }
        public string TransactionId
        {
            get; set;
        }
    }
}
