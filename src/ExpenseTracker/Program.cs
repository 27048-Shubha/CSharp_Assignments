using ExpenseTracker.Controller;
using ExpenseTracker.Repository;
using ExpenseTracker.Services;
using ExpenseTracker.View;

namespace Assignments
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ConsoleView console = new ConsoleView();

            InMemoryIncome incomeRepository = new InMemoryIncome();
            InMemoryExpense expenseRepository = new InMemoryExpense();

            IncomeService incomeService = new IncomeService(incomeRepository);
            ExpenseService expenseService = new ExpenseService(expenseRepository);

            TransactionController controller = new TransactionController(console, incomeService, expenseService);

            controller.Initialize();
        }
    }
}