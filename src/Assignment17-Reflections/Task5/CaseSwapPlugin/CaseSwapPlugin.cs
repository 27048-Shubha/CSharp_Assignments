namespace Assignment17_Reflections.Task5.CaseSwapPlugin
{
    using Assignment17_Reflections.Task5.PluginInterface;

    /// <summary>
    /// Represents Case swap plugin by implementing <see cref="IPlugin"/> interface.
    /// </summary>
    public class CaseSwapPlugin : IPlugin
    {
        /// <summary>
        /// Gets name of the plugin.
        /// </summary>
        /// <value>Ascii Shift Plugin</value>
        public string Name => "Case Swap Plugin";

        private string Password { get; set; } = string.Empty;

        /// <summary>
        /// Encrypts given password.
        /// </summary>
        /// <param name="password">Password to be encrypted.</param>
        public void Encrypt(string password)
        {
            string encryptedPassword = string.Empty;
            foreach (char character in password)
            {
                if (char.IsLower(character))
                {
                    encryptedPassword += char.ToUpper(character);
                }
                else if (char.IsUpper(character))
                {
                    encryptedPassword += char.ToLower(character);
                }
                else
                {
                    encryptedPassword += character;
                }
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
                if (char.IsLower(character))
                {
                    decryptedPassword += char.ToUpper(character);
                }
                else if (char.IsUpper(character))
                {
                    decryptedPassword += char.ToLower(character);
                }
                else
                {
                    decryptedPassword += character;
                }
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