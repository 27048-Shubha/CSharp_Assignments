namespace Assignment17_Reflections.Utilities
{
    /// <summary>
    /// Represents details of the course.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// Gets or sets title of the course.
        /// </summary>
        /// <value> Title of the course. </value>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets student object to the course.
        /// </summary>
        /// <value> Student object to be mapped to this course instance. </value>
        public Student Student { get; set; }
    }
}
