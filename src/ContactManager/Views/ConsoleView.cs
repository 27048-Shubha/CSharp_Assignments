namespace ContactManager
{
    using System;
    using ContactManager.Helpers;
    using ContactManager.Models;

    /// <summary>
    /// Manages all console I/O operations.
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// Displays open menu.
        /// </summary>
        public void DisplayWelcome()
        {
            this.DisplayLineBreak();
            ConsoleColorManager.SetColor(ConsoleColor.Blue);
            Console.WriteLine("Welcome to Contact Manager");
            Console.ResetColor();
            this.DisplayLineBreak();
        }

        /// <summary>
        /// Displays open menu.
        /// </summary>
        public void DisplayMenu()
        {
            this.DisplayLineBreak();
            ConsoleColorManager.SetColor(ConsoleColor.Blue);
            this.DisplayWelcome();
            Console.WriteLine("Enter your choice:\n0. View all contacts, \n1. Add new contact, \n2. Edit existing contact, \n3. Delete a contact, \n4. Search any contact \n5. View sorted list \n6. Exit");
            Console.ResetColor();
            this.DisplayLineBreak();
        }

        /// <summary>
        /// Displays menu to edit contact attributes.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string DisplayEditMenu()
        {
            ConsoleColorManager.SetColor(ConsoleColor.White);
            Console.WriteLine("Enter 1 to edit name");
            Console.WriteLine("2 to edit phone number");
            Console.WriteLine("3 to edit email");
            Console.WriteLine("4 to edit notes");

            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Displays menu to edit contact attributes.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string GetStorageChoice()
        {
            ConsoleColorManager.SetColor(ConsoleColor.Blue);
            Console.WriteLine("[Y] to store contacts in file");
            Console.WriteLine("Press any key to continue store in memory:");

            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Gets name of the contact as input.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string GetName()
        {
            ConsoleColorManager.SetColor(ConsoleColor.White);
            Console.WriteLine("Enter name: ");
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Gets phone number of the contact as input.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string GetPhoneNumber()
        {
            ConsoleColorManager.SetColor(ConsoleColor.White);
            Console.WriteLine("Enter phone number: ");
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Gets email id of the contact as input.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string GetEmail()
        {
            ConsoleColorManager.SetColor(ConsoleColor.White);
            Console.WriteLine("Enter email id: ");
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Gets notes of the contact as input.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string GetNotes()
        {
            ConsoleColorManager.SetColor(ConsoleColor.White);
            Console.WriteLine("Enter notes: ");
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// To receive choice inputs for menu.
        /// </summary>
        /// <returns>Input integer received from user.</returns>
        public string GetChoice()
        {
            ConsoleColorManager.SetColor(ConsoleColor.White);
            Console.WriteLine("Enter your choice: ");
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Gets file name from the user.
        /// </summary>
        /// <returns>Input file name received from the user. </returns>
        public string GetFileName()
        {
            ConsoleColorManager.SetColor(ConsoleColor.White);
            Console.WriteLine("Enter file name: ");
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Displays file not found message.
        /// </summary>
        public void DisplayFileNotFound()
        {
            ConsoleColorManager.SetColor(ConsoleColor.Red);
            Console.WriteLine("File not found! Enter Y to create new file:");
            Console.ResetColor();
        }

        /// <summary>
        /// Display list of contacts.
        /// </summary>
        /// <param name="contacts">List of contacts to be displayed.</param>
        public void DisplayContact(IReadOnlyList<Contact> contacts)
        {
            ConsoleColorManager.SetColor(ConsoleColor.White);
            foreach (var item in contacts)
            {
                Console.WriteLine($"Name: {item.Name}\nPhone Number: {item.PhoneNumber}");
                Console.WriteLine($"Email Id: {(string.IsNullOrWhiteSpace(item.Email) ? "No email id exists" : item.Email)}");
                Console.WriteLine($"Notes: {(string.IsNullOrWhiteSpace(item.Notes) ? "No notes Exists" : item.Notes)}");
            }
        }

        /// <summary>
        /// Displays default message for menu.
        /// </summary>
        public void DisplayDefaultMessage()
        {
            ConsoleColorManager.SetColor(ConsoleColor.Red);
            Console.WriteLine("Enter valid inputs only!");
            Console.ResetColor();
        }

        /// <summary>
        /// To display success message after any operation.
        /// </summary>
        /// <param name="message">Success message to be displayed.</param>
        public void DisplaySuccess(string message)
        {
            ConsoleColorManager.SetColor(ConsoleColor.Green);
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Display empty contact list.
        /// </summary>
        public void DisplayEmptyListMessage()
        {
            ConsoleColorManager.SetColor(ConsoleColor.Yellow);
            Console.WriteLine("No Contacts to display\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays about duplicate existance.
        /// </summary>
        public void DisplayDuplicateMessage()
        {
            ConsoleColorManager.SetColor(ConsoleColor.Red);
            Console.WriteLine("Contact already exists!");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays conformation for exit.
        /// </summary>
        public void DisplayExitWarning()
        {
            ConsoleColorManager.SetColor(ConsoleColor.Yellow);
            Console.WriteLine("To confirm exit enter 'Y'\n");
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
            ConsoleColorManager.SetColor(ConsoleColor.Green);
            Console.WriteLine("Thank you for using Contact Manager!");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays warning on invalid message.
        /// </summary>
        /// <param name="message">Message to be printed.</param>
        public void DisplayInvalidInputMessage(string message)
        {
            ConsoleColorManager.SetColor(ConsoleColor.Red);
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays message if contact is not found.
        /// </summary>
        public void DisplayNotFoundMessage()
        {
            ConsoleColorManager.SetColor(ConsoleColor.Red);
            Console.WriteLine("Contact not found!");
            Console.ResetColor();
        }

        /// <summary>
        /// Clears console.
        /// </summary>
        public void ClearConsole()
        {
            Console.Clear();
        }

        /// <summary>
        /// Displays line break.
        /// </summary>
        private void DisplayLineBreak()
        {
            ConsoleColorManager.SetColor(ConsoleColor.Red);
            Console.WriteLine("------------------------------------------");
            Console.ResetColor();
        }
    }
}