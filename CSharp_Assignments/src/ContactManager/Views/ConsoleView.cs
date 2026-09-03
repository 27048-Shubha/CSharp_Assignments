namespace ContactManager
{
    using System.Collections.Generic;
    using ContactManager.Models;

    /// <summary>
    /// Manages all console I/O operations.
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// Gets name of the contact as input.
        /// </summary>
        /// <param name="inputType">Input from the user.</param>
        /// <returns>User input received.</returns>
        public string GetInput(string inputType)
        {
            this.SetColor(ConsoleColor.White);
            Console.WriteLine($"Enter {inputType}: ");
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Gets input from the user.
        /// </summary>
        /// <returns>Input string received from the user.<returns>
        public string GetName()
        {
            return this.ReadRequiredInput("Name");
        }

        /// <summary>
        /// Gets phone number as input from the user.
        /// </summary>
        /// <returns>Input received from the user.</returns>
        public string GetPhoneNumber()
        {
            return this.ReadRequiredInput("Phone number");
        }

        /// <summary>
        /// Displays the main menu.
        /// </summary>
        public void DisplayMenu()
        {
            this.DisplayLineBreak();
            this.SetColor(ConsoleColor.Blue);
            Console.WriteLine("Welcome to the Contact Manager! \n" +
                "Enter your choice:\n" +
                "0. View all contacts, \n" +
                "1. Add new contact, \n" +
                "2. Edit existing contact, \n" +
                "3. Delete a contact, \n" +
                "4. Search any contact \n" +
                "5. View sorted list \n" +
                "6. Exit");
            Console.ResetColor();
            this.DisplayLineBreak();
        }

        /// <summary>
        /// Displays menu to edit contact attributes.
        /// </summary>
        /// <returns>User input received.</returns>
        public string DisplayEditMenu()
        {
            this.SetColor(ConsoleColor.White);
            Console.WriteLine("Enter 1 to edit name\n" +
                "2 to edit phone number\n" +
                "3 to edit email\n" +
                "4 to edit notes");

            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Display list of contacts.
        /// </summary>
        /// <param name="contacts">List of contacts to be displayed.</param>
        public void DisplayContact(IReadOnlyList<Contact> contacts)
        {
            this.SetColor(ConsoleColor.White);
            if (!this.IsEmpty(contacts))
            {
                foreach (var item in contacts)
                {
                    Console.WriteLine($"Name: {item.Name}\nPhone Number: {item.PhoneNumber}");
                    Console.WriteLine($"Email Id: {(string.IsNullOrWhiteSpace(item.Email) ? "No email id exists" : item.Email)}");
                    Console.WriteLine($"Notes: {(string.IsNullOrWhiteSpace(item.Notes) ? "No notes Exists" : item.Notes)}");
                }
            }
        }

        /// <summary>
        /// To display success message after any operation.
        /// </summary>
        /// <param name="message">Success message to be displayed.</param>
        public void DisplaySuccess(string message)
        {
            this.SetColor(ConsoleColor.Green);
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Confirms exit before closing the console.
        /// </summary>
        /// <returns>Trimmed Input entered by the user.</returns>
        public string ExitConfirmation()
        {
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Displays thank you message for using contact manager.
        /// </summary>
        public void DisplayExitConfirmation()
        {
            this.SetColor(ConsoleColor.Green);
            Console.WriteLine("Thank you for using Contact Manager!");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays confirmation for exit.
        /// </summary>
        /// <param name="message">Warning message to be displayed from the input.</param>
        public void DisplayWarning(string message)
        {
            this.SetColor(ConsoleColor.Yellow);
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays error message.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public void DisplayErrorMessage(string message)
        {
            this.SetColor(ConsoleColor.Red);
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays confirmation for exit.
        /// </summary>
        public void DisplayExitWarning()
        {
            this.SetColor(ConsoleColor.Yellow);
            Console.WriteLine("To confirm exit enter 'Y'\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Clears console.
        /// </summary>
        public void ClearConsole()
        {
            Console.Clear();
        }

        private string ReadRequiredInput(string fieldName)
        {
            string input;
            do
            {
                Console.WriteLine($"Enter {fieldName}:");
                input = (Console.ReadLine() ?? string.Empty).Trim();
            }
            while (string.IsNullOrEmpty(input));

            return input;
        }

        /// <summary>
        /// Displays dashed lines in console.
        /// </summary>
        private void DisplayLineBreak()
        {
            this.SetColor(ConsoleColor.Red);
            Console.WriteLine("------------------------------------------");
            Console.ResetColor();
        }

        private void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        private bool IsEmpty(IReadOnlyList<Contact> contact)
        {
            if (contact.Count() == 0)
            {
                this.DisplayWarning("No contacts to display\n");
                return true;
            }

            return false;
        }
    }
}