namespace Assignment2.Repository
{
    using Assignment2.Models;

    /// <summary>
    /// Handles repository operations of the employee hierarchy application.
    /// </summary>
    public class EmployeeRepository
    {
        /// <summary>
        /// Intantiates and initializes object values of manager.
        /// </summary>
        /// <param name="name">The _name of the manager. </param>
        /// <param name="salary">The salary of the manager. </param>
        /// <returns>The details of manager created. </returns>
        public string AddManager(string name, decimal salary)
        {
            Manager manager = new Manager()
            {
                Name = name,
                Salary = salary,
            };
            return manager.PrintDetails();
        }

        /// <summary>
        /// Intantiates and initializes object values of developer.
        /// </summary>
        /// <param name="name">The _name of the developer. </param>
        /// <param name="salary">The salary of the developer. </param>
        /// <returns>The details of developer created. </returns>
        public string AddDeveloper(string name, decimal salary)
        {
            Developer dev = new Developer()
            {
                Name = name,
                Salary = salary,
            };
            return dev.PrintDetails();
        }
    }
}