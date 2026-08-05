namespace ContactManager.Repository
{
    using System;
    using System.IO.Enumeration;
    using ContactManager.Models;

    /// <summary>
    /// Handles CRUD Operations of Contact Manager using CSV.
    /// </summary>
    internal class CSVContactRepository : IContactRepository
    {
        /// <summary>
        /// Holds default file name on which operations to be performed.
        /// </summary>
        private readonly string filePath;
        private readonly List<string> headerList = new List<string>() { "Id,Name,PhoneNumber,Email,Notes" };
        private readonly string fileName = "contacts.csv";

        /// <summary>
        /// Initializes a new instance of the <see cref="CSVContactRepository"/> class.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public CSVContactRepository(string fileName)
        {
            this.filePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data", fileName);
        }

        /// <summary>
        /// To add contact to the list.
        /// </summary>
        /// <param name="contact"> The contact to add.</param>
        public void Add(Contact contact)
        {
            bool isExists = File.Exists(this.filePath);
            if (!isExists)
            {
                File.WriteAllLines(this.filePath, this.headerList);
            }

            List<string> contents = new List<string>() { { $"{contact.Id},{contact.Name},{contact.PhoneNumber},{contact.Email},{contact.Notes}" } };
            File.AppendAllLines(this.filePath, contents);
            Console.WriteLine("Added in file");
        }

        /// <summary>
        /// To view all contacts in the list.
        /// </summary>
        /// <returns> List of all contacts.</returns>
        public IReadOnlyList<Contact> GetAll()
        {
            List<Contact> contacts = new List<Contact>();
            string[] lines = File.ReadAllLines(this.filePath);
            Contact newContact;
            string[] words;
            for (int i = 1; i < lines.Length; i++)
            {
                words = lines[i].Split(',');
                newContact = new Contact(words[0], words[1], words[2], words[3], words[4]);
                contacts.Add(newContact);
            }

            return contacts.ToList();
        }

        /// <summary>
        /// to Delete a Contact from the List.
        /// </summary>
        /// <param name="contact"> Object that holds Contact Details.</param>
        public void Delete(Contact contact)
        {
            List<Contact> contacts = new List<Contact>();
            string[] lines = File.ReadAllLines(this.filePath);
            string[] words;
            foreach (string line in lines)
            {
                words = line.Split(',');
                if (words[1].Contains(contact.Name, StringComparison.OrdinalIgnoreCase))
                {
                    File.Delete(line);
                }
            }
        }

        /// <summary>
        /// to Search for a Contact.
        /// </summary>
        /// <param name="name"> Name of the Contact to be searched.</param>
        /// <returns> ContactInfo object if found, otherwise null.</returns>
        public Contact? Get(string name)
        {
            string[] lines = File.ReadAllLines(this.filePath);
            Contact? newContact = null;
            string[] words;
            foreach (string line in lines)
            {
                words = line.Split(',');
                if (words[1] == name)
                {
                    newContact = new Contact(words[0], words[1], words[2], words[3]);
                }
            }

            return newContact;
        }

        /// <summary>
        /// to Search for a Contact.
        /// </summary>
        /// <param name="name"> Name of the Contact to be searched.</param>
        /// <returns> ContactInfo object if found, otherwise null.</returns>
        public List<Contact> FetchByNameContaining(string name)
        {
            List<Contact> contacts = new List<Contact>();
            string[] lines = File.ReadAllLines(this.filePath);
            string[] words;
            foreach (string line in lines)
            {
                words = line.Split(',');
                if (words[1].Contains(name, StringComparison.OrdinalIgnoreCase))
                {
                    contacts.Add(new Contact(words[0], words[1], words[2], words[3]));
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
            List<Contact> contacts = new List<Contact>();
            string[] lines = File.ReadAllLines(this.filePath);
            string[] words;
            for (int i = 1; i < lines.Length; i++)
            {
                words = lines[i].Split(',');
                contacts.Add(new Contact(words[0], words[1], words[2], words[3], words[4]));
            }

            return contacts.OrderBy(c => c.Name).ToList();
        }

        /// <summary>
        /// to Check if a Contact exists.
        /// </summary>
        /// <param name="name"> Name of the Contact to be checked.</param>
        /// <returns> True if found, otherwise false.</returns>
        public bool ExistsByName(string name)
        {
            List<Contact> contacts = new List<Contact>();
            string[] lines = File.ReadAllLines(this.filePath);
            string[] words;
            foreach (string line in lines)
            {
                words = line.Split(',');
                if (words[1].Contains(name, StringComparison.OrdinalIgnoreCase))
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
            List<Contact> contacts = new List<Contact>();

            if (!File.Exists(this.filePath))
            {
                return null;
            }

            string[] lines = File.ReadAllLines(this.filePath);
            string[] words;
            foreach (string line in lines)
            {
                words = line.Split(',');
                if (words[2] == phone)
                {
                    return new Contact(words[0], words[1], words[2], words[3]);
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
            List<Contact> contacts = new List<Contact>();
            string[] lines = File.ReadAllLines(this.filePath);
            if (lines.Length <= 1)
            {
                return true;
            }

            return false;
        }
    }
}
