namespace Assignment2.Views
{
    /// <summary>
    /// Manages Main Console Operations common to all the system
    /// </summary>
    public class MainView
    {
        public void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to Hierarchy System!\nMenu:\n'S' to enter Shape Hierarchy System\n'E' to enter Employee System\n'B' to enter Banking System\n'Q' to quit\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Invalid Input Message
        /// </summary>
        public void DisplayDefault()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Kindly Enter valid inputs only");
            Console.Clear();
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Exit Message.
        /// </summary>
        public void DisplayExitMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Quitting Application...Thank You!");
            Console.Clear();
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Lined Dashes.
        /// </summary>
        public void DisplayLineBreaker()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------------");
            Console.ResetColor();
        }
    }
}
