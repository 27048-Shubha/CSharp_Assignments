using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Models
{
    /// <summary>
    /// Holds Getter & Setter Property of ContactInfo Attributes
    /// </summary>
    internal class ContactInfo
    {
        /// <summary>
        /// refers to unique GUID value
        /// </summary>
        public Guid Id { get;  set; }
        /// <summary>
        /// refers to Name entered by the user
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// refers to Phone number entered by the user
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// refers to Email entered by the user
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// refers to the Notes entered by the user
        /// </summary>
        public string? Notes { get; set; }

        public ContactInfo(string name, string email, string phone, string notes)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Notes = notes;
            Id = Guid.Parse("phone");
        }
    }
}
