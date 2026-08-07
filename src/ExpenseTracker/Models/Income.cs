using ExpenseTracker.Enums;

namespace ExpenseTracker.Models
{
    internal class Income : Transaction
    {
        private decimal _totalIncome;
        private IncomeSource _source;

        public Income(string transactionId, decimal amount, DateOnly date, IncomeSource source)
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
