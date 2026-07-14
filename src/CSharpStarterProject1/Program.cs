using System;

namespace Assignments
{
    /// <summary>
    /// Contact Manager Console Application
    /// </summary>
    internal class Program
    {
        private static List<List<string>> contacts = new List<List<string>>();

        /// <summary>
        /// Returns index of str1 stored inside contacts
        /// </summary>
        /// <param name="str1">String whose index to be found</param>
        /// <param name="atr_type">Type - Name, Phone, Email, Notes</param>
        /// <returns>index of str1 in contacts</returns>
        public static int SearchIndex(string str1, int atr_type)
        {
            int index = 0;
            foreach (var contact in contacts)
            {
                if (str1 == contact[atr_type])
                {
                    return index;
                } 
                index++;
            }
            return -1;
        }

        /// <summary>
        /// Returns index of str1 stored inside contacts
        /// </summary>
        /// <param name="str1">String whose index to be found</param>
        /// <param name="atr_type">Type - Name, Phone, Email, Notes</param>
        public static void DeleteBy(string str1, int atr_type)
        {
            Console.WriteLine("Enter Phone Number to be deleted: ");
            string delete_ph = Console.ReadLine();
            int delete_index = SearchIndex(delete_ph, 1);
            
            if (delete_index != -1)
            {
                contacts.RemoveAt(delete_index);
            }
            else
            {
                Console.WriteLine("Phone Number doesn't exist");
            }
        }

        /// <summary>
        /// Checks whether the list of contacts is empty
        /// </summary>
        /// <returns>True if contact is empty, else False</returns>
        public static bool IsEmpty()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No Contacts Added Yet!");
            }
            return contacts.Count == 0;
        }

        /// <summary>
        /// To view sorted list 
        /// </summary>
        /// <param name="sortType">Sort by Name/Phone/Email</param>
        public static void ViewSorted(int sortType)
        {
            contacts.Sort((a, b) => a[sortType].CompareTo(b[sortType]));
            Console.WriteLine("NAME - PHONE NUMBER - EMAIL - NOTES");

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact[0]} - {contact[1]} - {contact[2]} - {contact[3]}");
            }
        }

        /// <summary>
        /// Execution of this program begins here
        /// </summary>
        /// <param name="args"> Command Line Arguments </param>
        public static void Main(string[] args)
        {
            int ch;
            do
            {
                Console.WriteLine("Welcome to the Contact Manager! \nENTER 0 to VIEW ALL CONTACT, \n1 TO ADD NEW CONTACT, \n2 TO EDIT EXSISTING CONTACT, \n3 TO DELETE ANY CONTACT, \n4 TO SEARCH ANY CONTACT, \n5 TO VIEW SORTED LIST\n6 TO EXIT\n");
                ch = int.Parse(Console.ReadLine());

                string name;
                string phone;
                string email;
                string notes;

                switch (ch)
                {
                    case 0: // VIEW
                        Console.WriteLine("LIST OF ALL CONTACTS:");
                        if (!IsEmpty())
                        {
                            for (int i = 0; i < contacts.Count; i++)
                            {
                                Console.WriteLine($"NAME: {contacts[i][0]}\nPHONE NUMBER: {contacts[i][1]}\nEMAIL: {contacts[i][2]}\nNOTES: {contacts[i][3]}\n\n");
                            }
                        }
                        break;

                    case 1: // ADD
                        Console.WriteLine("ENTER NAME: ");
                        name = Console.ReadLine();

                        Console.WriteLine("ENTER PHONE NUMBER: ");
                        phone = Console.ReadLine();

                        Console.WriteLine("ENTER EMAIL ADDRESS: ");
                        email = Console.ReadLine();

                        Console.WriteLine("ENTER NOTES: ");
                        notes = Console.ReadLine();

                        contacts.Add(new List<string>() { name, phone, email, notes });

                        break;

                    case 2: // EDIT
                        if (!IsEmpty())
                        {
                            Console.WriteLine("ENTER NAME: ");
                            string search_ph = Console.ReadLine();
                            int count = 0;
                            int search_index = SearchIndex(search_ph, 1);

                            if (search_index != -1)
                            {
                                Console.WriteLine("Enter 1 to edit Name\n2 to edit Phone\n3 to edit Email\n4 to edit Notes\n");
                                int edit_ch = int.Parse(Console.ReadLine());

                                switch (edit_ch)
                                {
                                    case 1:
                                        Console.WriteLine("Enter new Name:");
                                        contacts[search_index][0] = Console.ReadLine();
                                        break;

                                    case 2:
                                        Console.WriteLine("Enter new Phone:");
                                        contacts[search_index][1] = Console.ReadLine();
                                        break;

                                    case 3:
                                        Console.WriteLine("Enter new Email:");
                                        contacts[search_index][2] = Console.ReadLine();
                                        break;

                                    case 4:
                                        Console.WriteLine("Enter new Note:");
                                        contacts[search_index][3] = Console.ReadLine();
                                        break;

                                    default:
                                        Console.WriteLine("Kinly Enter only from 1 to 4\n");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("PHONE NUMBER Doesn't Exist");
                            }
                        }
                        break;

                    case 3: // DELETE
                        if (!IsEmpty())
                        {
                            Console.WriteLine("Enter Phone Number to be deleted: ");
                            string delete_ph = Console.ReadLine();
                            int delete_index = SearchIndex(delete_ph, 1);

                            if (delete_index != -1)
                            {
                                contacts.RemoveAt(delete_index);
                            }
                            else
                            {
                                Console.WriteLine("Phone Number doesn't exist");
                            }
                        }
                        break;

                    case 4: // SEARCH
                        if (!IsEmpty())
                        {
                            Console.WriteLine("Enter Name to search");
                            string search_name = Console.ReadLine();
                            int search_index = SearchIndex(search_name, 0);

                            if (search_index != -1)
                            {
                                Console.WriteLine($"Name: {contacts[search_index][0]}\nPhone: {contacts[search_index][1]}\nEmail: {contacts[search_index][2]}\nNotes: {contacts[search_index][3]}");
                            }
                            else
                            {
                                Console.WriteLine("Name Not Found");
                            }
                        }

                        break;

                    case 5: //SORT
                        if (!IsEmpty())
                        {
                            Console.WriteLine("Enter 1 to sort by Name\n2 to sort by Phone\n3 to sort by Email\n4 to sort by Notes\n");
                            string sortType = Console.ReadLine();

                            if (int.TryParse(sortType, out int type))
                            {
                                ViewSorted(type);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input for sort type\n");
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Enter only from 0 to 4\n");
                        break;
                }
            }
            while (ch != 6);
        }    
    }
}