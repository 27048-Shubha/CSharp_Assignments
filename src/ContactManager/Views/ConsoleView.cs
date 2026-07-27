namespace ContactManager
{
    using System;
    using ContactManager.Models;

    /// <summary>
    /// Manages all console I/O operations.
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// Displays open menu.
        /// </summary>
        public void DisplayMenu()
        {
            this.DisplayLineBreak();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to the Contact Manager! \nEnter your choice:\n0. View all contacts, \n1. Add new contact, \n2. Edit existing contact, \n3. Delete a contact, \n4. Search any contact \n5. View sorted list \n6. Exit");
            Console.ResetColor();
            this.DisplayLineBreak();
        }

        /// <summary>
        /// Displays menu to edit contact attributes.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string? DisplayEditMenu()
        {
            Console.WriteLine("Enter 1 to edit name");
            Console.WriteLine("2 to edit phone number");
            Console.WriteLine("3 to edit email");
            Console.WriteLine("4 to edit notes");

            return Console.ReadLine()?.Trim();
        }

        /// <summary>
        /// Displays line break.
        /// </summary>
        public void DisplayLineBreak()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("------------------------------------------");
            Console.ResetColor();
        }

        /// <summary>
        /// Gets name of the contact as input.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string? GetName()
        {
            Console.WriteLine("Enter name: ");
            return Console.ReadLine()?.Trim();
        }

        /// <summary>
        /// Gets phone number of the contact as input.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string? GetPhone()
        {
            Console.WriteLine("Enter phone number: ");
            return Console.ReadLine()?.Trim();
        }

        /// <summary>
        /// Gets email id of the contact as input.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string? GetEmail()
        {
            Console.WriteLine("Enter email id: ");
            return Console.ReadLine()?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// Gets notes of the contact as input.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string? GetNotes()
        {
            Console.WriteLine("Enter notes: ");
            return Console.ReadLine()?.Trim();
        }

        /// <summary>
        /// To receive choice inputs for menu.
        /// </summary>
        /// <returns>Input integer received from user.</returns>
        public string? GetChoice()
        {
            Console.WriteLine("Enter your choice: ");
            return Console.ReadLine()?.Trim();
        }

        /// <summary>
        /// Display list of contacts.
        /// </summary>
        /// <param name="contact">List of contacts to be displayed.</param>
        public void DisplayContactList(List<Contact> contact)
        {
            foreach (var item in contact)
            {
                Console.WriteLine($"Name: {item.Name}\nPhone Number: {item.Phone}");
                Console.WriteLine($"Email Id: {(string.IsNullOrWhiteSpace(item.Email) ? "No email id exists" : item.Email)}");
                Console.WriteLine($"Notes: {(string.IsNullOrWhiteSpace(item.Notes) ? "No notes Exists" : item.Notes)}");
            }
        }

        /// <summary>
        /// Displays default message for menu.
        /// </summary>
        public void DisplayDefaultMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter valid inputs only!");
            Console.ResetColor();
        }

        /// <summary>
        /// To display success message after any operation.
        /// </summary>
        /// <param name="message">Success message to be displayed.</param>
        public void DisplaySuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Display empty contact list.
        /// </summary>
        public void DisplayEmptyListMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No Contacts to display\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays about duplicate existance.
        /// </summary>
        public void DisplayDuplicateMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Contact already exists!");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays conformation for exit.
        /// </summary>
        public void DisplayExitWarning()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("To confirm exit enter 'Y'\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Confirms exit before closing the console.
        /// </summary>
        /// <returns>Trimmed Input entered by the user.</returns>
        public string? ExitConfirmation()
        {
            return Console.ReadLine()?.Trim();
        }

        /// <summary>
        /// Displays thank you message for using contact manager.
        /// </summary>
        public void DisplayExitConfirmation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you for using Contact Manager!");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays warning on invalid email.
        /// </summary>
        public void DisplayInvalidInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Blank spaces aren't allowed for name! Please enter a valid input!");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays warning on invalid email.
        /// </summary>
        public void DisplayInvalidEmailMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid email id! Please enter a valid email id  (Format:yourname@example.com)");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays warning on invalid phone number.
        /// </summary>
        public void DisplayInvalidPhoneMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid phone number!\nPlease enter a valid 10-digit phone number containing only 0-9 digits\n(Format:9876543210)");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays warning on invalid message.
        /// </summary>
        public void DisplayInvalidInputMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Input! Please enter a valid input");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays message if contact is not found.
        /// </summary>
        public void DisplayNotFoundMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
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
    }
}