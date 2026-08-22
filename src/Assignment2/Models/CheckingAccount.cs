using Assignment2.Validators;

namespace Assignment2.Models
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
        /// <returns>Returns true on withdrawal success, false when _balance falls beyond minimum _balance.</returns>
        public override bool Withdraw(decimal amount)
        {
            if (WithDrawalValidator.IsWithdrawalAllowed(amount))
            {
                this.Balance -= amount;
                return true;
            }

            return false;
        }
    }
}