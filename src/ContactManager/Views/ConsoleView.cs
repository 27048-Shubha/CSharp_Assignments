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
            Console.WriteLine("Welcome to the Contact Manager! \nENTER 0 to VIEW ALL CONTACT, \n1 TO ADD NEW CONTACT, \n2 TO EDIT EXSISTING CONTACT, \n3 TO DELETE ANY CONTACT, \n4 TO SEARCH ANY CONTACT, \n5 TO VIEW SORTED LIST\n6 TO EXIT");
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
            Console.WriteLine("Enter Email Address: ");
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
                Console.WriteLine($"NAME: {item.Name}\nPHONE NUMBER: {item.Phone}\nEMAIL: {item.Email}\nNOTES: {item.Notes}\n");
            }
        }

        /// <summary>
        /// Displays a single contact's details.
        /// </summary>
        /// <param name="contact">Contact object whose details are to be displayed.</param>
        public void DisplayContact(Contact contact)
        {
            Console.WriteLine($"NAME: {contact.Name}\nPHONE NUMBER: {contact.Phone}\nEMAIL: {contact.Email}\nNOTES: {contact.Notes}\n");
        }

        /// <summary>
        /// Displays default message for menu.
        /// </summary>
        public void DisplayDefaultMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter Valid Inputs Only!");
            Console.ResetColor();
        }

        /// <summary>
        /// To display success message after any operation.
        /// </summary>
        public void DisplaySuccess()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Operation Success!\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Display Empty ContactList.
        /// </summary>
        public void DisplayEmptyListMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No Contacts to display\n");
            Console.ResetColor();
        }


        /// <summary>
        /// Displays about Duplicate Existance.
        /// </summary>
        public void DisplayDuplicateMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Contact Already Exists!");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays Warning on Invalid Email.
        /// </summary>
        public void DisplayInvalidEmailMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid Email Id! Please enter a valid Email Id");
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
            Console.WriteLine("Contact Not Found!");
            Console.ResetColor();
        }
    }
}