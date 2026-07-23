namespace Assignment2.Models.Task3
{
    public class CheckingAccount : BankAccount
    {
        public override bool Withdraw(decimal amount)
        {
            base.Balance -= amount;
            return true;
        }
    }
}