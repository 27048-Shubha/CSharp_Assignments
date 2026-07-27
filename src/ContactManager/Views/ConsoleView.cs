namespace ContactManager
{
    using System;
    using ContactManager.Models;
    /// <summary>
    /// Manages all Console I/O Operations.
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// Displays Open Menu.
        /// </summary>
        public void DisplayMenu()
        {
            this.DisplayLineBreak();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to the Contact Manager! \nEnter your Choice:\n0. View all Contacts, \n1. Add New Contact, \n2. Edit Existing Contact, \n3. Delete a contact, \n4. Search Any Contact \n5. View Sorted List \n6. Exit");
            Console.ResetColor();
            this.DisplayLineBreak();
        }


        /// <summary>
        /// Displays Menu to Edit Contact Attributes.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public int DisplayEditMenu()
        {
            Console.WriteLine("Enter 1 to edit Name");
            Console.WriteLine("2 to edit Phone");
            Console.WriteLine("3 to edit Email");
            Console.WriteLine("4 to edit Notes");

            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Displays Line Break.
        /// </summary>
        public void DisplayLineBreak()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("------------------------------------------\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Gets Name of the Contact as Input.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string GetName()
        {
            Console.WriteLine("Enter Name: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets Phone Number of the Contact as Input.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string GetPhone()
        {
            Console.WriteLine("Enter Phone Number: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets Email Address of the Contact as Input.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string GetEmail()
        {
            Console.WriteLine("Enter Email id: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets Notes of the Contact as Input.
        /// </summary>
        /// <returns>User input receiveed.</returns>
        public string GetNotes()
        {
            Console.WriteLine("Enter Notes: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// to receive Choice inputs for Menu.
        /// </summary>
        /// <returns>Input integer received from user.</returns>
        public int GetChoice()
        {
            Console.WriteLine("Enter Choice: ");
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Display list of contacts.
        /// </summary>
        /// <param name="contact">List of contacts to be displayed.</param>
        public void DisplayContactList(List<Contact> contact)
        {
            foreach (var item in contact)
            {
                Console.WriteLine($"Name: {item.Name}\nPhone Number: {item.Phone}\nEmail Id: {item.Email}\nNotes: {item.Notes}\n");
            }
        }

        /// <summary>
        /// Displays a single contact's details.
        /// </summary>
        /// <param name="contact">Contact object whose details are to be displayed.</param>
        public void DisplayContact(Contact contact)
        {
            Console.WriteLine($"Name: {contact.Name}\nPhone Number: {contact.Phone}\nEmail Id: {contact.Email}\nNotes: {contact.Notes}\n");
        }

        /// <summary>
        /// Displays default message for menu.
        /// </summary>
        public void DisplayDefaultMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter valid inputs Only!");
            Console.ResetColor();
        }

        /// <summary>
        /// To display success message after any operation.
        /// </summary>
        public void DisplaySuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Display Empty ContactList.
        /// </summary>
        public void DisplayEmptyListMessage()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No Contacts to display\n");
            Console.ResetColor();
        }


        /// <summary>
        /// Displays about Duplicate Existance.
        /// </summary>
        public void DisplayDuplicateMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Contact already exists!");
            Console.ResetColor();
        }

        public void DisplayExitWarning()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("To confirm exit enter Y\n");
            Console.ResetColor();
        }

        public char ExitConfirmation()
        {
            return char.Parse(Console.ReadLine());
        }
        public void DisplayExitConfirmation()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you for using Contact Manager!");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Warning on Invalid Email.
        /// </summary>
        public void DisplayInvalidEmailMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Email Id! Please enter a valid email id  (Format:yourname@example.com)");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Warning on Invalid Phone number.
        /// </summary>
        public void DisplayInvalidPhoneMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Phone Number! Please enter a valid 10-digit phone number (Format:9876543210)");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Warning on Invalid Message.
        /// </summary>
        public void DisplayInvalidInputMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Input! Please enter a valid input");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Message if contact is not Found.
        /// </summary>
        public void DisplayNotFoundMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Contact not found!");
            Console.ResetColor();
        }

        /// <summary>
        /// Clears Console
        /// </summary>
        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}