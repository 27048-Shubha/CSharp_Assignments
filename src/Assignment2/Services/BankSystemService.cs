namespace Assignment2.Services
{
    using Assignment2.Models.Task3;
    using Assignment2.Repository;
    using Assignment2.Validators;

    /// <summary>
    /// Handles business logic validation and sends call to repository after validation.
    /// </summary>
    public class BankSystemService
    {
        private BankSystemRepo repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankSystemService"/> class.
        /// </summary>
        /// <param name="repo"> The object to handle repository operations. </param>
        /// <param name="validate"> The object to handle validation operations. </param>
        public BankSystemService(BankSystemRepo repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Calls repo for savings account creation.
        /// </summary>
        /// <returns> The details of the new bank account created if True, else null.</returns>
        public BankAccount CreateSavingsAccount()
        {
            return this.repo.CreateSavingsAccount();
        }

        /// <summary>
        /// Calls repo for savings account creation.
        /// </summary>
        /// <returns> The details of the new bank account created if True, else null.</returns>
        public BankAccount CreateCheckingAccount()
        {
            return this.repo.CreateCheckingAccount();
        }

        /// <summary>
        /// Gets balance amount in the current account.
        /// </summary>
        /// <param name="account">The account's balance to be checked.</param>
        /// <returns>The balance of the current account.</returns>
        public decimal CheckBalance(BankAccount account)
        {
            return account.Balance;
        }

        /// <summary>
        /// Validates and deposits amount to the bank account.
        /// </summary>
        /// <param name="account">The account on which amount to be deposited.</param>
        /// <param name="amount">The amount to be deposited.</param>
        /// <returns>True on successful deposit operation, else false.</returns>
        public bool DepositAmount(BankAccount account, string amount)
        {
            if (InputValidator.IsNumber(amount))
            {
                decimal amountDecimal = Convert.ToDecimal(amount);
                if (!InputValidator.IsZero(amountDecimal) && !InputValidator.IsNegative(amountDecimal))
                {
                    account.Deposit(amountDecimal);
                    return true;
                }

                return false;
            }

            return false;
        }

        /// <summary>
        /// Validates and withdraws amount from the account.
        /// </summary>
        /// <param name="account">The account from which amount to be withdrawn.</param>
        /// <param name="amount">The amount to be withdrawn.</param>
        /// <returns>True on successful withdrawal operation, else false.</returns>
        public bool WithdrawAmount(BankAccount account, string amount)
        {
            if (InputValidator.IsNumber(amount))
            {
                decimal amountDecimal = Convert.ToDecimal(amount);
                if (!InputValidator.IsNegative(amountDecimal))
                {
                    return account.Withdraw(amountDecimal);
                }

                return false;
            }

            return false;
        }
    }
}