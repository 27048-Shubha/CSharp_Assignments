namespace ExpenseTracker.Repository
{
    using ExpenseTracker.Models;
    using System.Text.Json;
    /// <summary>
    /// Provides repository operations for managing income transactions.
    /// </summary>
    internal class JsonIncome : ITransactionRepository<Income>
    {
        private static string filePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\Data\Transactions.json"));
        private static decimal _transactionCount = 0;
        private List<JsonTransaction> _transactions;

        /// <summary>
        /// Generates a unique transaction identifier for an income transaction.
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
        /// Retrieves all income transactions from the repository.
        /// </summary>
        /// <returns>A read-only list of all income transactions.</returns>
        public IReadOnlyList<Income> GetAll()
        {
            var jsonString = File.ReadAllText(filePath);
            IReadOnlyList<JsonTransaction> loadedTransactions = ReadTransactions();
            List<Income> incomeList = new List<Income>();

            foreach (var item in loadedTransactions)
            {
                if (item.TransactionType == "Income")
                {
                    Income income = new Income(
                        item.TransactionId,
                        item.Amount,
                        item.Date,
                        item.Source);

                    incomeList.Add(income);
                }
            }

            return (IReadOnlyList<Income>)incomeList;
        }

        /// <summary>
        /// Adds an income transaction to the repository.
        /// </summary>
        /// <param name="transaction">The income transaction to add.</param>
        public void Add(Transaction transaction)
        {
            var transactions = this.ReadTransactions();

            Income income = (Income)transaction;
            JsonTransaction newTransaction = new JsonTransaction
            {
                Id = income.Id,
                TransactionId = income.TransactionId,
                Amount = income.Amount,
                Date = income.Date,
                TransactionType = income.GetType().Name,
                Source = income.Source,
                TotalIncome = income.TotalIncome,
            };

            transactions.Add(newTransaction);
            File.WriteAllText(filePath, JsonSerializer.Serialize(transactions));
        }

        /// <summary>
        /// Updates an existing income transaction.
        /// </summary>
        /// <param name="id">The unique identifier of the income transaction to update.</param>
        /// <param name="transaction">The income transaction containing updated values.</param>
        public void Update(Guid id, Transaction transaction)
        {
            if (transaction is not Income income)
            {
                throw new ArgumentException(
                    "Only an income can be updated in JsonIncome.",
                    nameof(transaction));
            }

            RewriteTransaction(id, new JsonTransaction
            {
                Id = income.Id,
                TransactionId = income.TransactionId,
                Amount = income.Amount,
                Date = income.Date,
                TransactionType = nameof(Income),
                Source = income.Source,
                TotalIncome = income.TotalIncome
            });
        }

        /// <summary>
        /// Retrieves an income transaction using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the income transaction to retrieve.</param>
        /// <returns>The matching income transaction if found; otherwise, null.</returns>
        public Income? Get(Guid id)
        {
            var jsonString = File.ReadAllText(filePath);
            List<JsonTransaction> loadedExpense = JsonSerializer.Deserialize<List<JsonTransaction>>(jsonString);

            foreach (var item in loadedExpense)
            {
                if (id == item.Id)
                {
                    return new Income(
                        item.TransactionId,
                        item.Amount,
                        item.Date,
                        item.Source);
                }
            }

            return null;
        }

        /// <summary>
        /// Retrieves the unique identifier of an income transaction using its transaction identifier.
        /// </summary>
        /// <param name="transactionId">The transaction identifier of the income transaction.</param>
        /// <returns>The unique identifier if found; otherwise, Guid.Empty.</returns>
        public Guid GetId(string transactionId)
        {
            var jsonString = File.ReadAllText(filePath);
            List<JsonTransaction> loadedExpense = JsonSerializer.Deserialize<List<JsonTransaction>>(jsonString);

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
        /// Deletes an income transaction using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the income transaction to delete.</param>
        public void Delete(Guid id)
        {
            var jsonString = File.ReadAllText(filePath);
            List<JsonTransaction> loadedExpense = JsonSerializer.Deserialize<List<JsonTransaction>>(jsonString);

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
            var transactions = ReadTransactions();

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