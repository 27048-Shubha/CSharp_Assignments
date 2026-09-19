using Models;

namespace Assignment16_AdvancedCSharp.Tasks
{
    internal class Task1_Notifier
    {
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
