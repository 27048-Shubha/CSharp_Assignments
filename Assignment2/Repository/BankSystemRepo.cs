using Assignment2.Models.Task3;

namespace Assignment2.Repository
{
    /// <summary>
    /// Manages Bank System Repository
    /// </summary>
    public class BankSystemRepo
    {
        /// <summary>
        /// Creates savings account 
        /// </summary>
        /// <returns>Savings account created</returns>
        public BankAccount CreateSavingsAccount()
        {
            SavingsAccount account = new SavingsAccount();
            account.Balance = 100;
            return account;
        }

        /// <summary>
        /// Creates Checking account 
        /// </summary>
        /// <returns>Checking account created</returns>
        public BankAccount CreateCheckingAccount()
        {
            CheckingAccount account = new CheckingAccount();
            account.Balance = 100;
            return account;
        }
    }
}