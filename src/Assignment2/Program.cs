namespace Assignment2
{
    using Assignment2.Controllers;
    using Assignment2.Repository;
    using Assignment2.Services;
    using Assignment2.Validators;
    using Assignment2.Views;

    /// <summary>
    /// Entry point of application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts and invokes application.
        /// </summary>
        public static void Main()
        {
            MainView console = new MainView();
            ShapeView shapeView = new ShapeView();
            EmployeeView employeeView = new EmployeeView();
            BankSystemView bankSystemView = new BankSystemView();

            ShapeRepository shapeRepo = new ShapeRepository();
            EmployeeRepository employeeRepo = new EmployeeRepository();
            BankSystemRepo bankRepo = new BankSystemRepo();

            ShapeService shapeService = new ShapeService(shapeRepo);
            EmployeeService employeeService = new EmployeeService(employeeRepo);
            BankSystemService bankSystemService = new BankSystemService(bankRepo);

            ShapeController shapeController = new ShapeController(shapeView, shapeService);
            EmployeeController employeeController = new EmployeeController(employeeView, employeeService);
            BankSystemController bankController = new BankSystemController(bankSystemView, bankSystemService);

            char choice;
            while (true)
            {
                console.DisplayMenu();
                choice = console.GetUserChoice();
                switch (choice)
                {
                    case 'S':
                    case 's':
                        shapeController.Initialize();
                        break;

                    case 'E':
                    case 'e':
                        employeeController.Initialize();
                        break;

                    case 'B':
                    case 'b':
                        bankController.Initialize();
                        break;

                    case 'Q':
                    case 'q':
                        console.DisplayExitMessage();
                        return;

                    default:
                        console.DisplayDefault();
                        break;
                }
            }
        }
    }
}
