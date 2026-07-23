namespace Assignment2.Views
{
    /// <summary>
    /// Manages Console Operations of Bank Hierarchy System.
    /// </summary>
    public class BankSystemView
    {
        /// <summary>
        /// Displays Home Menu Options of Bank System.
        /// </summary>
        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to the Bank System");
            Console.WriteLine("[S] Create Checking Account");
            Console.WriteLine("[C] Create Savings Account");
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
            Console.WriteLine("[D] Deposit");
            Console.WriteLine("[W] Withdraw");
            Console.WriteLine("[B] Check Balance");
            Console.WriteLine("[Q] Quit");
        }

        /// <summary>
        /// Displays Invalid Input & Prompts to enter Input again.
        /// </summary>
        /// <returns>User's Choice Input.</returns>
        public char InvalidInput()
        {
            Console.WriteLine("Kindly Enter valid inputs only");
            return Char.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Gets Amount to be deposited.
        /// </summary>
        /// <returns>User's Input Amount.</returns>
        public string GetDepositAmount()
        {
            Console.WriteLine("Enter Amount to Deposit");
            return Console.ReadLine()
                ;
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
            Console.WriteLine($"Your current balance: {balance}");
        }

        /// <summary>
        /// Displays Withdrawal success message.
        /// </summary>
        /// <param name="amount">Amount withdrawn.</param>
        public void DepositSuccessMessage(string amount)
        {
            Console.WriteLine($"Deposit of amount {amount} is Success!");
        }

        /// <summary>
        /// Displays Withdrawal success message.
        /// </summary>
        /// <param name="amount">Amount withdrawn.</param>
        public void WithdrawSuccessMessage(string amount)
        {
            Console.WriteLine($"WithDraw of amount {amount} is Success!");
        }

        /// <summary>
        /// Displays Failure Message for Withdrawal operation
        /// </summary>
        public void WithdrawFailureMessage()
        {
            Console.WriteLine($"Invalid Amount Entered! Kindly Check Balance before WithDrawing");
        }

        /// <summary>
        /// Displays Minimum Balance Warning Message
        /// </summary>
        public void DisplayMinBalanceWarning()
        {
            Console.WriteLine("Minimum Balance Should be 100");
        }

        /// <summary>
        /// Displays Exit Message.
        /// </summary>
        public void DisplayExitMessage()
        {
            Console.WriteLine("Quitting Application...Thank You!");
        }


    }
}