using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Services
{
    /// <summary>
    /// Handles all I/P Validations
    /// </summary>
    internal class ValidateContact
    {
        /// <summary>
        /// to check for existance of new contact number to avoid duplication
        /// </summary>
        /// <param name="contact"> New Object </param>
        /// <param name="contactList"> List of all existing contacts </param>
        /// <returns> true if new attribute else False </returns>
        public static bool CheckDuplicates( ContactInfo contact, List<ContactInfo> contactList )
        {
            foreach(var attribute in contactList)
            {
                if(attribute.Phone == contact.Phone)
                {
                    Console.WriteLine("Phone Number Already Exists!");
                    return false;
                }
            }
            return true;
        }
        {
            //new ContactInfo(name);
        }
    }
}
