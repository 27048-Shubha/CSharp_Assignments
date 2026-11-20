namespace Assignments
{
    /// <summary>
    /// Manages flow of demonstration.
    /// </summary>
    public class Program
    {
        private static readonly string _name = "Shubha";
        private static readonly int _age = 20;

        /// <summary>
        /// Displays dash to the console.
        /// </summary>
        public static void DisplayDash()
        {
            Console.WriteLine("--------------------------------------------");
        }

        /// <summary>
        /// Displays structure and class contents to the file.
        /// </summary>
        /// <param name="person1">A structure representing person</param>
        /// <param name="person2">A class representing a person</param>
        public static void Display(PersonStruct person1, PersonClass person2)
        {
            DisplayDash();
            Console.WriteLine("Contents instide PersonStruct:");
            Console.WriteLine($"Name: {person1.Name}\nAge:{person1.Age}");

            DisplayDash();
            Console.WriteLine("Contents instide PersonClass:");
            Console.WriteLine($"Name: {person2.Name}\nAge:{person2.Age}");
        }

        /// <summary>
        /// Modifies structure and class contents.
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
            PersonStruct person1 = new PersonStruct(_name, _age);
            PersonClass person2 = new PersonClass(_name, _age);

            Console.WriteLine("\nContents before modifying:");
            Display(person1, person2);

            Modify(person1, person2);

            DisplayDash();
            Console.WriteLine("\nContents after modifying:");
            Display(person1, person2);
        }
    }
}