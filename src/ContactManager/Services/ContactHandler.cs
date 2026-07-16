// Services/ValidateContact.cs
using System;
using System.Collections.Generic;

using ContactManager;
using ContactManager.Helpers;
using ContactManager.Models;
using ContactManager.Persistance;

namespace ContactManager.Services
{
    /// <summary>
    /// Handles all I/P Validations
    /// </summary>
    internal class ContactHandler
    {
        private Repository _repo = new Repository();

        /// <summary>
        /// to Add new contact to the list
        /// </summary>
        /// <param name="contact">Contact information to add</param>
        /// <returns>Status of the operation</returns>
        public int AddContact(ContactInfo contact)
        {
            if (CheckDuplicates(contact))
            {
                return -1;
            }
            else if (!ContactManager.Helpers.Helpers.ValidatePhone(contact.Phone ?? ""))
            {
                return -2;
            }
            _repo.AddContact(contact);
            return 1;
        }

        /// <summary>
        /// to Get all contact information
        /// </summary>
        /// <returns>List of all contacts or null if empty</returns>
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
        /// to Search for a contact by name
        /// </summary>
        /// <param name="phone">Phone number of the contact to search for</param>
        /// <returns>Status of the operation</returns>
        public int DeleteContact(string phone)
        {
            ContactInfo contact = _repo.ExistPhone(phone);
            if (contact != null)
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
        /// to Edit contact information
        /// </summary>
        /// <param name="name">Name of the contact to edit</param>
        /// <param name="editChoice">Choice of attribute to edit</param>
        /// <param name="newValue">New value for the attribute</param>
        /// <returns>Status of the operation</returns>
        public int EditContact(string name, int editChoice, string newValue)
        {
            ContactInfo contact = _repo.SearchContact(name);
            if (contact == null)
            {
                return -1;
            }
            switch (editChoice)
            {
                case 1:
                    _repo.EditName(contact, newValue);
                    break;

                case 2:
                    _repo.EditPhone(contact, newValue);
                    break;

                case 3:
                    _repo.EditEmail(contact, newValue);
                    break;

                case 4:
                    _repo.EditNotes(contact, newValue);
                    break;

                default:
                    return -2;
            }
            return 1;
        }

        /// <summary>
        /// to Search for a Contact
        /// </summary>
        /// <param name="name">Name of the contact to search for</param>
        /// <returns>ContactInfo object if found, otherwise null</returns>
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
        public bool CheckDuplicates(ContactInfo contact)
        {
            return _repo.ExistPhone(contact.Phone) != null;
        }

        /// <summary>
        /// To check whether contactList is empty or not
        /// </summary>
        /// <param name="contactList"> Entire List of contacts in contactList </param>
        /// <returns>True if empty else False</returns>
        public bool IsEmpty(List<ContactInfo> contactList)
        {
            return contactList.Count == 0;
        }

        /// <summary>
        /// to Sort Contact
        /// </summary>
        /// <returns>Sorted list of contacts or null if empty</returns>
        public List<ContactInfo> SortContact()
        {
            if (_repo.Empty())
            {
                return null;
            }

            return _repo.SortContact();
        }
    }
}