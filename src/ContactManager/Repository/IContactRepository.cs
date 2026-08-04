namespace ContactManager.Persistance
{
    using System.Collections.Generic;
    using System.Linq;
    using ContactManager.Models;

    /// <summary>
    /// Holds Original List & related CRUD Operations.
    /// </summary>
    internal interface IContactRepository
    {
        private readonly List<Contact> contacts;

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
    }
}