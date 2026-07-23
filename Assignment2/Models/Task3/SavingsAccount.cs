namespace Assignment2.Models.Task3
{
    public class SavingsAccount : BankAccount
    {
        public override bool Withdraw(decimal amount)
        {
            if (base.Balance - amount < 100)
            {
                return false;
            }
            base.Balance -= amount;
            return true;
        }
    }
}