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
            if(contactList.Count == 0)
            {
                Console.WriteLine("No Contacts to display\n");
            }
            else
            {
                foreach(var contact in contactList)
                {
                    Console.WriteLine($"NAME: {contact.Name}\nPHONE NUMBER: {contact.Phone}\nEMAIL: {contact.Email}\nNOTES: {contact.Notes}\n\n");
                }
            }
        }
        /// <summary>
        /// to Add new contact into contactList
        /// </summary>
        public static void AddContact()
        {
            Console.WriteLine("ENTER NAME: ");
            string name = Console.ReadLine();

            Console.WriteLine("ENTER PHONE NUMBER: ");
            string phone = Console.ReadLine();

            Console.WriteLine("ENTER EMAIL ADDRESS: ");
            string email = Console.ReadLine();

            Console.WriteLine("ENTER NOTES: ");
            string notes = Console.ReadLine();

            //I/P Validations
            ContactInfo contact = new ContactInfo(name, phone, email, notes);
            if (ValidateContact.CheckDuplicates(contact, contactList) &&  Helpers.ValidatePhone(phone))
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
                Console.WriteLine("ENTER NAME: ");
                string searchPh = Console.ReadLine();

                int searchIndex = ValidateContact.FindIndex(searchPh, contactList);


                if (searchIndex != -1)
                {
                    Console.WriteLine("Enter 1 to edit Name\n2 to edit Phone\n3 to edit Email\n4 to edit Notes\n");
                    int editCh = int.Parse(Console.ReadLine());


                    switch (editCh)
                    {
                        case 1:
                            Console.WriteLine("Enter new Name:");
                            contactList[searchIndex].Name = Console.ReadLine();
                            break;

                        case 2:
                            Console.WriteLine("Enter new Phone:");
                            contactList[searchIndex].Phone = Console.ReadLine();
                            break;

                        case 3:
                            Console.WriteLine("Enter new Email:");
                            contactList[searchIndex].Email = Console.ReadLine();
                            break;

                        case 4:
                            Console.WriteLine("Enter new Note:");
                            contactList[searchIndex].Notes = Console.ReadLine();
                            break;

                        default:
                            Console.WriteLine("Kinly Enter only from 1 to 4\n");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("PHONE NUMBER Doesn't Exist");
                }
            }
        }

        /// <summary>
        /// to Delete existing Contact
        /// </summary>
        public static void DeleteContact()
        {
            Console.WriteLine("Enter Phone Number to be deleted: ");
            string deletePh = Console.ReadLine();
            foreach(var contact in contactList)
            {
                if(contact.Phone == deletePh)
                {
                    contactList.Remove(contact);
                    return;
                }
            }
            Console.WriteLine("Phone Number doesn't exist");
        }
        
        /// <summary>
        /// to Search Contacts from Contact List
        /// </summary>
        public static void SearchContact()
        {
            Console.WriteLine("Enter Name to search");
            string searchName = Console.ReadLine();
            foreach (var contact in contactList)
            {
                if (contact.Name == searchName)
                {
                    contactList.Remove(contact);
                    return;
                }
            }
            Console.WriteLine("Searched Contact doesn't exist");
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
