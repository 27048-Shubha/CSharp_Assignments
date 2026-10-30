namespace Assignment17_Reflections.Utilities
{
    /// <summary>
    /// Represents contract of service of the student.
    /// </summary>
    public interface IStudentService
    {
        /// <summary>
        /// Gets name of the student.
        /// </summary>
        /// <returns>Name of the student.</returns>
        public string GetStudentName();

        /// <summary>
        /// Gets age of the student.
        /// </summary>
        /// <returns>Age of the student.</returns>
        public int GetAge();

        /// <summary>
        /// Displays details of the student.
        /// </summary>
        public void DisplayDetails();
    }
}
