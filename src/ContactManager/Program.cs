namespace Assignments
{
    using ContactManager.Controllers;

    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method where execution begins.
        /// </summary>
        /// <param name="args">CommandLine Args.</param>
        public static void Main(string[] args)
        {
            ContactController controller = new ContactController();
            controller.Initialize();
        }
    }
}
