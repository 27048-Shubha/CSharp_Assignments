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
        public void Add();
        public void Update();
        public Guid Get();
        public void Delete();
        public void Summary();
    }
}
