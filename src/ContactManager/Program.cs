//Program.cs
//using ContactManager.Helpers;
using ContactManager;
using ContactManager.Models;
using ContactManager.Persistance;
using ContactManager.Services;

namespace Assignments
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method where execution begins
        /// </summary>
        /// <param name="args">CommandLine Args</param>
        public static void Main(string[] args)
        {
            ConsoleManager console = new ConsoleManager();
            ContactHandler handler = new ContactHandler();
            int ch;
            do
            {
                console.DisplayMenu();
                ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 0: // VIEW
                        List<ContactInfo> contact = handler.GetAllContactInfo();
                        if (contact != null)
                        {
                            console.DisplayContactList(contact);
                        }
                        else
                        {
                            console.DisplayEmptyListMessage();
                        }
                        break;

                    case 1: // ADD
                        string name = console.GetName();
                        string phone = console.GetPhone();
                        string email = console.GetEmail();
                        string notes = console.GetNotes();
                        ContactInfo newContact = new ContactInfo(name, phone, email, notes);
                        int addStatus = handler.AddContact(newContact);
                        if(addStatus == -1)
                        {
                            console.DisplayDuplicateMessage();
                        }
                        else if(addStatus == -2)
                        {
                            console.DisplayInvalidPhoneMessage();
                        }
                        else
                        {
                            console.DisplaySuccess();
                        }
                        break;

                    case 2: // EDIT
                        Repository.EditContact();
                        break;

                    case 3: // DELETE
                        phone = console.GetPhone();
                        int deleteStatus = handler.DeleteContact(phone);
                        if (deleteStatus == -1)
                        {
                            console.DisplayNotFoundMessage();
                        }
                        else
                        {
                            console.DisplaySuccess();
                        }
                        break;

                    case 4: // SEARCH
                        name = console.GetName();
                        contact = handler.SearchContact(name);
                        if(contact == null)
                        {
                            console.DisplayNotFoundMessage();
                        }
                        else
                        {
                            console.DisplayContact(contact);
                        }
                        break;

                    case 5: //SORT
                        Repository.SortContact();
                        break;

                    default:
                        ConsoleManager.DisplayDefaultMessage();
                        break;
                }
            } 
            while (ch != 6);
        }
    }
}