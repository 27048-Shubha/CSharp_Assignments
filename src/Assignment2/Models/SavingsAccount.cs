using Assignment2.Validators;

namespace Assignment2.Models
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
        /// <returns>Returns true on withdrawal success, false when _balance falls beyond minimum _balance.</returns>
        public override bool Withdraw(decimal amount)
        {
            if (WithDrawalValidator.IsWithdrawalAllowed(amount))
            {
                return false;
            }

            this.Balance -= amount;
            return true;
        }
    }
}