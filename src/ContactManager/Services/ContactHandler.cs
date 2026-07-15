// Services/ValidateContact.cs
using ContactManager;
using ContactManager.Models;
using ContactManager.Persistance;

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
    internal class ContactHandler
    {
        private ConsoleManager _console = new ConsoleManager();
        private Repository _repo = new Repository();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        public int AddContact(ContactInfo contact)
        {
            if (ContactHandler.CheckDuplicates(contact))
            {
                return -1;
            }
            else if (Helpers.ValidatePhone(contact.Phone))
            {
                return -2;
            }
            _repo.AddContact(contact);
            return 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<ContactInfo> GetAllContactInfo()
        {
            if (_repo.Empty())
            {
                return null;
            }
            else
            {
                return _repo.ViewContact();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public int DeleteContact(string phone)
        {
            ContactInfo contact = _repo.ExistPhone(phone);
            if(contact != null)
            {
                _repo.DeleteContact(contact);
                return 1;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public ContactInfo SearchContact(string name)
        {
            if (_repo.Exist(name))
            {
                return _repo.SearchContact(name);
            }
            else
            {
                return null;
            }
        }
       
        /// <summary>
        /// to check for existance of new contact number to avoid duplication
        /// </summary>
        /// <param name="contact"> New Object </param>
        /// <returns> true if new attribute else False </returns>
        public static bool CheckDuplicates(ContactInfo contact)
        {
            if (Repository.Exists(contact.Phone))
            {
                    ConsoleManager.DisplayDuplicateMessage();
                    return false;
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
                ConsoleManager.DisplayEmptyListMessage();
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
            foreach (var contact in contactList)
            {
                if (contact.Name == name)
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

            foreach (var contact in contactList)
            {
                ConsoleManager.DisplayContactList(contact.Name, contact.Phone, contact.Email, contact.Notes);
            }
        }
    }
}