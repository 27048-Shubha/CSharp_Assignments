namespace Assignment17_Reflections.Task_5.AsciiShiftPlugin
{
    public class AsciiShiftPlugin : IPlugin
    {
        private string Password { get; set; }

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

        public void Decrypt()
        {
            string decryptedPassword = string.Empty;
            foreach (char character in this.Password)
            {
                decryptedPassword += character - 3;
            }

            this.Display("Decrypted password:", decryptedPassword);
        }

        public void Display(string message, string password)
        {
            Console.WriteLine($"{message} " + password);
        }
    }
}