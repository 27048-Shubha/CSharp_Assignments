namespace ContactManager.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using ContactManager.Models;

    /// <summary>
    /// Contains abstract methods for implementation of list.
    /// </summary>
    internal interface IContactRepository
    {
        /// <summary>
        /// To add contact to the list.
        /// </summary>
        /// <param name="contact"> The contact to add.</param>
        public void Add(Contact contact);

        /// <summary>
        /// to View all this.contacts in the list.
        /// </summary>
        /// <returns> List of all this.contacts.</returns>
        public IReadOnlyList<Contact> GetAll();

        /// <summary>
        /// to Delete a Contact from the List.
        /// </summary>
        /// <param name="contact"> Object that holds Contact Details.</param>
        public void Delete(Contact contact);

        /// <summary>
        /// to Search for a Contact.
        /// </summary>
        /// <param name="name"> Name of the Contact to be searched.</param>
        /// <returns> ContactInfo object if found, otherwise null.</returns>
        public Contact? Get(string name);

        /// <summary>
        /// to Sort Contact.
        /// </summary>
        /// <returns> Sorted List of ContactInfo objects.</returns>
        public List<Contact> GetAllSortedByName();

        /// <summary>
        /// to Search for a Contact.
        /// </summary>
        /// <param name="name"> Name of the Contact to be searched.</param>
        /// <returns> ContactInfo object if found, otherwise null.</returns>
        public List<Contact> FetchByNameContaining(string name);

        /// <summary>
        /// to Check if a Contact exists.
        /// </summary>
        /// <param name="name"> Name of the Contact to be checked.</param>
        /// <returns> True if found, otherwise false.</returns>
        public bool ExistsByName(string name);

        /// <summary>
        /// to Check if a Phone number exists.
        /// </summary>
        /// <param name="phone"> Phone number to be checked.</param>
        /// <returns> ContactInfo object if found, otherwise null.</returns>
        public Contact? GetByPhoneNumber(string phone);

        /// <summary>
        /// to Check if the Contact List is empty.
        /// </summary>
        /// <returns> True if empty, otherwise false.</returns>
        public bool Empty();
    }
}