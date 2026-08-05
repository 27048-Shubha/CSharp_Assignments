namespace ContactManager
{
    using ContactManager.Controllers;
    using ContactManager.Repository;
    using ContactManager.Services;
    using ContactManager.Validations;

    /// <summary>
    /// Application entry point and composition root. Wires up the dependencies once and hands control to the controller.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Indicates whether file storage is being used.
        /// </summary>
        private static bool isFileStorage;

        /// <summary>
        /// Holds name of the file on which operations to be performed.
        /// </summary>
        private static string fileName;

        /// <summary>
        /// Execution of flow begins from here.
        /// </summary>
        /// <param name="args">CommandLine Args.</param>
        public static void Main(string[] args)
        {
            ContactValidator validate = new ContactValidator();

            ConsoleView console = new ConsoleView();

            ContactService? service = null;

            console.DisplayWelcome();
            string choice;

            isFileStorage = console.GetStorageChoice() == "Y" ? true : false;

            if (isFileStorage)
            {
                Program.fileName = console.GetFileName();
                if (!File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Data", fileName)))
                {
                    console.DisplayFileNotFound();
                    choice = console.GetChoice();
                    if (choice != "Y")
                    {
                        return;
                    }

                    // Console.WriteLine("Printting from Program.cs - file");
                }

                service = new ContactService(new CSVContactRepository(fileName), validate);
            }
            else
            {
                service = new ContactService(new ContactRepository(), validate);
            }

            ContactController controller = new ContactController(console, service);

            controller.Initialize();
        }
    }
}
