namespace Assignment16_AdvancedCSharp.Tasks
{
    using Assignment16_AdvancedCSharp.Models;

    /// <summary>
    /// Manages task notification system using events.
    /// </summary>
    public class Task1Notifier
    {
        /// <summary>
        /// Entry point of execution for task1.
        /// </summary>
        public void Run()
        {
            Notifier notifier = new ();
            notifier.OnAction += PrintToConsole;
            notifier.RaiseAction("Message from PrintToConsole!");
            notifier.OnAction -= PrintToConsole;
        }

        private static void PrintToConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}
