namespace Assignment2.Models.Task3
{
    /// <summary>
    /// Manages checking account inherited from bank account class.
    /// </summary>
    public class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Implements abstract method to withdraw from savings bank account.
        /// </summary>
        /// <param name="amount">The amount to be withdrawn.</param>
        /// <returns>True on withdrawal success, False when _balance falls beyond minimum _balance.</returns>
        public override bool Withdraw(decimal amount)
        {
            if (this.Balance - amount >= 0)
            {
                this.Balance -= amount;
                return true;
            }

            return false;
        }
    }
}