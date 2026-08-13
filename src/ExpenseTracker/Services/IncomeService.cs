namespace ExpenseTracker.Services
{
    using ExpenseTracker.Models;
    using ExpenseTracker.Models.DTOs;
    using ExpenseTracker.Repository;

    /// <summary>
    /// rovides business operations for income transactions.
    /// </summary>
    internal class IncomeService : ITransactionService, ITransactionUpdateService<UpdateIncomeDto>
    {
        private IncomeRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="IncomeService"/> class.
        /// </summary>
        /// <param name="incomeRepository">The repository used to store and retrieve income transactions.</param>
        public IncomeService(IncomeRepository incomeRepository)
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
        public static void Validate(UpdateIncomeDto dto)
        {
            ValidateAmountAndDate(dto.Amount, dto.Date);
        }

        /// <summary>
        /// Generates a unique display identifier for an income transaction.
        /// </summary>
        /// <returns> A string identifier prefixed with the letter I.</returns>
        public static string GetTransactionId()
        {
            return IncomeRepository.GetTransactionId();
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
        ///  Retrieves all income transactions.
        /// </summary>
        /// <returns> A read-only list containing the income transactions.</returns>
        public IReadOnlyList<TransactionDto> GetAll()
        {
            return this._repository.GetAll().Select(MapToDto).ToList();
        }

        /// <summary>
        /// Updates an existing income transaction.
        /// </summary>
        /// <param name="transactionId">Transaction Id of the transaction to be edited.</param>
        /// <param name="dto">Dto for Updation of Income</param>
        /// <exception cref="InvalidOperationException">Raises when income transaction is not found.</exception>
        public void Edit(string transactionId, UpdateIncomeDto dto)
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

            return income != null;
        }
    }
}
