using Assignment2.Services;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// Controls Menu service and communicates with Console and Service
    /// </summary>
    public class EmployeeController
    {
        private EmployeeView _console;
        private EmployeeService _service;

        public EmployeeController(EmployeeView _console, EmployeeService _service)
        {
            this._console = _console;
            this._service = _service;
        }


        /// <summary>
        /// Execution of Employee starts here
        /// </summary>
        public void Initialize()
        {
            char choice;

            do
            {
                _console.DisplayEmployeeMenu();
                choice = _console.GetEmployeeMenuInput();
                string message;

                switch (choice)
                {
                    case 'D':
                    case 'd':
                        message = _service.AddDeveloper(_console.GetEmployeeName(), _console.GetEmployeeSalary());
                        _console.DisplayMessage(message);
                        break;

                    case 'M':
                    case 'm':
                        message = _service.AddManager(_console.GetEmployeeName(), _console.GetEmployeeSalary());
                        _console.DisplayMessage(message);
                        break;


                    case 'Q':
                    case 'q':
                        _console.DisplayExitMessage();
                        break;

                    default:
                        _console.DisplayDefault();
                        break;
                }
            } while (choice != 'Q' && choice != 'q');
        }
    }
}