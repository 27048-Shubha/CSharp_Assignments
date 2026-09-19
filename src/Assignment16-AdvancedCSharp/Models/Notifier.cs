namespace Models
{
    /// <summary>
    /// Manages notification process.
    /// </summary>
    internal class Notifier
    {
        /// <summary>
        /// Delegate representing notification call.
        /// </summary>
        public delegate void Notify();

        /// <summary>
        /// Event representing notification call.
        /// </summary>
        public event Notify OnAction;

        /// <summary>
        /// Invokes event notify.
        /// </summary>
        public void InvokeEvent()
        {
            Console.WriteLine("Invoking subscribers...");
            this.OnAction.Invoke();
        }
    }
}
