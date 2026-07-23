using Assignment2.Models.Task3;
using Assignment2.Repository;
using Assignment2.Validations;

namespace Assignment2.Services
{
    /// <summary>
    /// Manages Services of Banking System
    /// </summary>
    public class BankSystemService
    {
        private BankSystemRepo _repo = new BankSystemRepo();
        private ValidateInput _validate = new ValidateInput();
        /// <summary>
        /// Checks and passes to the Savings Account Repository
        /// </summary>
        /// <returns> Details of the BankAccount If True, else null</returns>
        public BankAccount CreateSavingsAccount()
        {
            //if(_repo.ValidateSalary(salary))
            {
                return _repo.CreateSavingsAccount();
            }
            return null;
        }

        /// <summary>
        /// Checks and passes to the Savings Account Repository
        /// </summary>
        /// <returns> Details of the BankAccount If True, else null</returns>
        public BankAccount CreateCheckingAccount()
        {
            //if(_repo.ValidateSalary(salary))
            {
                return _repo.CreateCheckingAccount();
            }
            return null;
        }

        /// <summary>
        /// Checks Balance based on current object.
        /// </summary>
        /// <param name="account">Account whose balance to be checked.</param>
        /// <returns>Balance of the current account.</returns>
        public decimal CheckBalance(BankAccount account)
        {
            return account.Balance;
        }

        public bool DepositAmount(BankAccount account, string amount)
        {
            if (_validate.IsNumber(amount))
            {
                decimal amountDecimal = Convert.ToDecimal(amount);
                if(!_validate.IsZero(amountDecimal) && !_validate.IsNegative(amountDecimal))
                {
                    account.Deposit(amountDecimal);
                    return true;
                }
                return false;
            }
            return false;
        }

        public bool WithdrawAmount(BankAccount account, string amount)
        {
            if (_validate.IsNumber(amount))
            {
                decimal amountDecimal = Convert.ToDecimal(amount);
                if (!_validate.IsZero(amountDecimal) && !_validate.IsNegative(amountDecimal))
                {
                    return account.Withdraw(amountDecimal);
                }
                return false;
            }
            return false;
        }
    }
}