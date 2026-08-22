namespace Assignment2.Models
{
    /// <summary>
    /// Abstract class that manages _accountNumber, _balance, withdraw and deposit.
    /// </summary>
    public abstract class BankAccount
    {
        /// <summary>
        /// Constant representing minimum balance threshold.
        /// </summary>
        public const decimal MinimumBalance = 100;

        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        /// <value>The account number of the bank account.</value>
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        /// <value>The _balance amount of the bank account.</value>
        public decimal Balance { get; set; }

        /// <summary>
        /// Adds amount to the existing Balance.
        /// </summary>
        /// <param name="amount">The amount to be added to the _balance.</param>
        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        /// <summary>
        /// Abstract method to withdraw from bank account.
        /// </summary>
        /// <param name="amount">The amount to be withdrawn.</param>
        /// <returns>Returns true on withdrawal success, false when _balance falls beyond minimum _balance.</returns>
        public abstract bool Withdraw(decimal amount);
    }
}