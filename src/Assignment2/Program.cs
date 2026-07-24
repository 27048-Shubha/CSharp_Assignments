using Assignment2.Controllers;
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
            MainView _console = new MainView();
            char choice;
            do
            {
                _console.DisplayMenu();
                choice = Char.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 'S':
                    case 's':
                        ShapeController shapeController = new ShapeController();
                        shapeController.Initialize();
                        break;

                    case 'E':
                    case 'e':
                        EmployeeController employeeController = new EmployeeController();
                        employeeController.Initialize();
                        break;

                    case 'B':
                    case 'b':
                        BankSystemController bankController = new BankSystemController();
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
