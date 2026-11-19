namespace Assignments
{
    /// <summary>
    /// A class representing person.
    /// </summary>
    public class PersonClass
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonClass"/> class.
        /// </summary>
        /// <param name="name">Name of the person.</param>
        /// <param name="age">Age of the person.</param>
        public PersonClass(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        /// <value>Person's name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the person.
        /// </summary>
        /// <value>Person's age.</value>
        public int Age { get; set; }
    }
}