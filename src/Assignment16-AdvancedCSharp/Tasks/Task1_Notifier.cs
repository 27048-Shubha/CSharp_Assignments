namespace Assignment16_AdvancedCSharp.Tasks
{
    internal class Task1_Notifier
    {
        public delegate void Notify();

        public event Notify OnAction;

        public void InvokeEvent()
        {
            Console.WriteLine("Invoking subscribers...");
            this.OnAction.Invoke();
        }
    }
}
