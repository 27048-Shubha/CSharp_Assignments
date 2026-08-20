namespace Assignment2.Controllers
{
    using Assignment2.Services;
    using Assignment2.Views;

    /// <summary>
    /// Controls Employee system's menu this._service and communicates with this._console and this._service.
    /// </summary>
    public class EmployeeController
    {
        private EmployeeView _console;
        private EmployeeService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="console"> The object to handle _console operations. </param>
        /// <param name="service"> The object to handle services. </param>
        public EmployeeController(EmployeeView console, EmployeeService service)
        {
            this._console = console;
            this._service = service;
        }

        /// <summary>
        /// Start point of execution of Employee Hierarchy system.
        /// </summary>
        public void Initialize()
        {
            char choice;

            while (true)
            {
                this._console.DisplayMenu();
                choice = this._console.GetUserChoice();
                string message;

                switch (choice)
                {
                    case 'D':
                    case 'd':
                        message = this._service.AddDeveloper(this._console.GetEmployeeName(), this._console.GetEmployeeSalary());
                        this._console.DisplayMessage(message);
                        break;

                    case 'M':
                    case 'm':
                        message = this._service.AddManager(this._console.GetEmployeeName(), this._console.GetEmployeeSalary());
                        this._console.DisplayMessage(message);
                        break;

                    case 'B':
                    case 'b':
                        this._console.DisplayExitMessage();
                        return;

                    default:
                        this._console.DisplayDefault();
                        break;
                }
            }
        }
    }
}