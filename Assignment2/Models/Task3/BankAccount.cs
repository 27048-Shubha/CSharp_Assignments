namespace Assignment2.Models.Task3
{
    public abstract class BankAccount
    {
        private string _accountNumber;
        private decimal _balance;

        public string AccountNumber
        {
            get { return _accountNumber; }
            set { _accountNumber = value; }
        }
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        public abstract bool Withdraw(decimal amount);
    }
}