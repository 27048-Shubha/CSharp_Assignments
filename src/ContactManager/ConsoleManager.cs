// Console.cs
using ContactManager.Models;
using System;

namespace ContactManager
{
    public class Console
    {
        public static void DisplayMenu()
        {
            System.Console.WriteLine("Welcome to the Contact Manager! \nENTER 0 to VIEW ALL CONTACT, \n1 TO ADD NEW CONTACT, \n2 TO EDIT EXSISTING CONTACT, \n3 TO DELETE ANY CONTACT, \n4 TO SEARCH ANY CONTACT, \n5 TO VIEW SORTED LIST\n6 TO EXIT\n");
        }

        public static void DisplayDefaultMessage()
        {
            System.Console.WriteLine("Enter Valid Inputs Only!");
        }

        public static void DisplayEmptyListMessage()
        {
            System.Console.WriteLine("No Contacts to display\n");
        }

        public static void DisplayContactList(ContactInfo contact)
        {
            System.Console.WriteLine($"NAME: {contact.Name}\nPHONE NUMBER: {contact.Phone}\nEMAIL: {contact.Email}\nNOTES: {contact.Notes}\n\n");
        }

        public static void DisplayDuplicateMessage()
        {
            System.Console.WriteLine("Contact Already Exists!");
        }

        public static string getName()
        {
            System.Console.WriteLine("Enter Name: ");
            return System.Console.ReadLine();
        }

        public static string getPhone()
        {
            System.Console.WriteLine("Enter Phone Number: ");
            return System.Console.ReadLine();
        }

        public static string getEmail()
        {
            System.Console.WriteLine("Enter Email Address: ");
            return System.Console.ReadLine();
        }

        public static string getNotes()
        {
            System.Console.WriteLine("Enter Notes: ");
            return Console.ReadLine();
        }

        public static void DisplayInvalidPhoneMessage()
        {
            System.Console.WriteLine("Invalid Phone Number! Please enter a valid 10-digit phone number (Format:9876543210)");
        }

        public static void DisplayEditMenu()
        {
            System.Console.WriteLine("Enter 1 to edit Name\n2 to edit Phone\n3 to edit Email\n4 to edit Notes\n");
        }

        public static void DisplayNotFoundMessage()
        {   
            System.Console.WriteLine("Contact Not Found!");
        }

    }
}