namespace Assignment2.Views
{
    using Assignment2.Validators;

    /// <summary>
    /// Manages main console operations of the application.
    /// </summary>
    public class MainView
    {
        /// <summary>
        /// Gets user choice as input.
        /// </summary>
        /// <returns>The value entered by the user or default.</returns>
        public char GetUserChoice()
        {
            char choice;
            char defaultChoice = 'D';
            string value = Console.ReadLine() ?? string.Empty;
            if (!InputValidator.IsValidChar(value, out choice))
            {
                return defaultChoice;
            }

            return choice;
        }

        /// <summary>
        /// Displays main welcome menu of the application.
        /// </summary>
        public virtual void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome to hierarchy system!");
            Console.WriteLine("Menu:");
            Console.WriteLine("[S] Shape System");
            Console.WriteLine("[E] Employee System");
            Console.WriteLine("[B] Banking System");
            Console.WriteLine("[Q] Quit");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays invalid input message.
        /// </summary>
        public void DisplayDefault()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Kindly enter valid inputs only");
            Thread.Sleep(1000);
            Console.Clear();
            Console.ResetColor();
        }

        /// <summary>
        /// Displays the exit message.
        /// </summary>
        public void DisplayExitMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Quitting application... Thank you!");
            Thread.Sleep(1000);
            Console.Clear();
            Console.ResetColor();
        }

        /// <summary>
        /// Displays dashed lines.
        /// </summary>
        public void DisplayLineBreaker()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------------");
            Console.ResetColor();
        }
    }
}