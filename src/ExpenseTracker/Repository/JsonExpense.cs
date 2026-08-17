namespace ExpenseTracker.Repository
{
    using System.Text.Json;
    using ExpenseTracker.Models;

    /// <summary>
    /// Provides repository operations for managing expense transactions.
    /// </summary>
    internal class JsonExpense : ITransactionRepository
    {
        private static string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.FullName, "Data");
        private static decimal _transactionCount = 0;

        /// <summary>
        /// Generates a unique transaction identifier for an expense transaction.
        /// </summary>
        /// <returns>
        /// A unique transaction identifier prefixed with the letter.
        /// </returns>
        public static string GetTransactionId()
        {
            _transactionCount += 1;
            return "I" + _transactionCount.ToString();
        }

        /// <summary>
        /// Retrieves all expense transactions from the repository.
        /// </summary>
        /// <returns>A read-only list of all expense transactions.</returns>
        public IReadOnlyList<Expense> GetAll()
        {
            var jsonString = File.ReadAllText(filePath);
            IReadOnlyList<Expense> loadedExpense = JsonSerializer.Deserialize<IReadOnlyList<Expense>>(jsonString);
            return loadedExpense;
        }

        /// <summary>
        /// Adds an expense transaction to the repository.
        /// </summary>
        /// <param name="transaction">The expense transaction to add.</param>
        public void Add(Transaction transaction)
        {
            var jsonString = JsonSerializer.Serialize(transaction);
            File.WriteAllText(filePath, jsonString);
        }

        /// <summary>
        /// Updates an existing expense transaction.
        /// </summary>
        /// <param name="id">The unique identifier of the expense transaction to update.</param>
        /// <param name="incomeDetails">The expense transaction containing updated values.</param>
        public void Update(Guid id, Transaction incomeDetails)
        {
            Expense expense = (Expense)incomeDetails;
            var jsonString = File.ReadAllText(filePath);
            List<Expense> loadedExpense = JsonSerializer.Deserialize<List<Expense>>(jsonString);

            foreach (var item in loadedExpense)
            {
                if (id == item.Id)
                {
                    item.Amount = expense.Amount;
                    item.Date = expense.Date;
                    item.Category = expense.Category;
                }
            }

            File.WriteAllText(filePath, JsonSerializer.Serialize(expense));
        }

        /// <summary>
        /// Retrieves an expense transaction using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the expense transaction to retrieve.</param>
        /// <returns>The matching expense transaction if found; otherwise, null.</returns>
        public Expense? Get(Guid id)
        {
            var jsonString = File.ReadAllText(filePath);
            List<Expense> loadedExpense = JsonSerializer.Deserialize<List<Expense>>(jsonString);

            foreach (var item in loadedExpense)
            {
                if (id == item.Id)
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Retrieves the unique identifier of an expense transaction using its transaction identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier of the expense transaction.</param>
        /// <returns>The unique identifier if found; otherwise, Guid.Empty.</returns>
        public Guid GetId(string transactionId)
        {
            var jsonString = File.ReadAllText(filePath);
            List<Expense> loadedExpense = JsonSerializer.Deserialize<List<Expense>>(jsonString);

            foreach (var item in loadedExpense)
            {
                if (transactionId == item.TransactionId)
                {
                    return item.Id;
                }
            }

            return Guid.Empty;
        }

        /// <summary>
        /// Deletes an expense transaction using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the expense transaction to delete.</param>
        public void Delete(Guid id)
        {
            var jsonString = File.ReadAllText(filePath);
            List<Expense> loadedExpense = JsonSerializer.Deserialize<List<Expense>>(jsonString);

            var updatedExpense = loadedExpense.FindAll(income => income.Id == id);
            File.WriteAllText(filePath, JsonSerializer.Serialize(updatedExpense));
        }
    }
}