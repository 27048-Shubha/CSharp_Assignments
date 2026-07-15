// Persistance/Repository.cs
using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using ContactManager.Services;

namespace ContactManager.Persistance
{
    /// <summary>
    /// Holds Original List & related CRUD Operations
    /// </summary>
    internal class Repository
    {
        static private List<ContactInfo> contactList = new List<ContactInfo>();

        /// <summary>
        /// to View List of all contacts
        /// </summary>
        public static void ViewContact()
        {
            if (contactList.Count == 0)
            {
                DisplayEmptyListMessage();
            }
            else
            {
                foreach (var contact in contactList)
                {
                    DisplayContactList(contact);
                }
            }
        }

        /// <summary>
        /// to Add new contact into contactList
        /// </summary>
        public static void AddContact()
        {

            //I/P Validations
            ContactInfo contact = new ContactInfo(getName(), getPhone(), getEmail(), getNotes());
            if (ValidateContact.CheckDuplicates(contact, contactList) && Helpers.ValidatePhone(phone))
            {
                contactList.Add(contact);
            }
        }

        /// <summary>
        /// to Edit existing Contact
        /// </summary>
        public static void EditContact()
        {
            // GUID Based Implementation
            if (!ValidateContact.IsEmpty(contactList))
            {
                string searchPh = getName();

                int searchIndex = ValidateContact.FindIndex(searchPh, contactList);

                if (searchIndex != -1)
                {
                    DisplayEditMenu();
                    int editCh = int.Parse(ConsoleManager.ReadLine());

                    switch (editCh)
                    {
                        case 1:
                            contactList[searchIndex].Name = getName();
                            break;

                        case 2:
                            contactList[searchIndex].Phone = getPhone();
                            break;

                        case 3:
                            contactList[searchIndex].Email = getEmail();
                            break;

                        case 4:
                            contactList[searchIndex].Notes = getNotes();
                            break;

                        default:
                            DisplayDefaultMessage();
                            break;
                    }
                }
                else
                {
                    DisplayNotFoundMessage();
                }
            }
        }

        /// <summary>
        /// to Delete existing Contact
        /// </summary>
        public static void DeleteContact()
        {
            string deletePh = getPhone();
            foreach (var contact in contactList)
            {
                if (contact.Phone == deletePh)
                {
                    contactList.Remove(contact);
                    return;
                }
            }
            DisplayNotFoundMessage();
        }

        /// <summary>
        /// to Search Contacts from Contact List
        /// </summary>
        public static void SearchContact()
        {
            string searchName = getName();
            foreach (var contact in contactList)
            {
                if (contact.Name == searchName)
                {
                    contactList.Remove(contact);
                    return;
                }
            }
            DisplayNotFoundMessage();
        }

        /// <summary>
        /// to Sort Contact 
        /// </summary>
        public static void SortContact()
        {
            //Sort Contact Feature
            if (!ValidateContact.IsEmpty(contactList))
            {
                ValidateContact.ViewSorted(contactList);
            }
        }
    }
}
