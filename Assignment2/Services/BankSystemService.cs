using Assignment2.Models.Task3;
using Assignment2.Repository;

namespace Assignment2.Services
{
    public class BankSystemService
    {
        private BankSystemRepo _repo = new BankSystemRepo();

        public BankAccount CreateSavingsAccount()
        {
            //if(_repo.ValidateSalary(salary))
            {
                return _repo.CreateSavingsAccount();
            }
            return null;
        }

        public BankAccount CreateCheckingAccount()
        {
            //if(_repo.ValidateSalary(salary))
            {
                return _repo.CreateCheckingAccount();
            }
            return null;
        }
        public decimal CheckBalance(BankAccount account)
        {
            return account.Balance;
        }
    }
}