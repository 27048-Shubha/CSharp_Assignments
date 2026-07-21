namespace ContactManager.Services
{
    using System.Collections.Generic;
    using ContactManager.Models;
    using ContactManager.Persistance;

    /// <summary>
    /// Handles all I/P Validations.
    /// </summary>
    internal class ContactService
    {
        private ContactRepository repo = new ContactRepository();

        /// <summary>
        /// to Add new contact to the list.
        /// </summary>
        /// <param name="contact">Contact information to add.</param>
        /// <returns>Status of the operation.</returns>
        public int AddContact(Contact contact)
        {
            if (CheckDuplicates(contact))
            {
                return -1;
            }
            else if (!ContactManager.Helpers.ContactValidator.ValidatePhone(contact.Phone ?? string.Empty))
            {
                return -2;
            }

            repo.AddContact(contact);
            return 1;
        }

        /// <summary>
        /// to Get all contact information.
        /// </summary>
        /// <returns>List of all contacts or null if empty.</returns>
        public List<Contact> GetAllContactInfo()
        {
            if (repo.Empty())
            {
                return null;
            }
            else
            {
                return repo.ViewContact();
            }
        }

        /// <summary>
        /// to Search for a contact by name.
        /// </summary>
        /// <param name="phone">Phone number of the contact to search for.</param>
        /// <returns>Status of the operation.</returns>
        public int DeleteContact(string phone)
        {
            Contact contact = repo.ExistPhone(phone);
            if (contact != null)
            {
                repo.DeleteContact(contact);
                return 1;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// to Edit contact information.
        /// </summary>
        /// <param name="name">Name of the contact to edit.</param>
        /// <param name="editChoice">Choice of attribute to edit.</param>
        /// <param name="newValue">New value for the attribute.</param>
        /// <returns>Status of the operation.</returns>
        public int EditContact(string name, int editChoice, string newValue)
        {
            Contact contact = repo.SearchContact(name);
            if (contact == null)
            {
                return -1;
            }

            switch (editChoice)
            {
                case 1:
                    repo.EditName(contact, newValue);
                    break;

                case 2:
                    repo.EditPhone(contact, newValue);
                    break;

                case 3:
                    repo.EditEmail(contact, newValue);
                    break;

                case 4:
                    repo.EditNotes(contact, newValue);
                    break;

                default:
                    return -2;
            }

            return 1;
        }

        /// <summary>
        /// to Search for a Contact.
        /// </summary>
        /// <param name="name">Name of the contact to search for.</param>
        /// <returns>ContactInfo object if found, otherwise null.</returns>
        public Contact SearchContact(string name)
        {
            if (repo.Exist(name))
            {
                return repo.SearchContact(name);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// to check for existance of new contact number to avoid duplication.
        /// </summary>
        /// <param name="contact"> New Object. </param>
        /// <returns> true if new attribute else False. </returns>
        public bool CheckDuplicates(Contact contact)
        {
            return repo.ExistPhone(contact.Phone) != null;
        }

        /// <summary>
        /// To check whether contactList is empty or not.
        /// </summary>
        /// <param name="contactList"> Entire List of contacts in contactList. </param>
        /// <returns>True if empty else False.</returns>
        public bool IsEmpty(List<Contact> contactList)
        {
            return contactList.Count == 0;
        }

        /// <summary>
        /// to Sort Contact.
        /// </summary>
        /// <returns>Sorted list of contacts or null if empty.</returns>
        public List<Contact> SortContact()
        {
            if (repo.Empty())
            {
                return null;
            }

            return repo.SortContact();
        }
    }
}