namespace Assignment2.Views
{
    /// <summary>
    /// Hanldes the console operations of employee system.
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
            this.DisplayLineBreaker();
            Console.ResetColor();
        }

        /// <summary>
        /// Gets name of the employee.
        /// </summary>
        /// <returns> The input name from the user. </returns>
        public string GetEmployeeName()
        {
            Console.WriteLine("Enter Name: ");
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Gets salary of the employee.
        /// </summary>
        /// <returns> The input salary from user. </returns>
        public string GetEmployeeSalary()
        {
            Console.WriteLine("Enter Salary: ");
            return Console.ReadLine() ?? string.Empty;
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