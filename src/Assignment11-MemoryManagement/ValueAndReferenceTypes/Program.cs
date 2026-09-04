namespace Assignments
{
    internal class Program
    {
        public struct PersonStruct
        {
            public PersonStruct(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }

            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class PersonClass
        {
            public PersonClass(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }

            public string Name { get; set; }
            public int Age { get; set; }
        }

        static void DisplayDash()
        {
            Console.WriteLine("--------------------------------------------");
        }

        static void Display(PersonStruct person1, PersonClass person2)
        {
            Program.DisplayDash();
            Console.WriteLine("Contents instide PersonStruct:");
            Console.WriteLine($"Name: {person1.Name}\nAge:{person1.Age}");

            Program.DisplayDash();
            Console.WriteLine("Contents instide PersonClass:");
            Console.WriteLine($"Name: {person2.Name}\nAge:{person2.Age}");
        }

        static void Modify(PersonStruct person1, PersonClass person2)
        {
            person1.Name = "Shree";
            person1.Age = 15;

            person2.Name = "Shree";
            person2.Age = 15;
        }

        public static void Main(string[] args)
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