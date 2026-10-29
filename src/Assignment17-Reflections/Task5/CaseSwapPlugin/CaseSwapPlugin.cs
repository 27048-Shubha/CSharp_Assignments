namespace Assignment17_Reflections.Task_5.CaseSwapPlugin
{
    public class CaseSwapPlugin : IPlugin
    {
        public string Name => "Case Swap Plugin";
        private string Password { get; set; }

        public void Encrypt(string password)
        {
            string encryptedPassword = string.Empty;
            foreach (char character in password)
            {
                if (Char.IsLower(character))
                {
                    encryptedPassword += Char.ToUpper(character);
                }
                else if (Char.IsUpper(character))
                {
                    encryptedPassword += Char.ToLower(character);
                }
                else
                {
                    encryptedPassword += character;
                }
            }

            this.Password = encryptedPassword;
            this.Display("Encrypted password:", this.Password);
        }

        public void Decrypt()
        {
            string decryptedPassword = string.Empty;
            foreach (char character in this.Password)
            {
                if (Char.IsLower(character))
                {
                    decryptedPassword += Char.ToUpper(character);
                }
                else if (Char.IsUpper(character))
                {
                    decryptedPassword += Char.ToLower(character);
                }
                else
                {
                    decryptedPassword += character;
                }
            }

            this.Display("Decrypted password:", decryptedPassword);
        }

        public void Display(string message, string password)
        {
            Console.WriteLine($"{message} " + password);
        }
    }
}