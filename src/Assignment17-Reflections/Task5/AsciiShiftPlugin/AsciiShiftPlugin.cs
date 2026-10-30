namespace Assignment17_Reflections.Task5.AsciiShiftPlugin
{
    using Assignment17_Reflections.Task5.PluginInterface;

    /// <summary>
    /// Represents Ascii Shift plugin by implementing <see cref="IPlugin"/> interface.
    /// </summary>
    public class AsciiShiftPlugin : IPlugin
    {
        /// <summary>
        /// Gets name of the plugin.
        /// </summary>
        /// <value>Ascii Shift Plugin</value>
        public string Name => "Ascii Shift Plugin";

        private string Password { get; set; }

        /// <summary>
        /// Encrypts given password.
        /// </summary>
        /// <param name="password">Password to be encrypted.</param>
        public void Encrypt(string password)
        {
            string encryptedPassword = string.Empty;
            foreach (char character in password)
            {
                encryptedPassword += character + 3;
            }

            this.Password = encryptedPassword;
            this.Display("Encrypted password:", this.Password);
        }

        /// <summary>
        /// Decrypts given password.
        /// </summary>
        /// <param name="password">Password to be decrypted.</param>
        public void Decrypt()
        {
            string decryptedPassword = string.Empty;
            foreach (char character in this.Password)
            {
                decryptedPassword += character - 3;
            }

            this.Display("Decrypted password:", decryptedPassword);
        }

        /// <summary>
        /// Displays the message and the password.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        /// <param name="password">Password to be displayed.</param>
        public void Display(string message, string password)
        {
            Console.WriteLine($"{message} " + password);
        }
    }
}