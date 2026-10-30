namespace Assignment17_Reflections.Task5.PluginInterface
{
    /// <summary>
    /// Represents contract for plugins.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Gets name of the plugin.
        /// </summary>
        /// <value>Name of the plugin.</value>
        public string Name { get; }

        /// <summary>
        /// Encrypts password.
        /// </summary>
        /// <param name="passwod">Password to be encrypted.</param>
        public void Encrypt(string passwod);

        /// <summary>
        /// Decrypts password.
        /// </summary>
        public void Decrypt();

        /// <summary>
        /// Displays the message and the password.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        /// <param name="password">Password to be displayed.</param>
        public void Display(string message, string password);
    }
}