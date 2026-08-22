namespace ContactManager.Services
{
    using System.Collections.Generic;
    using ContactManager.Models;
    using ContactManager.Persistance;
    using ContactManager.Validations;

    /// <summary>
    /// Handles business validations of the contact manager.
    /// </summary>
    internal class ContactService
    {
        private readonly ContactRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactService"/> class.
        /// </summary>
        /// <param name="repo">Handles operations of Repository.</param>
        internal ContactService(ContactRepository repo)
        {
            this.repository = repo;
        }

        /// <summary>
        /// Adds new contact to the list.
        /// </summary>
        /// <param name="contact">Contact information to add.</param>
        /// <returns>Status of the operation.</returns>
        public int Add(Contact contact)
        {
            if (this.CheckDuplicates(contact))
            {
                return -1;
            }
            else if (ContactValidator.IsEmpty(contact.Name))
            {
                return -2;
            }
            else if (!ContactValidator.IsValidPhoneNumber(contact.PhoneNumber))
            {
                return -3;
            }
            else if (ContactValidator.IsEmpty(contact.Email))
            {
                if (ContactValidator.IsValidEmail(contact.Email))
                {
                    return -4;
                }
            }

            this.repository.Add(contact);
            return 1;
        }

        /// <summary>
        /// Gets all contact information.
        /// </summary>
        /// <returns>List of all contacts or null if empty.</returns>
        public IReadOnlyList<Contact> GetAll()
        {
            return this.repository.GetAll();
        }

        /// <summary>
        /// Deletes contact from the contact list.
        /// </summary>
        /// <param name="phone">Phone number of the contact to search for.</param>
        /// <returns>Status of the operation.</returns>
        public Enums.Status Delete(string phone)
        {
            Contact? contact = this.repository.GetByPhoneNumber(phone);
            if (contact != null)
            {
                this.repository.Delete(contact);
                return Enums.Status.Success;
            }
            else
            {
                return Enums.Status.NotFound;
            }
        }

        /// <summary>
        /// Edits contact information.
        /// </summary>
        /// <param name="name">Name of the contact to edit.</param>
        /// <param name="editChoice">Choice of attribute to edit.</param>
        /// <param name="newValue">New value for the attribute.</param>
        /// <returns>Status of the operation.</returns>
        public Enums.Status Edit(string name, string editChoice, string newValue)
        {
            Contact? contact = this.repository.Get(name);
            if (contact == null)
            {
                return Enums.Status.NotFound;
            }

            switch (editChoice)
            {
                case "1":
                    contact.Name = newValue;
                    break;

                case "2":
                    contact.PhoneNumber = newValue;
                    break;

                case "3":
                    contact.Email = newValue;
                    break;

                case "4":
                    contact.Notes = newValue;
                    break;

                default:
                    return Enums.Status.InvalidInput;
            }

            return Enums.Status.Success;
        }

        /// <summary>
        /// Searches for a Contact.
        /// </summary>
        /// <param name="name">Name of the contact to search for.</param>
        /// <returns>ContactInfo object if found, otherwise null.</returns>
        public List<Contact>? Search(string name)
        {
            if (this.repository.IsExistsByName(name))
            {
                return this.repository.FetchByNameContaining(name);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Checks for existance of new contact number to avoid duplication.
        /// </summary>
        /// <param name="contact"> New Object. </param>
        /// <returns> true if new attribute else False. </returns>
        public bool CheckDuplicates(Contact contact)
        {
            return this.repository.GetByPhoneNumber(contact.PhoneNumber) != null;
        }

        /// <summary>
        /// Checks whether passed contactList is empty or not.
        /// </summary>
        /// <param name="contactList"> Entire List of contacts in contactList. </param>
        /// <returns>True if empty else False.</returns>
        public bool IsEmpty(IReadOnlyList<Contact> contactList)
        {
            return contactList.Count == 0;
        }

        /// <summary>
        /// Checks whether contact list is empty or not.
        /// </summary>
        /// <returns>True if contact exists, else false.</returns>
        public bool HasContacts()
        {
            IReadOnlyList<Contact> contacts = this.GetAll();
            return contacts.Count != 0;
        }

        /// <summary>
        /// Sorts contact list.
        /// </summary>
        /// <returns>Sorted list of contacts or null if empty.</returns>
        public List<Contact>? Sort()
        {
            if (this.repository.IsEmpty())
            {
                return null;
            }

            return this.repository.GetAllSortedByName();
        }
    }
}