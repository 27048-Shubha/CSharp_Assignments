using CollectionsAndGenerics.Services;
using CollectionsAndGenerics.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndGenerics.Controller
{
    public class DictController
    {
        private readonly DictionaryOperationsService<string, int> _service;

        internal DictController(DictionaryOperationsService<string, int> service)
        {
            this._service = service;
        }

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
