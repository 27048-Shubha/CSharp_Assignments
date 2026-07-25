using Assignment2.Controllers;
using Assignment2.Repository;
using Assignment2.Services;
using Assignment2.Validations;
using Assignment2.Views;

namespace Assignment2
{
    /// <summary>
    /// Start of CS Project.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Beginning Execution of the Program
        /// </summary>
        public static void Main()
        {
            ValidateInput _validate = new ValidateInput();

            MainView _console = new MainView();
            ShapeView _shapeView = new ShapeView();
            EmployeeView _employeeView = new EmployeeView();
            BankSystemView _bankSystemView = new BankSystemView();

            ShapeRepository _shapeRepo = new ShapeRepository();
            EmployeeRepository _employeeRepo = new EmployeeRepository();
            BankSystemRepo _bankRepo = new BankSystemRepo();

            ShapeService _shapeService = new ShapeService(_shapeRepo, _validate);
            EmployeeService _employeeService = new EmployeeService(_employeeRepo, _validate);
            BankSystemService _bankSystemService = new BankSystemService(_bankRepo, _validate);

            char choice;
            do
            {
                _console.DisplayMenu();
                choice = Char.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 'S':
                    case 's':
                        ShapeController shapeController = new ShapeController(_shapeView, _shapeService);
                        shapeController.Initialize();
                        break;

                    case 'E':
                    case 'e':
                        EmployeeController employeeController = new EmployeeController(_employeeView, _employeeService);
                        employeeController.Initialize();
                        break;

                    case 'B':
                    case 'b':
                        BankSystemController bankController = new BankSystemController(_bankSystemView, _bankSystemService);
                        bankController.Initialize();
                        break;

                    case 'Q':
                    case 'q':
                        _console.DisplayExitMessage();
                        break;

                    default:
                        _console.DisplayDefault();
                        break;
                }
            } while (choice != 'q' || choice != 'Q');
        }
    }
}
