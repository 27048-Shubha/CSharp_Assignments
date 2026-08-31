using ExpenseTracker.Enums;

namespace ExpenseTracker.Models.DTOs;

/// <summary>
/// Represents the editable values of an existing income transaction.
/// </summary>
internal class UpdateIncomeDto
{
    /// <summary>
    /// Gets or sets the identifier of the income transaction to update.
    /// </summary>
    /// <value>
    /// The transaction's display identifier.
    /// </value>
    public string TransactionId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the updated income amount.
    /// </summary>
    /// <value>
    /// A positive monetary amount.
    /// </value>
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the updated income date.
    /// </summary>
    /// <value>
    /// The date on which the income was received.
    /// </value>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Gets or sets the updated income source.
    /// </summary>
    /// <value>
    /// The new source assigned to the income.
    /// </value>
    public IncomeSource Source { get; set; }
}