using Assignment2.Controllers;

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
            Console.WriteLine("Welcome to Hierarchy System!\nKindly choose 'S' to enter Shape Hierarchy System\n'E' to enter Employee System\n'B' to enter Banking System\n");
            char ch = Char.Parse(Console.ReadLine());
            switch (ch)
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

                default:
                    Console.WriteLine("Thank You! Quitting now!");
                    break;
            }   
        }
    }
}
