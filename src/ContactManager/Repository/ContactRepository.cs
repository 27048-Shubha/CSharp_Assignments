namespace ContactManager.Persistance
{
    using System.Collections.Generic;
    using System.Linq;
    using ContactManager.Models;

    /// <summary>
    /// Holds Original List & related CRUD Operations.
    /// </summary>
    internal class ContactRepository
    {
        private readonly List<Contact> _contacts = new List<Contact>();

        /// <summary>
        /// To add contact to the list.
        /// </summary>
        /// <param name="contact"> The contact to add.</param>
        public void Add(Contact contact)
        {
            this._contacts.Add(contact);
        }

        /// <summary>
        /// to View all this.contacts in the list.
        /// </summary>
        /// <returns> List of all this.contacts.</returns>
        public IReadOnlyList<Contact> GetAll()
        {
            return this._contacts.ToList();
        }

        /// <summary>
        /// to Delete a Contact from the List.
        /// </summary>
        /// <param name="contact"> Object that holds Contact Details.</param>
        public void Delete(Contact contact)
        {
            this._contacts.Remove(contact);
        }

        /// <summary>
        /// to Search for a Contact.
        /// </summary>
        /// <param name="name"> Name of the Contact to be searched.</param>
        /// <returns> ContactInfo object if found, otherwise null.</returns>
        public Contact? Get(string name)
        {
            return this._contacts.FirstOrDefault(c => c.Name == name);
        }

        /// <summary>
        /// to Search for a Contact.
        /// </summary>
        /// <param name="name"> Name of the Contact to be searched.</param>
        /// <returns> ContactInfo object if found, otherwise null.</returns>
        public List<Contact> FetchByNameContaining(string name)
        {
            List<Contact> contacts = new List<Contact>();
            foreach (var contact in this._contacts)
            {
                if (contact.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    contacts.Add(contact);
                }
            }

            return contacts;
        }

        /// <summary>
        /// to Sort Contact.
        /// </summary>
        /// <returns> Sorted List of ContactInfo objects.</returns>
        public List<Contact> GetAllSortedByName()
        {
            return this._contacts.OrderBy(c => c.Name).ToList();
        }

        /// <summary>
        /// to Check if a Contact exists.
        /// </summary>
        /// <param name="name"> Name of the Contact to be checked.</param>
        /// <returns> True if found, otherwise false.</returns>
        public bool IsExistsByName(string name)
        {
            List<Contact> contacts = new List<Contact>();
            foreach (var contact in this._contacts)
            {
                if (contact.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// to Check if a Phone number exists.
        /// </summary>
        /// <param name="phone"> Phone number to be checked.</param>
        /// <returns> ContactInfo object if found, otherwise null.</returns>
        public Contact? GetByPhoneNumber(string phone)
        {
            return this._contacts.FirstOrDefault(contact => contact.PhoneNumber == phone);
        }

        /// <summary>
        /// to Check if the Contact List is empty.
        /// </summary>
        /// <returns> True if empty, otherwise false.</returns>
        public bool IsEmpty()
        {
            return this._contacts.Count == 0;
        }
    }
}