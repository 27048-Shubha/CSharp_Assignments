namespace Assignment17_Reflections.Utilities
{
    public class Student
    {
        internal Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public void DisplayName()
        {
            Console.WriteLine($"Name: {this.Name}");
        }

        public void DisplayAge()
        {
            Console.WriteLine($"Age: {this.Age}");
        }
    }
}
