using ExpenseTracker.Enums;

namespace ExpenseTracker.Models.DTOs;

/// <summary>
/// Represents the data required to add a new income transaction.
/// </summary>
internal class AddIncomeDto
{
    /// <summary>
    /// Gets or sets the amount received in the income transaction.
    /// </summary>
    /// <value>
    /// A positive monetary amount.
    /// </value>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the date on which the income was received.
    /// </summary>
    /// <value>
    /// The income transaction date.
    /// </value>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Gets or sets the source from which the income was received.
    /// </summary>
    /// <value>
    /// The income source.
    /// </value>
    public IncomeSource Source { get; set; }
}