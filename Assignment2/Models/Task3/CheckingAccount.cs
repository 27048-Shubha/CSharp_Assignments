namespace Assignment2.Models.Task3
{
    /// <summary>
    /// Manages Checking Account inherited from Bank Account class.
    /// </summary>
    public class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Implementation of Abstract method that checks and updates balance
        /// </summary>
        /// <param name="amount">Amount tot be Withdrawn</param>
        /// <returns>True on </returns>
        public override bool Withdraw(decimal amount)
        {
            base.Balance -= amount;
            return true;
        }
    }
}