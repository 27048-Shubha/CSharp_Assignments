using ExpenseTracker.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace ExpenseTracker.Repository
{
    public interface ITransactionRepository<TTransaction, TCategory>
    {
        public void Add(decimal amount, DateOnly date, TCategory category );
        public void Update(Guid id, TTransaction list);
        public Guid Get(decimal amount);
        public Guid Get(DateOnly date);
        public void Delete(Guid id);
    }
}
