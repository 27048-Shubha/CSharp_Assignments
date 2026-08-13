namespace Assignment2.Models.Task3
{
    /// <summary>
    /// Manages savings account inherited from Bank Account class.
    /// </summary>
    public class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Implements abstract method to withdraw from savings bank account.
        /// </summary>
        /// <param name="amount">The amount to be withdrawn.</param>
        /// <returns>True on withdrawal success, False when balance falls beyond minimum balance.</returns>
        public override bool Withdraw(decimal amount)
        {
            if (this.Balance - amount < 100)
            {
                return false;
            }

            this.Balance -= amount;
            return true;
        }
    }
}