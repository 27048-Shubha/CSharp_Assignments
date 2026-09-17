using ExpenseTracker.Enums;

namespace ExpenseTracker.Models.DTOs;

/// <summary>
/// Represents the data required to add a new expense transaction.
/// </summary>
internal class AddExpenseDto
{
    /// <summary>
    /// Gets or sets the amount spent in the expense transaction.
    /// </summary>
    /// <value>
    /// A positive monetary amount.
    /// </value>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the date on which the expense occurred.
    /// </summary>
    /// <value>
    /// The expense transaction date.
    /// </value>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Gets or sets the category assigned to the expense.
    /// </summary>
    /// <value>
    /// The expense category.
    /// </value>
    public ExpenseCategory Category { get; set; }
}