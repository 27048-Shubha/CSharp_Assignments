using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Services
{
    /// <summary>
    /// Handles all I/P Validations
    /// </summary>
    internal class ValidateContact
    {
        /// <summary>
        /// to check for existance of new contact number to avoid duplication
        /// </summary>
        /// <param name="contact"> New Object </param>
        /// <param name="contactList"> List of all existing contacts </param>
        /// <returns> true if new attribute else False </returns>
        public static bool CheckDuplicates( ContactInfo contact, List<ContactInfo> contactList )
        {
            foreach(var attribute in contactList)
            {
                if(attribute.Phone == contact.Phone)
                {
                    Console.WriteLine("Phone Number Already Exists!");
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// To check whether contactList is empty or not
        /// </summary>
        /// <param name="contactList"> Entire List of contacts in contactList </param>
        /// <returns>True if empty else False</returns>
        public static bool IsEmpty(List<ContactInfo> contactList)
        {
            if (contactList.Count != 0)
            {
                Console.WriteLine("Contact List is Empty\n");
            }
            return contactList.Count == 0;
        }

        /// <summary>
        /// to Return Index of contact searching for
        /// </summary>
        /// <param name="name">Name to be found</param>
        /// <param name="contactList">Entire list of contacts stored</param>
        /// <returns>Index of name in contactList else -1</returns>
        public static int FindIndex(string name, List<ContactInfo> contactList)
        {
            int count = 0;
            foreach(var contact in contactList)
            {
                if(contact.Name == name)
                {
                    return count;
                }
                count++;
            }
            return -1;
        }

        /// <summary>
        /// returns Sorted List
        /// </summary>
        /// <param name="contactList">List to be Sorted</param>
        public static void ViewSorted(List<ContactInfo> contactList)
        {
            contactList.Sort((a, b) => a.Name.CompareTo(b.Name));
            Console.WriteLine("NAME - PHONE NUMBER - EMAIL - NOTES");

            foreach (var contact in contactList)
            {
                Console.WriteLine($"{contact.Name} - {contact.Phone} - {contact.Email} - {contact.Phone}");
            }
        }
    }
}
