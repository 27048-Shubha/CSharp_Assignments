namespace Assignment2.Controllers
{
    using Assignment2.Services;
    using Assignment2.Views;

    /// <summary>
    /// Controls Employee system's menu this.service and communicates with this.console and this.service.
    /// </summary>
    public class EmployeeController
    {
        private EmployeeView console;
        private EmployeeService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="console"> The object to handle console operations. </param>
        /// <param name="service"> The object to handle services. </param>
        public EmployeeController(EmployeeView console, EmployeeService service)
        {
            this.console = console;
            this.service = service;
        }

        /// <summary>
        /// Start point of execution of Employee Hierarchy system.
        /// </summary>
        public void Initialize()
        {
            char choice;

            while (true)
            {
                this.console.DisplayMenu();
                choice = this.console.GetUserChoice();
                string message;

                switch (choice)
                {
                    case 'D':
                    case 'd':
                        message = this.service.AddDeveloper(this.console.GetEmployeeName(), this.console.GetEmployeeSalary());
                        this.console.DisplayMessage(message);
                        break;

                    case 'M':
                    case 'm':
                        message = this.service.AddManager(this.console.GetEmployeeName(), this.console.GetEmployeeSalary());
                        this.console.DisplayMessage(message);
                        break;

                    case 'B':
                    case 'b':
                        this.console.DisplayExitMessage();
                        return;

                    default:
                        this.console.DisplayDefault();
                        break;
                }
            }
        }
    }
}