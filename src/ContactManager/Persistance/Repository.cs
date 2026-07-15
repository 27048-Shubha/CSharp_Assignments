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
        /// 
        /// </summary>
        /// <param name="contact"></param>
        public void AddContact(ContactInfo contact)
        {
            contactList.Add(contact);
        }

        /// <summary>
        /// to View List of all contacts
        /// </summary>
        public List<ContactInfo> ViewContact()
        {
            return contactList;
        }
        
        /// <summary>
        /// to Edit existing Contact
        /// </summary>
        public static void EditContact()
        {
            // GUID Based Implementation
            if (!ContactHandler.IsEmpty(contactList))
            {
                string searchPh = ConsoleManager.GetName();

                int searchIndex = ContactHandler.FindIndex(searchPh, contactList);

                if (searchIndex != -1)
                {
                    int editCh = ConsoleManager.DisplayEditMenu(); 
                    
                    switch (editCh)
                    {
                        case 1:
                            contactList[searchIndex].Name = ConsoleManager.GetName();
                            break;

                        case 2:
                            contactList[searchIndex].Phone = ConsoleManager.GetPhone();
                            break;

                        case 3:
                            contactList[searchIndex].Email = ConsoleManager.GetEmail();
                            break;

                        case 4:
                            contactList[searchIndex].Notes = ConsoleManager.GetNotes();
                            break;

                        default:
                            ConsoleManager.DisplayDefaultMessage();
                            break;
                    }
                }
                else
                {
                    ConsoleManager.DisplayNotFoundMessage();
                }
            }
        }

        /// <summary>
        /// to Delete existing Contact
        /// </summary>
        public void DeleteContact(ContactInfo contact)
        {
            contactList.Remove(contact);
        }

        /// <summary>
        /// to Search Contacts from Contact List
        /// </summary>
        public static void SearchContact()
        {
            string searchName = ConsoleManager.GetName();
            foreach (var contact in contactList)
            {
                if (contact.Name == searchName)
                {
                    contactList.Remove(contact);
                    return;
                }
            }
            ConsoleManager.DisplayNotFoundMessage();
        }

        /// <summary>
        /// to Sort Contact 
        /// </summary>
        public static void SortContact()
        {
            //Sort Contact Feature
            if (!ContactHandler.IsEmpty(contactList))
            {
                ContactHandler.ViewSorted(contactList);
            }
        }

        public bool Exist(string contactName)
        {
            foreach(var contact in contactList)
            {
                if(contact.Name == contactName)
                {
                    return true;
                }
            }
        }

        public ContactInfo ExistPhone(string phone)
        {
            foreach (var contact in contactList)
            {
                if (contact.Phone == phone)
                {
                    return contact;
                }
            }
            return null;
        }

        public bool Empty()
        {
            if (contactList.Count == 0)
            {
                    return true;
            }
            return false;
    }
}
