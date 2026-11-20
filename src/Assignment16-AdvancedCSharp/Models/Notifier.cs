namespace Assignment16_AdvancedCSharp.Models
{
    /// <summary>
    /// Manages notification process.
    /// </summary>
    internal sealed class Notifier
    {
        /// <summary>
        /// Delegate representing notification call.
        /// </summary>
        /// <param name="message">Notification message</param>
        public delegate void Notify(string message);

        /// <summary>
        /// Event representing notification call.
        /// </summary>
        public event Notify? OnAction;

        /// <summary>
        /// Invokes event notify.
        /// </summary>
        /// <param name="message">Message for the event.</param>
        public void RaiseAction(string message)
        {
            this.OnAction?.Invoke(message);
        }
    }
}
