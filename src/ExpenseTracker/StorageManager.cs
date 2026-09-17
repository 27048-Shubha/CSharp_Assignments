namespace ExpenseTracker
{
    using ExpenseTracker.Models;
    using ExpenseTracker.Repository;
    using ExpenseTracker.View;

    /// <summary>
    /// Manages storage choice.
    /// </summary>
    internal class StorageManager
    {
        private ConsoleView _console;

        /// <summary>
        /// Initializes a new instance of the <see cref="StorageManager"/> class.
        /// </summary>
        /// <param name="console">The console view used to receive input and display output.</param>
        public StorageManager(ConsoleView console)
        {
            this._console = console;
        }

        /// <summary>
        /// Chooses storage option for expense tracker.
        /// </summary>
        /// <returns>Returns tuple of income and expense repository instances.</returns>
        public (ITransactionRepository<Income>, ITransactionRepository<Expense>) ChooseStorage()
        {
            this._console.DisplayStorageOptions();
            Enums.Storage storage = this._console.ChooseStorageChoice();

            if (storage == Enums.Storage.JsonFile)
            {
                return (new JsonIncome(), new JsonExpense());
            }

            return (new InMemoryIncome(), new InMemoryExpense());
        }
    }
}
