namespace Assignment2.Views
{
    /// <summary>
    /// Hanldes Console Operations of Employee System
    /// </summary>
    public class EmployeeView: MainView
    {
        /// <summary>
        /// Displays StartUp Menu for Employee System
        /// </summary>
        public void DisplayEmployeeMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            base.DisplayLineBreaker();
            Console.WriteLine("Welcome to EMPLOYEE SYSTEM\n");
            Console.WriteLine("[D] to enter details of Developer:");
            Console.WriteLine("[M] to enter details of Manager:");
            base.DisplayLineBreaker();
            Console.ResetColor();
        }

        /// <summary>
        /// Gets Choice for Menu
        /// </summary>
        /// <returns> User's Choice </returns>
        public char GetEmployeeMenuInput()
        {
            return Char.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Gets Name of the Employee
        /// </summary>
        /// <returns> Name as Input from user </returns>
        public string GetEmployeeName()
        {
            Console.WriteLine("Enter Name: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets Salary of the Employee
        /// </summary>
        /// <returns> Name as Input from user </returns>
        public string GetEmployeeSalary()
        {
            Console.WriteLine("Enter Salary: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Displays Message received.
        /// </summary>
        /// <param name="message"> User Details or Error Message as string </param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine($"{message}\n");
        }

        
    }
}