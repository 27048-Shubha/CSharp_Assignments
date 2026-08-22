namespace Assignment2.Models
{
    /// <summary>
    /// Abstract class that manages _accountNumber, _balance, withdraw and deposit.
    /// </summary>
    public abstract class BankAccount
    {
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
        /// Withdraws the specified amount from the bank account and updates the balance if the withdrawal satisfies the account's withdrawal rules.
        /// </summary>
        /// <param name="amount">The amount to withdraw.</param>
        /// <returns> Returns true if the withdrawal is successful and the amount is deducted from the account balance; otherwise,false. </returns>
        public abstract bool Withdraw(decimal amount);
    }
}