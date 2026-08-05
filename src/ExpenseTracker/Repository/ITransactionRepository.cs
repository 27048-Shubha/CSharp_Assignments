using ExpenseTracker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker.Repository
{
    public interface ITransactionRepository
    {
        public void Add(decimal amount, DateOnly date, ExpenseCategory category);
        public void Update();
        public Guid Get();
        public void Delete();
        public void Summary();

    }
}
