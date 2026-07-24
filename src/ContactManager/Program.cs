namespace Assignments
{
    using ContactManager.Controllers;

    /// <summary>
    /// Manages Initialization of Contact Management System.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Execution of flow begins from here.
        /// </summary>
        /// <param name="args">CommandLine Args.</param>
        public static void Main(string[] args)
        {
            ContactController controller = new ContactController();
            controller.Initialize();
        }
    }
}
