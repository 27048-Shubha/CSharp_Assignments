/// <summary>
/// A class representing person.
/// </summary>
public class PersonClass
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PersonClass"/> struct.
    /// </summary>
    /// <param name="name">Name of the person.</param>
    /// <param name="age">Age of the person.</param>
    public PersonClass(string name, int age)
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
