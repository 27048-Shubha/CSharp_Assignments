namespace Assignment2.Models.Task3
{
    /// <summary>
    /// Abstract class that Manages AccountNumber, Balance, WithDraw and Deposit
    /// </summary>
    public abstract class BankAccount
    {
        private string _accountNumber;
        private decimal _balance;

        /// <summary>
        /// Gets and Sets Account Number
        /// </summary>
        /// <value>Default Value</value>
        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }

        /// <summary>
        /// Gets and Sets Balance
        /// </summary>
        /// <value>Balance Amount</value>
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        /// <summary>
        /// Adds amount to the existing Balance.
        /// </summary>
        /// <param name="amount">Amount to be added to the Balance</param>
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        /// <summary>
        /// Abstract Method to Withdraw from Bank Account
        /// </summary>
        /// <param name="amount">Amount to be withdrawn.</param>
        /// <returns>True on withdrawal success, False When Balance Falls beyond Minimum Balance</returns>
        public abstract bool Withdraw(decimal amount);
    }
}