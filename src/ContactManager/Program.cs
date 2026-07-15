//Program.cs
using ContactManager.Persistance;
//using ContactManager.Helpers;
using ContactManager;

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
                DisplayMenu();
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
                        DisplayDefaultMessage();
                        break;
                }
            } while (ch != 6);
        }
    }
}