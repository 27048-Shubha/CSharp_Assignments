using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ContactManager.Persistance
{
    /// <summary>
    /// Holds Original List & related CRUD Operations
    /// </summary>
    internal class Repository
    {
        static private List<ContactInfo> contactList = new List<ContactInfo>();
        
        static public void ViewContact()
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
        static public void AddContact()
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
            contactList.Add(contact);
        }

        static public void EditContact()
        {
            //GUID Based Implementation

        }
        static public void DeleteContact()
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
        
        static public void SearchContact()
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

        static public void SortContact()
        {
            //Sort Contact Feature
        }
    }
}
