namespace Assignment17_Reflections.Utilities
{
    /// <summary>
    /// Represents student class.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="name">Name of the student</param>
        /// <param name="age">Age of the student</param>
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        /// <summary>
        /// Gets or sets name of the student.
        /// </summary>
        /// <value> Name of the student. </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets age of the student.
        /// </summary>
        /// <value> Age of the student. </value>
        public int Age { get; set; }

        /// <summary>
        /// Displays name of the student.
        /// </summary>
        public void DisplayName()
        {
            Console.WriteLine($"Name: {this.Name}");
        }

        /// <summary>
        /// Displays age of the student.
        /// </summary>
        public void DisplayAge()
        {
            Console.WriteLine($"Age: {this.Age}");
        }
    }
}
