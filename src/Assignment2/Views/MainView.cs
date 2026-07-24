namespace Assignment2.Views
{
    /// <summary>
    /// Manages Main Console Operations common to all the system
    /// </summary>
    public class MainView
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Welcome to Hierarchy System!\nMenu:\n'S' to enter Shape Hierarchy System\n'E' to enter Employee System\n'B' to enter Banking System\n'Q' to quit\n");
        }

        /// <summary>
        /// Displays Invalid Input Message
        /// </summary>
        public void DisplayDefault()
        {
            Console.WriteLine("Kindly Enter valid inputs only");
            Console.Clear();

        }

        /// <summary>
        /// Displays Exit Message.
        /// </summary>
        public void DisplayExitMessage()
        {
            Console.WriteLine("Quitting Application...Thank You!");
            Console.Clear();
        }
    }
}
