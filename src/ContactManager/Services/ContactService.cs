namespace ContactManager.Services
{
    using System.Collections.Generic;
    using ContactManager.Models;
    using ContactManager.Persistance;
    using ContactManager.Validations;

    /// <summary>
    /// Handles all I/P Validations.
    /// </summary>
    internal class ContactService
    {
        private readonly ContactRepository _repo;
        private readonly ContactValidator _validate;

        public ContactService(ContactRepository repo, ContactValidator validate) {
            _repo = repo;
            _validate = validate;
        }

        /// <summary>
        /// to Add new contact to the list.
        /// </summary>
        /// <param name="contact">Contact information to add.</param>
        /// <returns>Status of the operation.</returns>
        public int AddContact(Contact contact)
        {
            if (this.CheckDuplicates(contact))
            {
                return -1;
            }
            else if (ContactValidator.IsEmpty(contact.Name))
            {
                return -2;
            }
            else if (!ContactValidator.ValidatePhone(contact.PhoneNumber))
            {
                return -3;
            }
            else if (ContactValidator.IsEmpty(contact.Email))
            {
                if (ContactValidator.ValidateEmail(contact.Email))
                {
                    return -4;
                }
            }

            this._repo.Add(contact);
            return 1;
        }

        /// <summary>
        /// to Get all contact information.
        /// </summary>
        /// <returns>List of all contacts or null if empty.</returns>
        public List<Contact> GetAllContactInfo()
        {
            return this._repo.View();
        }

        /// <summary>
        /// to Search for a contact by name.
        /// </summary>
        /// <param name="phone">Phone number of the contact to search for.</param>
        /// <returns>Status of the operation.</returns>
        public int DeleteContact(string phone)
        {
            Contact contact = this._repo.GetByPhoneNumber(phone);
            if (contact != null)
            {
                this._repo.Delete(contact);
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
        public int EditContact(string name, string editChoice, string newValue)
        {
            Contact? contact = this._repo.Get(name);
            if (contact == null)
            {
                return -1;
            }

            switch (editChoice)
            {
                case "1":
                    this._repo.EditName(contact, newValue);
                    break;

                case "2":
                    this._repo.EditPhone(contact, newValue);
                    break;

                case "3":
                    this._repo.EditEmail(contact, newValue);
                    break;

                case "4":
                    this._repo.EditNotes(contact, newValue);
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
        public List<Contact>? SearchContact(string name)
        {
            if (this._repo.ExistsByName(name))
            {
                return this._repo.FetchByNameContaining(name);
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
            return this._repo.GetByPhoneNumber(contact.PhoneNumber) != null;
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
        public List<Contact>? SortContact()
        {
            if (this._repo.Empty())
            {
                return null;
            }

            return this._repo.GetAllSortedByName();
        }
    }
}