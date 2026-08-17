using ExpenseTracker.Models;
using ExpenseTracker.Models.DTOs;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Services;

/// <summary>
/// Provides business operations for managing expense transactions.
/// </summary>
internal sealed class ExpenseService : ITransactionService, ITransactionUpdateService<ExpenseDto>
{
    /// <summary>
    /// The repository used to store, retrieve, update, and delete expense transactions.
    /// </summary>
    private readonly InMemoryExpense _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExpenseService"/> class.
    /// </summary>
    /// <param name="expenseRepository">
    /// The repository used to manage expense transactions.
    /// </param>
    public ExpenseService(InMemoryExpense expenseRepository)
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
    /// Converts an <see cref="Expense"/> model into a
    /// <see cref="TransactionDto"/> for display.
    /// </summary>
    /// <param name="expense">
    /// The expense transaction to convert.
    /// </param>
    /// <returns>
    /// A DTO containing the expense identifier, amount, date, and category.
    /// </returns>
    public static ExpenseDto MapToExpenseDto(Expense expense)
    {
        return new ExpenseDto
        {
            TransactionId = expense.TransactionId,
            Amount = expense.Amount,
            Date = expense.Date,
            Category = (Enums.ExpenseCategory)expense.Category,
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
        return InMemoryExpense.GetTransactionId();
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
    public static void Validate(ExpenseDto dto)
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
    ///  Retrieves all income transactions.
    /// </summary>
    /// <returns> A read-only list containing the income transactions.</returns>
    public IReadOnlyList<ExpenseDto> GetAllExpense()
    {
        return this._repository.GetAll().Select(MapToExpenseDto).ToList();
    }

    /// <summary>
    /// Retrieves an expense transaction using its display identifier.
    /// </summary>
    /// <param name="transactionId">
    /// The display identifier of the expense transaction.
    /// </param>
    /// <returns>
    /// A <see cref="ExpenseDto"/> representing the expense when found;
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
    /// Retrieves an expense transaction using its display identifier.
    /// </summary>
    /// <param name="transactionId">
    /// The display identifier of the expense transaction.
    /// </param>
    /// <returns>
    /// A <see cref="TransactionDto"/> representing the expense when found;
    /// otherwise, <see langword="null"/>.
    /// </returns>
    public ExpenseDto? GetExpense(string transactionId)
    {
        if (!this.TryGetExpense(transactionId, out Expense? expense))
        {
            return null;
        }

        return MapToExpenseDto(expense);
    }

    /// <summary>
    /// Sorts the transactions by date in ascending or descending order.
    /// </summary>
    /// <returns>Returns the total expense amount.</returns>
    public decimal GetTotalExpense()
    {
        return this.GetAllExpense().Sum(expense => expense.Amount);
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
        ExpenseDto dto)
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
    /// Returns transaction list based on the id.
    /// </summary>
    /// <param name="id">Id of the transaction to be found</param>
    /// <returns>List of transactions matching the id</returns>
    public List<TransactionDto> GetTransactionById(string id)
    {
        List<TransactionDto> transactions = this.GetAll().Where(transaction => transaction.TransactionId == id).ToList();
        return transactions;
    }

    /// <summary>
    /// Returns transaction list based on the expense category.
    /// </summary>
    /// <param name="expenseCategory">The expense category to filter by</param>
    /// <returns>List of transactions matching the expense category</returns>
    public List<ExpenseDto> GetTransactionByExpenseCategory(Enums.ExpenseCategory expenseCategory)
    {
        List<ExpenseDto> transactions = this.GetAllExpense().Where(transaction => transaction.Category == expenseCategory).ToList();
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