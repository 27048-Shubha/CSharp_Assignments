using Assignment2.Validators;

namespace Assignment2.Views
{
    /// <summary>
    /// Handles the console operations of employee system.
    /// </summary>
    public class EmployeeView : MainView
    {
        /// <summary>
        /// Displays startup menu for the employee system.
        /// </summary>
        public override void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            this.DisplayLineBreaker();
            Console.WriteLine("Welcome to employee system\n");
            Console.WriteLine("[D] to enter details of Developer:");
            Console.WriteLine("[M] to enter details of Manager:");
            Console.WriteLine("[B] to go back to main menu");
            this.DisplayLineBreaker();
            Console.ResetColor();
        }

        /// <summary>
        /// Gets name of the employee.
        /// </summary>
        /// <returns> The input name from the user. </returns>
        public string GetEmployeeName()
        {
            Console.WriteLine("Enter name: ");
            string name = Console.ReadLine() ?? string.Empty;
            if (name != string.Empty)
            {
                return name;
            }

            return "Name not defined";
        }

        /// <summary>
        /// Gets salary of the employee.
        /// </summary>
        /// <returns> The input salary from user. </returns>
        public decimal GetEmployeeSalary()
        {
            while (true)
            {
                Console.WriteLine("Enter salary: ");
                if (InputValidator.IsValidDecimal(Console.ReadLine(), out decimal salary))
                {
                    return salary;
                }
                else
                {
                    Console.WriteLine("Invalid input! Salary must be a valid number!");
                }
            }
        }

        /// <summary>
        /// Displays the message received as argument.
        /// </summary>
        /// <param name="message"> The message received as the argument.</param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine($"{message}\n");
        }
    }
}