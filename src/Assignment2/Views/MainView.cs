namespace Assignment2.Views
{
    using Assignment2.Validations;

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
            if (!ValidateInput.IsValidChar(value, out choice))
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to Hierarchy System!\nMenu:\n'S' to enter Shape hierarchy system\n'E' to enter Employee system\n'B' to enter Banking system\n'Q' to quit\n");
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
            Console.WriteLine("Quitting Application...Thank You!");
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
