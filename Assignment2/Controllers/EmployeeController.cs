using Assignment2.Services;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// Controls Menu service and communicates with Console and Service
    /// </summary>
    public class EmployeeController
    {
        private EmployeeView _console = new EmployeeView();
        private EmployeeService _service = new EmployeeService();

        /// <summary>
        /// Execution of Employee starts here
        /// </summary>
        public void Initialize()
        {
            _console.DisplayEmployeeMenu();
            char choice = _console.GetEmployeeMenuInput();
            string name;
            decimal salary;
            string message;

            switch(choice)
            {
                case 'D':
                case 'd':
                    name = _console.GetEmployeeName();
                    salary = _console.GetEmployeeSalary();
                    message = _service.AddDeveloper(name, salary);
                    _console.DisplayMessage(message);

                    break;

                case 'M':
                case 'm':
                    name = _console.GetEmployeeName();
                    salary = _console.GetEmployeeSalary();
                    message = _service.AddManager(name, salary);
                    _console.DisplayMessage(message);
                    break;

                default:
                    _console.DisplayDefault();
                    break;
            }
        } 
    }
}
