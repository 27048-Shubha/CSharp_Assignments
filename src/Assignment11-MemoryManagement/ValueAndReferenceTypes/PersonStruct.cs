namespace Assignments
{
    /// <summary>
    /// A struct representing person.
    /// </summary>
    public struct PersonStruct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonStruct"/> struct.
        /// </summary>
        /// <param name="name">Name of the person.</param>
        /// <param name="age">Age of the person.</param>
        public PersonStruct(string name, int age)
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
        /// Gets or sets age of the person.
        /// </summary>
        /// <value>Person's age.</value>
        public int Age { get; set; }
    }
}