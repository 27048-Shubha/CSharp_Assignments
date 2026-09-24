namespace Assignment2.Repository
{
    using Assignment2.Models;

    /// <summary>
    /// Handles repository operations of the employee hierarchy application.
    /// </summary>
    public class BankSystemRepository
    {
        /// <summary>
        /// Constant representing minimum balance threshold.
        /// </summary>
        public const decimal MinimumBalance = 100;

        /// <summary>
        /// Intantiates and initializes object values of savings account.
        /// </summary>
        /// <returns>The details of savings account created. </returns>
        public BankAccount CreateSavingsAccount()
        {
            SavingsAccount account = new SavingsAccount();
            account.Balance = MinimumBalance;
            return account;
        }

        /// <summary>
        /// Intantiates and initializes object values of checking account.
        /// </summary>
        /// <returns>The details of checking account created. </returns>
        public BankAccount CreateCheckingAccount()
        {
            CheckingAccount account = new CheckingAccount();
            account.Balance = MinimumBalance;
            return account;
        }
    }
}