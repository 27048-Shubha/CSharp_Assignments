using ExpenseTracker.Models;
using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Services;

/// <summary>
/// Provides business operations for managing expense transactions.
/// </summary>
internal sealed class ExpenseService : ITransactionService, ITransactionUpdateService<UpdateExpenseDto>
{
    /// <summary>
    /// The repository used to store, retrieve, update, and delete expense transactions.
    /// </summary>
    private readonly ExpenseRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpenseService"/> class.
    /// </summary>
    /// <param name="expenseRepository">
    /// The repository used to manage expense transactions.
    /// </param>
    public ExpenseService(ExpenseRepository expenseRepository)
    {
        this._repository = expenseRepository;
    }

    /// <summary>
    /// Converts an <see cref="Expense"/> model into a
    /// <see cref="TransactionDto"/> for display.
    /// </summary>
    /// <param name="expense">
    /// The expense transaction to convert.
    /// </param>
    /// <returns>
    /// A DTO containing the expense identifier, amount, date, and category.
    /// </returns>
    public static TransactionDto MapToDto(Expense expense)
    {
        return new TransactionDto
        {
            TransactionId = expense.TransactionId,
            Amount = expense.Amount,
            Date = expense.Date,
            CategoryOrSource = expense.Category.ToString(),
        };
    }

    /// <summary>
    /// Generates a unique display identifier for an expense transaction.
    /// </summary>
    /// <returns>
    /// A string containing the generated expense transaction identifier.
    /// </returns>
    public static string GetTransactionId()
    {
        return ExpenseRepository.GetTransactionId();
    }

    /// <summary>
    /// Validates the values required to add an expense.
    /// </summary>
    /// <param name="dto">
    /// The new expense data to validate.
    /// </param>
    public static void Validate(AddExpenseDto dto)
    {
        ValidateAmountAndDate(dto.Amount, dto.Date);
    }

    /// <summary>
    /// Validates the values required to update an expense.
    /// </summary>
    /// <param name="dto">
    /// The updated expense data to validate.
    /// </param>
    public static void Validate(UpdateExpenseDto dto)
    {
        ValidateAmountAndDate(dto.Amount, dto.Date);
    }

    /// <summary>
    /// Validates that the amount and date satisfy transaction rules.
    /// </summary>
    /// <param name="amount">
    /// The monetary amount to validate.
    /// </param>
    /// <param name="date">
    /// The transaction date to validate.
    /// </param>
    /// <exception cref="ArgumentException">
    /// Thrown when the amount is zero or negative, or when the date is in
    /// the future.
    /// </exception>
    public static void ValidateAmountAndDate(
        decimal amount,
        DateOnly date)
    {
        if (amount <= 0)
        {
            throw new ArgumentException(
                "Amount must be greater than zero.");
        }

        if (date > DateOnly.FromDateTime(DateTime.Today))
        {
            throw new ArgumentException(
                "Future dates are not allowed.");
        }
    }

    /// <summary>
    /// Adds a new expense transaction.
    /// </summary>
    /// <param name="dto">
    /// The data required to create the expense.
    /// </param>
    public void Add(AddExpenseDto dto)
    {
        Validate(dto);

        string transactionId = GetTransactionId();

        Expense expense = new (
            transactionId,
            dto.Amount,
            dto.Date,
            dto.Category);

        this._repository.Add(expense);
    }

    /// <summary>
    /// Retrieves all expense transactions and converts them into display DTOs.
    /// </summary>
    /// <returns>
    /// A read-only list containing the details of all expense transactions.
    /// </returns>
    public IReadOnlyList<TransactionDto> GetAll()
    {
        return this._repository
            .GetAll()
            .Select(MapToDto)
            .ToList();
    }

    /// <summary>
    /// Retrieves an expense transaction using its display identifier.
    /// </summary>
    /// <param name="transactionId">
    /// The display identifier of the expense transaction.
    /// </param>
    /// <returns>
    /// A <see cref="TransactionDto"/> representing the expense when found;
    /// otherwise, <see langword="null"/>.
    /// </returns>
    public TransactionDto? Get(string transactionId)
    {
        if (!this.TryGetExpense(transactionId, out Expense? expense))
        {
            return null;
        }

        return MapToDto(expense);
    }

    /// <summary>
    /// Updates an existing expense transaction.
    /// </summary>
    /// <param name="transactionId">
    /// The display identifier of the expense transaction to update.
    /// </param>
    /// <param name="dto">
    /// The updated expense values.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown when an expense with the specified identifier is not found.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown when the updated expense values are invalid.
    /// </exception>
    public void Edit(
        string transactionId,
        UpdateExpenseDto dto)
    {
        Validate(dto);

        if (!this.TryGetExpense(transactionId, out Expense expense))
        {
            throw new InvalidOperationException(
                "Expense transaction was not found.");
        }

        expense.Amount = dto.Amount;
        expense.Date = dto.Date;
        expense.Category = dto.Category;

        Guid id = this._repository.GetId(transactionId);
        this._repository.Update(id, expense);
    }

    /// <summary>
    /// Deletes an expense transaction using its display identifier.
    /// </summary>
    /// <param name="transactionId">
    /// The display identifier of the expense transaction to delete.
    /// </param>
    public void Delete(string transactionId)
    {
        Guid id = this._repository.GetId(transactionId);
        this._repository.Delete(id);
    }

    /// <summary>
    /// Attempts to retrieve an expense transaction using its display identifier.
    /// </summary>
    /// <param name="transactionId">
    /// The display identifier of the expense transaction.
    /// </param>
    /// <param name="expense">
    /// When this method returns, contains the matching expense transaction if found;
    /// otherwise, <see langword="null"/>.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the expense transaction exists;
    /// otherwise, <see langword="false"/>.
    /// </returns>
    private bool TryGetExpense(
        string transactionId,
        out Expense? expense)
    {
        Guid id = this._repository.GetId(transactionId);
        expense = this._repository.Get(id);

        return expense != null;
    }
}