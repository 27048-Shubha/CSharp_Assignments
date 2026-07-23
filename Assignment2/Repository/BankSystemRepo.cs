using Assignment2.Models.Task3;

namespace Assignment2.Repository
{
    public class BankSystemRepo
    {
        public BankAccount CreateSavingsAccount()
        {
            SavingsAccount account = new SavingsAccount();
            account.Balance = 100;
            return account;
        }

        public BankAccount CreateCheckingAccount()
        {
            CheckingAccount account = new CheckingAccount();
            account.Balance = 100;
            return account;
        }
    }
}