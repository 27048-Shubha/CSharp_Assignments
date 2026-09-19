namespace Models
{
    internal class Notifier
    {
        public delegate void Notify();

        public event Notify OnAction;

        public void InvokeEvent()
        {
            Console.WriteLine("Invoking subscribers...");
            OnAction.Invoke();
        }
    }
}
