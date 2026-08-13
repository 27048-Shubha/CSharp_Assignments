namespace Assignment2.Models.Task3
{
    /// <summary>
    /// Abstract class that manages accountNumber, balance, withdraw and deposit.
    /// </summary>
    public abstract class BankAccount
    {
        private string? _accountNumber;
        private decimal _balance;

        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        /// <value>The account number of the bank account.</value>
        public string? AccountNumber
        {
            get { return this._accountNumber; }
            set { this._accountNumber = value; }
        }

        /// <summary>
        /// Gets or sets account number.
        /// </summary>
        /// <value>The balance amount of the bank account.</value>
        public decimal Balance
        {
            get { return this._balance; }
            set { this._balance = value; }
        }

        /// <summary>
        /// Adds amount to the existing Balance.
        /// </summary>
        /// <param name="amount">The amount to be added to the balance.</param>
        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }

        /// <summary>
        /// Abstract method to withdraw from bank account.
        /// </summary>
        /// <param name="amount">The amount to be withdrawn.</param>
        /// <returns>True on withdrawal success, False when balance falls beyond minimum balance.</returns>
        public abstract bool Withdraw(decimal amount);
    }
}