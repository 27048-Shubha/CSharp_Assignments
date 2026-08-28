namespace Assignment2.Models
{
    /// <summary>
    /// Abstract class that manages _accountNumber, _balance, withdraw and deposit.
    /// </summary>
    public abstract class BankAccount
    {
        /// <summary>
        /// Minimum balance value for the account.
        /// </summary>
        protected static readonly decimal MinimumBalance = 100m;

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
        /// Attempts to withdraw the specified amount from the account balance.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        /// <returns>True, if the withdrawal is completed successfully, else if the withdrawal cannot be performed according to the account's withdrawal rules.
        /// </returns>
        public abstract bool Withdraw(decimal amount);
    }
}