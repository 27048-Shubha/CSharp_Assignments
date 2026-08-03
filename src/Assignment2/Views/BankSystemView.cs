namespace Assignment2.Views
{
    /// <summary>
    /// Manages console operations of the bank hierarchy system.
    /// </summary>
    public class BankSystemView : MainView
    {
        /// <summary>
        /// Displays start up menu for shape system.
        /// </summary>
        public override void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            this.DisplayLineBreaker();
            Console.WriteLine("Welcome to the Bank System");
            Console.WriteLine("[C] Create checking account:");
            Console.WriteLine("[S] Create savings account:");
            Console.WriteLine("[Q] to Quit");
            this.DisplayLineBreaker();
            Console.ResetColor();
        }

        /// <summary>
        /// Displays banking menu operations of the bank system.
        /// </summary>
        public void DisplayAccountMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            this.DisplayLineBreaker();
            Console.WriteLine("[D] Deposit");
            Console.WriteLine("[W] Withdraw");
            Console.WriteLine("[B] Check Balance");
            Console.WriteLine("[Q] Quit");
            this.DisplayLineBreaker();
            Console.ResetColor();
        }

        /// <summary>
        /// Gets amount to be deposited.
        /// </summary>
        /// <returns> The amount entered by the user as input. </returns>
        public string GetDepositAmount()
        {
            Console.WriteLine("Enter Amount to Deposit");
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Gets amount to be withdrawn.
        /// </summary>
        /// <returns> The amount entered by the user as input. </returns>
        public string GetWithdrawAmount()
        {
            Console.WriteLine("Enter Amount to WithDraw");
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Display current balance amount in the bank account object.
        /// </summary>
        /// <param name="balance">current balance amount in the bank account object.</param>
        public void DisplayBalance(decimal balance)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your current balance: {balance}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays success message of the deposit operation.
        /// </summary>
        /// <param name="amount"> The amount deposited in the bank account.</param>
        public void DepositSuccessMessage(string amount)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Deposit of amount {amount} is Success!");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays success message of withdrawal operation.
        /// </summary>
        /// <param name="amount">The amount withdrawn from the bank account.</param>
        public void WithdrawSuccessMessage(string amount)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"WithDraw of amount {amount} is Success!");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays failure message of withdrawal operation.
        /// </summary>
        public void WithdrawFailureMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid Amount Entered! Kindly Check Balance before WithDrawing");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays minimum balance warning message.
        /// </summary>
        public void DisplayMinBalanceWarning()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Minimum Balance Should be 100");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays initial balance information.
        /// </summary>
        public void DisplayMinBalanceInfo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thanks for creating account! Your initial balance is set to 100 by default as per policies!");
            Console.ResetColor();
        }
    }
}