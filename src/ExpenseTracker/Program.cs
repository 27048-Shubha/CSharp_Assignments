namespace Assignments
{
    using ExpenseTracker;
    using ExpenseTracker.Controller;
    using ExpenseTracker.Models;
    using ExpenseTracker.Repository;
    using ExpenseTracker.Services;
    using ExpenseTracker.View;

    /// <summary>
    /// Main program of the expense tracker.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Manages initial execution of the program.
        /// </summary>
        public static void Main()
        {
            ConsoleView console = new ConsoleView();
            StorageManager storage = new StorageManager(console);

            (ITransactionRepository<Income>, ITransactionRepository<Expense>) repository = storage.ChooseStorage();
            ITransactionRepository<Income> incomeRepository = repository.Item1;
            ITransactionRepository<Expense> expenseRepository = repository.Item2;

            IncomeService incomeService = new IncomeService(incomeRepository);
            ExpenseService expenseService = new ExpenseService(expenseRepository);

            TransactionController controller = new TransactionController(console, incomeService, expenseService);

            controller.Initialize();
        }
    }
}