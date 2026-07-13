using System;

namespace Assignments
{
    /// <summary>
    /// Contact Manager 
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function holds menu to all features of the Contact Maneger Console Application
        /// </summary>
        /// <param name="args"> Console Argument </param>
        public static void Main(string[] args)
        {
            int ch;
            do
            {
                Console.WriteLine("Welcome to the Contact Manager! ENTER 0 to VIEW ALL CONTACT, \n1 TO ADD NEW CONTACT, \n2 TO EDIT EXSISTING CONTACT, \n3 TO DELETE ANY CONTACT, \n4 TO SEARCH ANY CONTACT, \n5 TO EXIT");
                ch = int.Parse(Console.ReadLine());
                List<String> name = new List<String>();
                List<String> phone = new List<String>();
                List<String> email = new List<String>();
                List<String> notes = new List<String>();
                int totalContacts = 0;

                switch (ch)
                {
                    case 0: // VIEW
                        Console.WriteLine("LIST OF ALL CONTACTS:");
                        for (int i = 0; i < totalContacts; i++)
                        {
                            Console.WriteLine($"NAME: {name[i]}\nPHONE NUMBER: {phone[i]}\nEMAIL: {email[i]}\nNOTES: {notes[i]}\n\n");
                        }
                        break;

                    case 1: // ADD
                        Console.WriteLine("ENTER NAME: ");
                        name.Add(Console.ReadLine());
                        Console.WriteLine("ENTER PHONE NUMBER: ");
                        phone.Add( Console.ReadLine() );
                        Console.WriteLine("ENTER EMAIL ADDRESS: ");
                        email.Add(Console.ReadLine());
                        Console.WriteLine("ENTER NOTES: ");
                        notes.Add(Console.ReadLine());
                        totalContacts = phone.Count;
                        break;

                    case 2: // EDIT
                        String search_ph = Console.ReadLine();
                        int index = phone.IndexOf(search_ph);
                        if (index != -1)
                        {
                            Console.WriteLine("Enter 1 to edit Name\n2 to edit Phone\n3 to edit Email\n4 to edit Notes\n");
                            int edit_ch = int.Parse(Console.ReadLine());
                            switch (edit_ch)
                            {
                                case 1:
                                    Console.WriteLine("Enter new Name:");
                                    name[index] = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.WriteLine("Enter new Phone:");
                                    phone[index] = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.WriteLine("Enter new Email:");
                                    email[index] = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.WriteLine("Enter new Note:");
                                    notes[index] = Console.ReadLine();
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
                        break;

                    case 3: // DELETE
                        Console.WriteLine("Enter Phone Number to be deleted: ");
                        String delete_ph = Console.ReadLine();
                        int delete_index = phone.IndexOf(delete_ph);
                        if (delete_index != -1)
                        {
                            name.RemoveAt(delete_index);
                            phone.RemoveAt(delete_index);
                            email.RemoveAt(delete_index);
                            notes.RemoveAt(delete_index);
                        }
                        break;

                    case 4: //SEARCH
                        Console.WriteLine("Enter Name to search");
                        String search_name = Console.ReadLine();
                        int search_index = name.IndexOf(search_name);
                        if (search_index != -1)
                        {
                            Console.WriteLine($"Name: {name[search_index]}\nPhone: {phone[search_index]}\nEmail: {email[search_index]} \nNotes: {notes[search_index]}");
                        }
                        else
                        {
                            Console.WriteLine("Name Not Found");
                        }
                        break;

                    default:
                        Console.WriteLine("Enter only from 0 to 4\n");
                        break;
                }
            }while (ch != 5);
        }
    }
}