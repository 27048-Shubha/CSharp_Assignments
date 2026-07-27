namespace ContactManager.Persistance
{
    using ContactManager.Models;

    /// <summary>
    /// Holds Original List & related CRUD Operations.
    /// </summary>
    internal class ContactRepository
    {
        private static List<Contact> contactList = new List<Contact>();

        /// <summary>
        /// To add contact to the list.
        /// </summary>
        /// <param name="contact"> Object that holds new Contact Details.</param>
        public void AddContact(Contact contact)
        {
            contactList.Add(contact);
        }

        /// <summary>
        /// to View all contacts in the list.
        /// </summary>
        /// <returns> List of all contacts.</returns>
        public List<Contact> ViewContact()
        {
            return new List<Contact>(contactList);
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
            contact.Phone = newPhoneNo;
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
        public void DeleteContact(Contact contact)
        {
            contactList.Remove(contact);
        }

        /// <summary>
        /// to Search for a Contact.
        /// </summary>
        /// <param name="name"> Name of the Contact to be searched.</param>
        /// <returns> ContactInfo object if found, otherwise null.</returns>
        public Contact? GetContact(string name)
        {
            foreach (var contact in contactList)
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
        public List<Contact> FetchContacts(string name)
        {
            List<Contact> contacts = new List<Contact>();
            foreach (var contact in contactList)
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
        public List<Contact> SortContact()
        {
            contactList.Sort((x, y) => x.Name.CompareTo(y.Name));
            return contactList;
        }

        /// <summary>
        /// to Check if a Contact exists.
        /// </summary>
        /// <param name="contactName"> Name of the Contact to be checked.</param>
        /// <returns> True if found, otherwise false.</returns>
        public bool Exist(string contactName)
        {
            foreach (var contact in contactList)
            {
                if (contact.Name.Contains(contactName))
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
        public Contact? ExistPhone(string phone)
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

        /// <summary>
        /// to Check if the Contact List is empty.
        /// </summary>
        /// <returns> True if empty, otherwise false.</returns>
        public bool Empty()
        {
            if (contactList.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}