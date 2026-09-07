namespace GarbageCollection.Student
{
    /// <summary>
    /// Represents student details.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Student"/> class.
        /// </summary>
        /// <param name="name">Name of the student.</param>
        /// <param name="age">Age of the student.</param>
        internal Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        /// <summary>
        /// Gets or sets the name of the student.
        /// </summary>
        /// <value>Student name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the student.
        /// </summary>
        /// <value>Student age.</value>
        public int Age { get; set; }
    }
}
