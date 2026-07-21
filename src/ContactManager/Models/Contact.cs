namespace ContactManager.Models
{
    using System;

    /// <summary>
    /// Holds Getter & Setter Property of ContactInfo Attributes.
    /// </summary>
    internal class Contact
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="name">Name of the Contact.</param>
        /// <param name="phone">Phone number of the Contact.</param>
        /// <param name="email">Email ID of the Contact.</param>
        /// <param name="notes">Notes of the Contact.</param>
        public Contact(string name, string phone, string email = "No mail found", string notes = "No notes found")
        {
            Id = Guid.NewGuid();

            Name = name;
            Phone = phone;
            Email = email;
            Notes = notes;
        }

        /// <summary>
        /// Gets or Sets GUID.
        /// </summary>
        /// <value>Unique ID given to Contact.</value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or Sets Name.
        /// </summary>
        /// <value>The name of the Contact.</value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or Sets Phone Number.
        /// </summary>
        /// <value>The Phone Number of the Contact.</value>
        public string? Phone { get; set; }

        /// <summary>
        /// Gets or Sets Email.
        /// </summary>
        /// <value>The Email ID of the Contact.</value>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or Sets Notes.
        /// </summary>
        /// <value>The Notes for the Contact.</value>
        public string? Notes { get; set; }
    }
}