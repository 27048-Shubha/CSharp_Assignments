namespace ContactManager
{
    using ContactManager.Controllers;
    using ContactManager.Persistance;
    using ContactManager.Services;
    using ContactManager.Validations;

    /// <summary>
    /// Application entry point and composition root. Wires up the dependencies once and hands control to the controller.
    /// </summary>
    public class Program
    {
        public static bool IsFileStorage;
        public static string FileName;
        /// <summary>
        /// Execution of flow begins from here.
        /// </summary>
        /// <param name="args">CommandLine Args.</param>
        public static void Main(string[] args)
        {
            ContactValidator validate = new ContactValidator();

            ConsoleView console = new ConsoleView();

            ContactRepository repository = new ContactRepository();

            ContactService service = new ContactService(repository, validate);

            ContactController controller = new ContactController(console, service);

            FileName = console.GetStorageChoice();
            IsFileStorage = FileName == "Y" ? true : false;

            controller.Initialize();
        }
    }
}
