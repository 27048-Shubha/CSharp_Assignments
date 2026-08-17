using System.Text.Json;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Provides repository operations for managing income transactions.
    /// </summary>
    internal class JsonIncome : ITransactionRepository
    {
        private static string filePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.FullName, "Data");
        private static decimal _transactionCount = 0;

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
            IReadOnlyList<Income> loadedIncome = JsonSerializer.Deserialize<IReadOnlyList<Income>>(jsonString);
            return loadedIncome;
        }

        /// <summary>
        /// Adds an income transaction to the repository.
        /// </summary>
        /// <param name="transaction">The income transaction to add.</param>
        public void Add(Transaction transaction)
        {
            var jsonString = JsonSerializer.Serialize(transaction);
            File.WriteAllText(filePath, jsonString);
        }

        /// <summary>
        /// Updates an existing income transaction.
        /// </summary>
        /// <param name="id">The unique identifier of the income transaction to update.</param>
        /// <param name="incomeDetails">The income transaction containing updated values.</param>
        public void Update(Guid id, Transaction incomeDetails)
        {
            Income income = (Income)incomeDetails;
            var jsonString = File.ReadAllText(filePath);
            List<Income> loadedIncome = JsonSerializer.Deserialize<List<Income>>(jsonString);

            foreach (var item in loadedIncome)
            {
                if (id == item.Id)
                {
                    item.Amount = income.Amount;
                    item.Date = income.Date;
                    item.Source = income.Source;
                }
            }

            File.WriteAllText(filePath, JsonSerializer.Serialize(income));
        }

        /// <summary>
        /// Retrieves an income transaction using its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the income transaction to retrieve.</param>
        /// <returns>The matching income transaction if found; otherwise, null.</returns>
        public Income? Get(Guid id)
        {
            var jsonString = File.ReadAllText(filePath);
            List<Income> loadedIncome = JsonSerializer.Deserialize<List<Income>>(jsonString);

            foreach (var item in loadedIncome)
            {
                if (id == item.Id)
                {
                    return item;
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
            List<Income> loadedIncome = JsonSerializer.Deserialize<List<Income>>(jsonString);

            foreach (var item in loadedIncome)
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
            List<Income> loadedIncome = JsonSerializer.Deserialize<List<Income>>(jsonString);

            var updatedIncome = loadedIncome.FindAll(income => income.Id == id);
            File.WriteAllText(filePath, JsonSerializer.Serialize(updatedIncome));
        }
    }
}