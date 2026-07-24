namespace Assignment2.Views
{
    /// <summary>
    /// Manages Console Operations of Bank Hierarchy System.
    /// </summary>
    public class BankSystemView: MainView
    {
        /// <summary>
        /// Displays Home Menu Options of Bank System.
        /// </summary>
        public void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            base.DisplayLineBreaker();
            Console.WriteLine("Welcome to the Bank System");
            Console.WriteLine("[C] Create Checking Account:");
            Console.WriteLine("[S] Create Savings Account:");
            base.DisplayLineBreaker();
            Console.ResetColor();
        }

        /// <summary>
        /// Gets User's Menu choice.
        /// </summary>
        /// <returns>User's Input Menu.</returns>
        public char GetMenuInput()
        {
            return Char.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Displays Banking Menu Operations of Bank System.
        /// </summary>
        public void DisplayAccountMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            base.DisplayLineBreaker();
            Console.WriteLine("[D] Deposit");
            Console.WriteLine("[W] Withdraw");
            Console.WriteLine("[B] Check Balance");
            Console.WriteLine("[Q] Quit");
            base.DisplayLineBreaker();
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Invalid Input & Prompts to enter Input again.
        /// </summary>
        /// <returns>User's Choice Input.</returns>
        public char InvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Kindly Enter valid inputs only");
            Console.ResetColor();
            return Char.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Displays Invalid Input & Prompts to enter Input again.
        /// </summary>
        /// <returns>User's Choice Input.</returns>
        public void InvalidDepositInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Kindly Enter valid inputs only");
            Console.ResetColor();
        }

        /// <summary>
        /// Gets Amount to be deposited.
        /// </summary>
        /// <returns>User's Input Amount.</returns>
        public string GetDepositAmount()
        {
            Console.WriteLine("Enter Amount to Deposit");
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets Amount to be Withdraw.
        /// </summary>
        /// <returns>User's Input Amount.</returns>
        public string GetWithdrawAmount()
        {
            Console.WriteLine("Enter Amount to WithDraw");
            return Console.ReadLine();
        }
        
        /// <summary>
        /// Display Current Balance in Bank Account.
        /// </summary>
        /// <param name="balance">Current balance of the object</param>
        public void DisplayBalance(decimal balance)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your current balance: {balance}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Withdrawal success message.
        /// </summary>
        /// <param name="amount">Amount withdrawn.</param>
        public void DepositSuccessMessage(string amount)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Deposit of amount {amount} is Success!");
            Console.ResetColor();
        }


        /// <summary>
        /// Displays Withdrawal success message.
        /// </summary>
        /// <param name="amount">Amount withdrawn.</param>
        public void WithdrawSuccessMessage(string amount)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"WithDraw of amount {amount} is Success!");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Failure Message for Withdrawal operation
        /// </summary>
        public void WithdrawFailureMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid Amount Entered! Kindly Check Balance before WithDrawing");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Minimum Balance Warning Message
        /// </summary>
        public void DisplayMinBalanceWarning()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Minimum Balance Should be 100");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Info about Inital Minimum Balance
        /// </summary>
        public void DisplayMinBalanceInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thanks for creating account! Your initial balance is set to 100 by default as per policies!");
            Console.ResetColor();
        }
    }
}