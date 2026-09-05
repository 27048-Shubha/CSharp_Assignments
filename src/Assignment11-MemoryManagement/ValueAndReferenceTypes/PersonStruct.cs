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
    /// Name of the person.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Age of the person.
    /// </summary>
    /// <value>Person's age.</value>
    public int Age { get; set; }
}