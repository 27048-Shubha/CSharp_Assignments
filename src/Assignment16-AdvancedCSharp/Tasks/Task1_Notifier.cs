using Models;

namespace Assignment16_AdvancedCSharp.Tasks
{
    /// <summary>
    /// Manages task notification system using events.
    /// </summary>
    internal class Task1_Notifier
    {
        /// <summary>
        /// Entry point of execution for task1.
        /// </summary>
        public void Run()
        {
            Notifier notifer = new ();
            notifer.OnAction += this.PrintToConsole;
            notifer.InvokeEvent();
        }

        private void PrintToConsole()
        {
            Console.WriteLine("Message from PrintToConsole!");
        }
    }
}
