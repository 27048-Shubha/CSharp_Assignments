namespace Assignment1_ContactManager
{
    using ContactManager;
    using ContactManager.Controllers;
    using ContactManager.Persistance;
    using ContactManager.Services;
    using ContactManager.Validations;

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
            ContactValidator _validate = new ContactValidator();

            ConsoleView _console = new ConsoleView();

            ContactRepository _repository = new ContactRepository();

            ContactService _service = new ContactService(_repository, _validate);

            ContactController controller = new ContactController(_console, _service);

            controller.Initialize();
        }
    }
}
