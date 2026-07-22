using Assignment2.Repository;

namespace Assignment2.Services
{
    /// <summary>
    /// Handles Pre-Check (Validation) Before Input Value enters the Repository
    /// </summary>
    public class EmployeeService
    {
        private EmployeeRepository _repo = new EmployeeRepository();

        /// <summary>
        /// Checks and passes the name, salary to the Employee Repository
        /// </summary>
        /// <param name="name"> Name of the Manager entered by the user </param>
        /// <param name="salary"> Salary of the Manager entered by the user </param>
        /// <returns> Details of the Employee If True, else Invalid Error Message </returns>
        public string AddManager(string name, decimal salary)
        {
            //if(_repo.ValidateSalary(salary))
            {
                return _repo.AddManager(name, salary);
            }
            return "Invalid Input";
        }

        /// <summary>
        /// Checks and passes the name, salary to the Employee Repository
        /// </summary>
        /// <param name="name"> Name of the Developer entered by the user </param>
        /// <param name="salary"> Salary of the Developer entered by the user </param>
        /// <returns> Details of the Employee If True, else Invalid Error Message </returns>
        public string AddDeveloper(string name, decimal salary)
        {
            //if(_repo.ValidateSalary(salary))
            {
                return _repo.AddDeveloper(name, salary);
            }
            return "Invalid Input";
        }
    }
}
