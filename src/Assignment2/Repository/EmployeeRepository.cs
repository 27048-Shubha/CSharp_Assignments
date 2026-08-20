namespace Assignment2.Repository
{
    using Assignment2.Models.Task2;

    /// <summary>
    /// Handles repository operations of the employee hierarchy application.
    /// </summary>
    public class EmployeeRepository
    {
        /// <summary>
        /// Intantiates and initializes object values of manager.
        /// </summary>
        /// <param name="name">The name of the manager. </param>
        /// <param name="_salary">The _salary of the manager. </param>
        /// <returns>The details of manager created. </returns>
        public string AddManager(string name, decimal salary)
        {
            Manager manager = new Manager();
            manager.Name = name;
            manager.Salary = salary;
            manager.Bonus = manager.CalculateBonus();
            return manager.PrintDetails();
        }

        /// <summary>
        /// Intantiates and initializes object values of developer.
        /// </summary>
        /// <param name="name">The name of the developer. </param>
        /// <param name="_salary">The _salary of the developer. </param>
        /// <returns>The details of developer created. </returns>
        public string AddDeveloper(string name, decimal salary)
        {
            Developer dev = new Developer();
            dev.Name = name;
            dev.Salary = salary;
            dev.Bonus = dev.CalculateBonus();
            return dev.PrintDetails();
        }
    }
}