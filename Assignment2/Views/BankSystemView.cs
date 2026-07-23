namespace Assignment2.Views
{
    public class BankSystemView
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to the Bank System");
            Console.WriteLine("[S] Create Checking Account");
            Console.WriteLine("[C] Create Savings Account");
        }

        public char GetMenuInput()
        {
            return Char.Parse(Console.ReadLine());
        }

        public void DisplayAccountMenu()
        {
            Console.WriteLine("[D] Deposit");
            Console.WriteLine("[W] Withdraw");
            Console.WriteLine("[B] Check Balance");
            Console.WriteLine("[Q] Quit");
        }

        public char InvalidInput()
        {
            Console.WriteLine("Kindly Enter valid inputs only");
            return Char.Parse(Console.ReadLine());
        }

        public decimal GetDepositAmount()
        {
            Console.WriteLine("Enter Amount to Deposit");
            return decimal.Parse(Console.ReadLine());
        }
        public decimal GetWithdrawAmount()
        {
            Console.WriteLine("Enter Amount to WithDraw");
            return decimal.Parse(Console.ReadLine());
        }
        public void DisplayBalance(decimal balance)
        {
            Console.WriteLine($"Your current balance: {balance}");
        }
        public void WithdrawSuccessMessage(decimal amount)
        {
            Console.WriteLine($"WithDraw of amount {amount} is Success!");
        }
        public void WithdrawFailureMessage()
        {
            Console.WriteLine($"Invalid Amount Entered! Kindly Check Balance before WithDrawing");
        }

        public void DisplayMinBalanceWarning()
        {
            Console.WriteLine("Minimum Balance Should be 100");
        }
    }
}