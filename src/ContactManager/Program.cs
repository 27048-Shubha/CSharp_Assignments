using ContactManager.Persistance;

namespace Assignments
{
    /// <summary>
    /// Program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method where execution begins
        /// </summary>
        /// <param name="args">CommandLine Args</param>
        public static void Main(string[] args)
        {
            int ch;
            do
            {
                Console.WriteLine("Welcome to the Contact Manager! \nENTER 0 to VIEW ALL CONTACT, \n1 TO ADD NEW CONTACT, \n2 TO EDIT EXSISTING CONTACT, \n3 TO DELETE ANY CONTACT, \n4 TO SEARCH ANY CONTACT, \n5 TO VIEW SORTED LIST\n6 TO EXIT\n");
                ch = int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 0: // VIEW
                        Repository.ViewContact();
                        break;

                    case 1: // ADD
                        Repository.AddContact();
                        break;

                    case 2: // EDIT
                        Repository.EditContact();
                        break;

                    case 3: // DELETE
                        Repository.DeleteContact();
                        break;

                    case 4: // SEARCH
                        Repository.SearchContact();
                        break;

                    case 5: //SORT
                        Repository.SortContact();
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