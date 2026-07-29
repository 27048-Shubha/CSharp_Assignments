namespace ContactManager.Persistance
{
    using ContactManager.Models;

    /// <summary>
    /// Holds Original List & related CRUD Operations.
    /// </summary>
    internal class ContactRepository
    {
        private readonly List<Contact> contacts = new List<Contact>();

        /// <summary>
        /// To add contact to the list.
        /// </summary>
        /// <param name="contact"> The contact to add.</param>
        public void Add(Contact contact)
        {
            contacts.Add(contact);
        }

        /// <summary>
        /// to View all contacts in the list.
        /// </summary>
        /// <returns> List of all contacts.</returns>
        public List<Contact> View()
        {
            return new List<Contact>(contacts);
        }

        /// <summary>
        /// to Edit Name of a Contact.
        /// </summary>
        /// <param name="contact"> Object that holds Contact Details.</param>
        /// <param name="newName"> New Name to be updated.</param>
        public void EditName(Contact contact, string newName)
        {
            contact.Name = newName;
        }

        /// <summary>
        /// to Edit Phone number of a Contact.
        /// </summary>
        /// <param name="contact"> Object that holds Contact Details.</param>
        /// <param name="newPhoneNo"> New Phone number to be updated.</param>
        public void EditPhone(Contact contact, string newPhoneNo)
        {
            contact.PhoneNumber = newPhoneNo;
        }

        /// <summary>
        /// to Edit Email of a Contact.
        /// </summary>
        /// <param name="contact"> Object that holds Contact Details.</param>
        /// <param name="newEmail"> New Email to be updated.</param>
        public void EditEmail(Contact contact, string newEmail)
        {
            contact.Email = newEmail;
        }

        /// <summary>
        /// to Edit Notes of a Contact.
        /// </summary>
        /// <param name="contact"> Object that holds Contact Details.</param>
        /// <param name="newNotes"> New Notes to be updated.</param>
        public void EditNotes(Contact contact, string newNotes)
        {
            contact.Notes = newNotes;
        }

        /// <summary>
        /// to Delete a Contact from the List.
        /// </summary>
        /// <param name="contact"> Object that holds Contact Details.</param>
        public void Delete(Contact contact)
        {
            contacts.Remove(contact);
        }

        /// <summary>
        /// to Search for a Contact.
        /// </summary>
        /// <param name="name"> Name of the Contact to be searched.</param>
        /// <returns> ContactInfo object if found, otherwise null.</returns>
        public Contact? Get(string name)
        {
            foreach (var contact in contacts)
            {
                if (contact.Name == name)
                {
                    return contact;
                }
            }

            return null;
        }

        /// <summary>
        /// to Search for a Contact.
        /// </summary>
        /// <param name="name"> Name of the Contact to be searched.</param>
        /// <returns> ContactInfo object if found, otherwise null.</returns>
        public List<Contact> FetchByNameContaining(string name)
        {
            List<Contact> contacts = new List<Contact>();
            foreach (var contact in this.contacts)
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
            contacts.Sort((x, y) => x.Name.CompareTo(y.Name));
            return contacts;
        }

        /// <summary>
        /// to Check if a Contact exists.
        /// </summary>
        /// <param name="name"> Name of the Contact to be checked.</param>
        /// <returns> True if found, otherwise false.</returns>
        public bool ExistsByName(string name)
        {
            foreach (var contact in contacts)
            {
                if (contact.Name.Contains(name))
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
            foreach (var contact in contacts)
            {
                if (contact.PhoneNumber == phone)
                {
                    return contact;
                }
            }

            return null;
        }

        /// <summary>
        /// to Check if the Contact List is empty.
        /// </summary>
        /// <returns> True if empty, otherwise false.</returns>
        public bool Empty()
        {
            if (contacts.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}