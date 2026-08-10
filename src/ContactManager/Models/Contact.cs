namespace ContactManager.Models
{
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
        /// <param name="email">Optional Email ID of the Contact.</param>
        /// <param name="notes">Optional Notes of the Contact.</param>
        internal Contact(string name, string phone, string? email = null, string? notes = null)
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.PhoneNumber = phone;
            this.Email = email;
            this.Notes = notes;
        }

        /// <summary>
        /// Gets the unique ID assigned to the contact at creation time.
        /// </summary>
        /// <value>Unique Guid of the contact. </value>
        public Guid Id { get; }

        /// <summary>
        /// Gets or sets the name of the contact.
        /// </summary>
        /// <value>Name of the contact.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets phone number of the contact.
        /// </summary>
        /// <value>Phone number of the contact.</value>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or Sets email id of the contact.
        /// </summary>
        /// <value>Optional email id of the contact.</value>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or Sets notes of the contact.
        /// </summary>
        /// <value>Optional notes for the contact.</value>
        public string? Notes { get; set; }
    }
}