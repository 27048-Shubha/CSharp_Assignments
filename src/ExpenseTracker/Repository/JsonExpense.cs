namespace ExpenseTracker.Repository
{
    using System.Text.Json;
    using ExpenseTracker.Models;

    /// <summary>
    /// Provides repository operations for managing expense transactions.
    /// </summary>
    internal class JsonExpense : ITransactionRepository<Expense>
    {
        private static string filePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\Data\Transactions.json"));
        private static int _transactionCount = 0;

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
            IReadOnlyList<JsonTransaction> loadedTransactions = this.ReadTransactions();
            List<Expense> expenses = new List<Expense>();

            foreach (var item in loadedTransactions)
            {
                if (item.TransactionType == "Expense")
                {
                    Expense expense = new Expense(
                        item.TransactionId,
                        item.Amount,
                        item.Date,
                        item.Category);

                    expenses.Add(expense);
                }
            }

            return (IReadOnlyList<Expense>)expenses;
        }

        /// <summary>
        /// Adds an expense transaction to the repository.
        /// </summary>
        /// <param name="transaction">The expense transaction to add.</param>
        public void Add(Transaction transaction)
        {
            var transactions = this.ReadTransactions();

            Expense expense = (Expense)transaction;
            JsonTransaction newTransaction = new JsonTransaction
                {
                    Id = expense.Id,
                    TransactionId = expense.TransactionId,
                    Amount = expense.Amount,
                    Date = expense.Date,
                    TransactionType = expense.GetType().Name,
                    Category = expense.Category,
                    TotalExpense = expense.TotalExpense,
                };

            transactions.Add(newTransaction);
            File.WriteAllText(filePath, JsonSerializer.Serialize(transactions));
        }

        /// <summary>
        /// Updates an existing expense transaction.
        /// </summary>
        /// <param name="id">The unique identifier of the expense transaction to update.</param>
        /// <param name="transaction">The expense transaction containing updated values.</param>
        public void Update(Guid id, Transaction transaction)
        {
            if (transaction is not Expense expense)
            {
                throw new ArgumentException(
                    "Only an expense can be updated in JsonExpense.",
                    nameof(transaction));
            }

            this.RewriteTransaction(id, new JsonTransaction
            {
                Id = expense.Id,
                TransactionId = expense.TransactionId,
                Amount = expense.Amount,
                Date = expense.Date,
                TransactionType = nameof(Expense),
                Category = expense.Category,
                TotalExpense = expense.TotalExpense,
            });
        }

        /// <summary>
        /// Retrieves an expense transaction using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the expense transaction to retrieve.</param>
        /// <returns>The matching expense transaction if found; otherwise, null.</returns>
        public Expense? Get(Guid id)
        {
            var jsonString = File.ReadAllText(filePath);
            List<JsonTransaction> loadedExpense = JsonSerializer.Deserialize<List<JsonTransaction>>(jsonString) ?? new List<JsonTransaction>();

            foreach (var item in loadedExpense)
            {
                if (id == item.Id)
                {
                    return new Expense(
                        item.TransactionId,
                        item.Amount,
                        item.Date,
                        item.Category);
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
            List<JsonTransaction> loadedExpense = JsonSerializer.Deserialize<List<JsonTransaction>>(jsonString) ?? new List<JsonTransaction>();

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
            List<JsonTransaction> loadedExpense = JsonSerializer.Deserialize<List<JsonTransaction>>(jsonString) ?? new List<JsonTransaction>();

            var updatedExpense = loadedExpense.FindAll(income => income.Id != id);
            File.WriteAllText(filePath, JsonSerializer.Serialize(updatedExpense));
        }

        /// <summary>
        /// Reads transaction from the file.
        /// </summary>
        /// <returns>Returns list of json transactions read from the file.</returns>
        private List<JsonTransaction> ReadTransactions()
        {
            if (!File.Exists(filePath))
            {
                return new List<JsonTransaction>();
            }

            var json = File.ReadAllText(filePath).Trim();

            if (string.IsNullOrWhiteSpace(json))
            {
                return new List<JsonTransaction>();
            }

            // Existing correct format
            if (json.StartsWith("["))
            {
                return JsonSerializer.Deserialize<List<JsonTransaction>>(json)
                       ?? new List<JsonTransaction>();
            }

            // One existing object from an earlier version
            if (json.StartsWith("{"))
            {
                var transaction = JsonSerializer.Deserialize<JsonTransaction>(json);

                return transaction is null
                    ? new List<JsonTransaction>()
                    : new List<JsonTransaction> { transaction };
            }

            return new List<JsonTransaction>();
        }

        /// <summary>
        /// Rewrites transaction with updated content.
        /// </summary>
        /// <param name="id">Id of the transaction to be rewritten.</param>
        /// <param name="updatedTransaction">Content to be rewritten with.</param>
        private void RewriteTransaction(Guid id, JsonTransaction updatedTransaction)
        {
            var transactions = this.ReadTransactions();

            var index = transactions.FindIndex(item => item.Id == id);

            transactions[index] = updatedTransaction;

            File.WriteAllText(
                filePath,
                JsonSerializer.Serialize(
                    transactions,
                    new JsonSerializerOptions { WriteIndented = true }));
        }
    }
}