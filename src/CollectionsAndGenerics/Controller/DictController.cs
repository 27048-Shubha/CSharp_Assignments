using CollectionsAndGenerics.Services;
using CollectionsAndGenerics.View;

namespace CollectionsAndGenerics.Controller
{
    /// <summary>
    /// Controlls dictionary operations.
    /// </summary>
    public class DictController
    {
        private readonly DictionaryOperationsService<string, int> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="DictController"/> class.
        /// </summary>
        /// <param name="service">Object to handle dictionary services</param>
        internal DictController(DictionaryOperationsService<string, int> service)
        {
            this._service = service;
        }

        /// <summary>
        /// Entry point of dictionary operation demonstration.
        /// </summary>
        public void Run()
        {
            this.DisplayHeader();

            ConsoleView.DisplayMessage("\n--------- Adding Students and Grades ---------");
            this.AddStudentDetails();
            this.Display();

            ConsoleView.DisplayMessage("\n--------- Removing Student \"Bob\" ---------");
            this._service.Remove("Bob");

            ConsoleView.DisplayMessage("\n---------  After Removing \"Bob\" ---------");
            this.Display();
        }

        private void DisplayHeader()
        {
            ConsoleView.DisplayMessage("=================================================");
            ConsoleView.DisplayMessage("  DICTIONARY DEMONSTRATION STUDENT GRADE MANAGEMENT SYSTEM");
            ConsoleView.DisplayMessage("=================================================");
        }

        private void AddStudentDetails()
        {
            string[] studentNames = { "Shubha", "Bob", "Ferb", "Finneas", "Patrick"};
            int[] studentGrades = { 9, 10, 7, 8, 9 };

            for (int i = 0; i < studentNames.Length; i++)
            {
                this._service.Add(studentNames[i], studentGrades[i]);
            }
        }

        private void Display()
        {
            IReadOnlyDictionary<string, int> students = this._service.GetAll();
            ConsoleView.DisplayMessage("Students and Grades:");
            ConsoleView.DisplayMessage( "--------------------------------------------------------");

            ConsoleView.DisplayDictionary(students);
            ConsoleView.DisplayMessage("\n");
        }
    }
}
