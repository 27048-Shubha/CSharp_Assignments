namespace ExpenseTracker.Services
{
    using ExpenseTracker.Enums;
    using ExpenseTracker.Models;
    using ExpenseTracker.Models.DTOs;
    using ExpenseTracker.Repository;

    /// <summary>
    /// rovides business operations for income transactions.
    /// </summary>
    internal class IncomeService : ITransactionService, ITransactionUpdateService<IncomeDto>
    {
        private InMemoryIncome _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="IncomeService"/> class.
        /// </summary>
        /// <param name="incomeRepository">The repository used to store and retrieve income transactions.</param>
        public IncomeService(InMemoryIncome incomeRepository)
        {
            this._repository = incomeRepository;
        }

        /// <summary>
        /// Converts an <see cref="Income"/> model into a
        /// <see cref="TransactionDto"/> for display.
        /// </summary>
        /// <param name="income">
        /// The expense transaction to convert.
        /// </param>
        /// <returns>
        /// A DTO containing the expense identifier, amount, date, and category.
        /// </returns>
        public static TransactionDto MapToDto(Income income)
        {
            return new TransactionDto
            {
                TransactionId = income.TransactionId,
                Amount = income.Amount,
                Date = income.Date,
                CategoryOrSource = income.Source.ToString(),
            };
        }

        /// <summary>
        /// Converts an <see cref="Income"/> model into a
        /// <see cref="TransactionDto"/> for display.
        /// </summary>
        /// <param name="income">
        /// The income transaction to convert.
        /// </param>
        /// <returns>
        /// A DTO containing the income identifier, amount, date, and source.
        /// </returns>
        public static IncomeDto MapToIncomeDto(Income income)
        {
            return new IncomeDto
            {
                TransactionId = income.TransactionId,
                Amount = income.Amount,
                Date = income.Date,
                Source = (Enums.IncomeSource)income.Source,
            };
        }

        /// <summary>
        /// Validates the values required to add an income transaction.
        /// </summary>
        /// <param name="dto">
        /// The income creation DTO to validate.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when the amount is zero or negative, or when the date is in
        /// the future.
        /// </exception>
        public static void Validate(AddIncomeDto dto)
        {
            ValidateAmountAndDate(dto.Amount, dto.Date);
        }

        /// <summary>
        /// Validates the values required to update an income transaction.
        /// </summary>
        /// <param name="dto">
        /// The income update DTO to validate.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when the amount is zero or negative, or when the date is in
        /// the future.
        /// </exception>
        public static void Validate(IncomeDto dto)
        {
            ValidateAmountAndDate(dto.Amount, dto.Date);
        }

        /// <summary>
        /// Generates a unique display identifier for an income transaction.
        /// </summary>
        /// <returns> A string identifier prefixed with the letter I.</returns>
        public static string GetTransactionId()
        {
            return InMemoryIncome.GetTransactionId();
        }

        /// <summary>
        /// Sorts the transactions by date in ascending or descending order.
        /// </summary>
        /// <returns>Returns the total income amount.</returns>
        public decimal GetTotalIncome()
        {
            return this.GetAllIncome().Sum(income => income.Amount);
        }

        /// <summary>
        /// Validates the amount and date of an income transaction.
        /// </summary>
        /// <param name="amount">
        /// The monetary amount of the transaction.
        /// </param>
        /// <param name="date">
        /// The date of the transaction.
        /// </param>
        /// <exception cref="ArgumentException">
        /// Thrown when the amount is zero or negative, or when the date is in the
        /// future.
        /// </exception>
        public static void ValidateAmountAndDate(decimal amount, DateOnly date)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.");
            }

            if (date > DateOnly.FromDateTime(DateTime.Today))
            {
                throw new ArgumentException("Future dates are not allowed.");
            }
        }

        /// <summary>
        /// Adds a new income to the transaction
        /// </summary>
        /// <param name="dto">DTO of the transaction</param>
        public void Add(AddIncomeDto dto)
        {
            // negative amount validation
            // future date validation
            Validate(dto);
            string transactionId = GetTransactionId();
            this._repository.Add((Income)new (transactionId, dto.Amount, dto.Date, dto.Source));
        }

        /// <summary>
        /// Updates an existing income transaction.
        /// </summary>
        /// <param name="transactionId">Transaction Id of the transaction to be edited.</param>
        /// <param name="dto">Dto for Updation of Income</param>
        /// <exception cref="InvalidOperationException">Raises when income transaction is not found.</exception>
        public void Edit(string transactionId, IncomeDto dto)
        {
            Validate(dto);
            if (!this.TryGetIncome(transactionId, out Income? income))
            {
                throw new InvalidOperationException("Income transaction was not found.");
            }

            income.Amount = dto.Amount;
            income.Date = dto.Date;
            income.Source = dto.Source;

            Guid id = this._repository.GetId(transactionId);
            this._repository.Update(id, income);
        }

        /// <summary>
        /// Retrieves an income transaction using its transaction identifier.
        /// </summary>
        /// <param name="transactionId">The display identifier of the transaction.</param>
        /// <returns>The matching income transaction if found; otherwise, null.</returns>
        public TransactionDto? Get(string transactionId)
        {
            if (!this.TryGetIncome(transactionId, out Income? income))
            {
                return null;
            }

            return MapToDto(income);
        }

        /// <summary>
        /// Retrieves an income transaction using its transaction identifier.
        /// </summary>
        /// <param name="transactionId">The display identifier of the transaction.</param>
        /// <returns>The matching income transaction if found; otherwise, null.</returns>
        public IncomeDto? GetIncome(string transactionId)
        {
            if (!this.TryGetIncome(transactionId, out Income? income))
            {
                return null;
            }

            return MapToIncomeDto(income);
        }

        /// <summary>
        /// Deletes an income transaction using the transaction identifier.
        /// </summary>
        /// <param name="transactionId">The display identifier of the transaction to delete.</param>
        public void Delete(string transactionId)
        {
            Guid id = this._repository.GetId(transactionId);
            this._repository.Delete(id);
        }

        /// <summary>
        /// Deletes an income transaction using the transaction object.
        /// </summary>
        /// <param name="transaction">The income transaction to delete.</param>
        public void DeleteTransaction(Transaction transaction)
        {
            Guid id = this._repository.GetId(transaction.TransactionId);
            this._repository.Delete(id);
        }

        /// <summary>
        ///  Retrieves all income transactions.
        /// </summary>
        /// <returns> A read-only list containing the income transactions.</returns>
        public IReadOnlyList<TransactionDto> GetAll()
        {
            return this._repository.GetAll().Select(MapToDto).ToList();
        }

        /// <summary>
        ///  Retrieves all income transactions.
        /// </summary>
        /// <returns> A read-only list containing the income transactions.</returns>
        public IReadOnlyList<IncomeDto> GetAllIncome()
        {
            return this._repository.GetAll().Select(MapToIncomeDto).ToList();
        }

        /// <summary>
        /// Returns transaction list based on the income source.
        /// </summary>
        /// <param name="id">Id of the transaction to be found</param>
        /// <returns>List of transactions matching the id</returns>
        public List<IncomeDto> GetTransactionById(string id)
        {
            List<IncomeDto> transactions = this.GetAllIncome().Where(transaction => transaction.TransactionId == id).ToList();
            return transactions;
        }

        /// <summary>
        /// Returns transaction list based on the income source.
        /// </summary>
        /// <param name="incomeSource">The income source to filter by</param>
        /// <returns>List of transactions matching the income source</returns>
        public List<IncomeDto> GetTransactionByIncomeSource(Enums.IncomeSource incomeSource)
        {
            List<IncomeDto> transactions = this.GetAllIncome().Where(transaction => transaction.Source == incomeSource).ToList();
            return transactions;
        }

        /// <summary>
        /// Sorts the transactions by amount in ascending or descending order.
        /// </summary>
        /// <param name="order">Indicates whether to sort in ascending order.</param>
        /// <returns>The sorted list of transactions.</returns>
        public IReadOnlyList<TransactionDto> SortByDate(Enums.Order order)
        {
            if (order == Enums.Order.Ascending)
            {
                IReadOnlyList<TransactionDto> transactionDtos = this.GetAll().OrderBy(transaction => transaction.Date).ToList();
                return transactionDtos;
            }
            else
            {
                IReadOnlyList<TransactionDto> transactionDtos = this.GetAll().OrderByDescending(transaction => transaction.Date).ToList();
                return transactionDtos;
            }
        }

        /// <summary>
        /// Sorts the transactions by amount in ascending or descending order.
        /// </summary>
        /// <param name="order">Indicates whether to sort in ascending order.</param>
        /// <returns>The sorted list of transactions.</returns>
        public IReadOnlyList<TransactionDto> SortByAmount(Enums.Order order)
        {
            if (order == Enums.Order.Ascending)
            {
                IReadOnlyList<TransactionDto> transactionDtos = this.GetAll().OrderBy(transaction => transaction.Amount).ToList();
                return transactionDtos;
            }
            else
            {
                IReadOnlyList<TransactionDto> transactionDtos = this.GetAll().OrderByDescending(transaction => transaction.Amount).ToList();
                return transactionDtos;
            }
        }

        /// <summary>
        /// Sorts the transactions by date in ascending or descending order.
        /// </summary>
        /// <param name="order">Indicates whether to sort in ascending order.</param>
        /// <returns>The sorted list of transactions.</returns>
        public IReadOnlyList<TransactionDto> SortByTransactionId(Enums.Order order)
        {
            if (order == Enums.Order.Ascending)
            {
                IReadOnlyList<TransactionDto> transactionDtos = this.GetAll().OrderBy(transaction => transaction.TransactionId).ToList();
                return transactionDtos;
            }
            else
            {
                IReadOnlyList<TransactionDto> transactionDtos = this.GetAll().OrderByDescending(transaction => transaction.TransactionId).ToList();
                return transactionDtos;
            }
        }

        /// <summary>
        /// Attempts to retrieve an income transaction using its display identifier.
        /// </summary>
        /// <param name="transactionId">
        /// The display identifier of the income transaction.
        /// </param>
        /// <param name="income">
        /// When this method returns, contains the matching income transaction if
        /// found; otherwise, <see langword="null"/>.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the income transaction is found; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        private bool TryGetIncome(string transactionId, out Income? income)
        {
            Guid id = this._repository.GetId(transactionId);
            income = this._repository.Get(id);

            return income is not null;
        }
    }
}