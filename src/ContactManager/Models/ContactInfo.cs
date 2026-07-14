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
        public Guid Id { get;  set; }
        public string? Name { get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }
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
