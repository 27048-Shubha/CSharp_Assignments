namespace Assignment2.Views
{
    /// <summary>
    /// Hanldes Console Operations of Employee System
    /// </summary>
    internal class EmployeeView: MainView
    {
        /// <summary>
        /// Displays StartUp Menu for Employee System
        /// </summary>
        public void DisplayEmployeeMenu()
        {
            Console.WriteLine("Welcome to EMPLOYEE SYSTEM\n");
            Console.WriteLine("[D] to enter details of Developer\n");
            Console.WriteLine("[M] to enter details of Manager\n");
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
            Console.WriteLine("Enter Name\n");
            return Console.ReadLine();
        }

        /// <summary>
        /// Gets Salary of the Employee
        /// </summary>
        /// <returns> Name as Input from user </returns>
        public string GetEmployeeSalary()
        {
            Console.WriteLine("Enter Salary\n");
            return Console.ReadLine();
        }

        /// <summary>
        /// Displays Message received.
        /// </summary>
        /// <param name="message"> User Details or Error Message as string </param>
        public void DisplayMessage(string message)
        {
            Console.WriteLine($"{message}");
        }

        
    }
}