namespace Assignment2
{
    using Assignment2.Controllers;
    using Assignment2.Repository;
    using Assignment2.Services;
    using Assignment2.Validations;
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
            ValidateInput validate = new ValidateInput();

            MainView console = new MainView();
            ShapeView shapeView = new ShapeView();
            EmployeeView employeeView = new EmployeeView();
            BankSystemView bankSystemView = new BankSystemView();

            ShapeRepository shapeRepo = new ShapeRepository();
            EmployeeRepository employeeRepo = new EmployeeRepository();
            BankSystemRepo bankRepo = new BankSystemRepo();

            ShapeService shapeService = new ShapeService(shapeRepo, validate);
            EmployeeService employeeService = new EmployeeService(employeeRepo, validate);
            BankSystemService bankSystemService = new BankSystemService(bankRepo, validate);

            char choice;
            do
            {
                console.DisplayMenu();
                choice = console.GetUserChoice();
                switch (choice)
                {
                    case 'S':
                    case 's':
                        ShapeController shapeController = new ShapeController(shapeView, shapeService);
                        shapeController.Initialize();
                        break;

                    case 'E':
                    case 'e':
                        EmployeeController employeeController = new EmployeeController(employeeView, employeeService);
                        employeeController.Initialize();
                        break;

                    case 'B':
                    case 'b':
                        BankSystemController bankController = new BankSystemController(bankSystemView, bankSystemService);
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
            while (choice != 'q' || choice != 'Q');
        }
    }
}
