//Program.cs
//using ContactManager.Helpers;
using ContactManager;
using ContactManager.Models;
using ContactManager.Persistance;
using ContactManager.Services;
using System.Collections.Generic;

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
                ch = console.GetChoice();

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
                        if (addStatus == -1)
                        {
                            console.DisplayDuplicateMessage();
                        }
                        else if (addStatus == -2)
                        {
                            console.DisplayInvalidPhoneMessage();
                        }
                        else
                        {
                            console.DisplaySuccess();
                        }
                        break;

                    case 2: // EDIT
                        name = console.GetName();
                        int editChoice = console.DisplayEditMenu();
                        string newValue = "";
                        switch (editChoice)
                        {
                            case 1:
                                newValue = console.GetName();
                                break;
                            case 2:
                                newValue = console.GetPhone();
                                break;
                            case 3:
                                newValue = console.GetEmail();
                                break;
                            case 4:
                                newValue = console.GetNotes();
                                break;
                            default:
                                console.DisplayDefaultMessage();
                                break;
                        }

                        int editStatus = handler.EditContact(name, editChoice, newValue);
                        if (editStatus == -1)
                        {
                            console.DisplayNotFoundMessage();
                        }
                        else if (editStatus == -2)
                        {
                            console.DisplayInvalidInputMessage();
                        }
                        else
                        {
                            console.DisplaySuccess();
                        }
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
                        ContactInfo foundContact = handler.SearchContact(name);
                        if (foundContact != null)
                        {
                            console.DisplayContact(foundContact);
                        }
                        else
                        {
                            console.DisplayNotFoundMessage();
                        }
                        break;

                    case 5:
                        List<ContactInfo> contacts = handler.SortContact();

                        if (contacts == null)
                        {
                            console.DisplayEmptyListMessage();
                        }
                        else
                        {
                            console.DisplayContactList(contacts);
                        }

                        break;

                    default:
                        console.DisplayDefaultMessage();
                        break;
                }
            }
            while (ch != 6);
        }
    }
}
