namespace Assignments
{
    /// <summary>
    /// Manages flow of demonstration.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Displays dash to the console.
        /// </summary>
        public static void DisplayDash()
        {
            Console.WriteLine("--------------------------------------------");
        }

        /// <summary>
        /// Displays stucture and class contents to the file.
        /// </summary>
        /// <param name="person1">A structure representing person</param>
        /// <param name="person2">A class representingperson</param>
        public static void Display(PersonStruct person1, PersonClass person2)
        {
            Program.DisplayDash();
            Console.WriteLine("Contents instide PersonStruct:");
            Console.WriteLine($"Name: {person1.Name}\nAge:{person1.Age}");

            Program.DisplayDash();
            Console.WriteLine("Contents instide PersonClass:");
            Console.WriteLine($"Name: {person2.Name}\nAge:{person2.Age}");
        }

        /// <summary>
        /// Modifies stucture and class contents.
        /// </summary>
        /// <param name="person1">A structure representing person</param>
        /// <param name="person2">A class representingperson</param>
        public static void Modify(PersonStruct person1, PersonClass person2)
        {
            person1.Name = "Shree";
            person1.Age = 15;

            person2.Name = "Shree";
            person2.Age = 15;
        }

        /// <summary>
        /// Entry point of the program.
        /// </summary>
        public static void Main()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            PersonStruct person1 = new PersonStruct(name, age);
            PersonClass person2 = new PersonClass(name, age);

            Console.WriteLine("\nContents before modifying:");
            Program.Display(person1, person2);

            Program.Modify(person1, person2);

            Program.DisplayDash();
            Console.WriteLine("\nContents after modifying:");
            Program.Display(person1, person2);
        }
    }
}