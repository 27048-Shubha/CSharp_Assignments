namespace Assignment2.Services
{
    using Assignment2.Repository;
    using Assignment2.Validators;

    /// <summary>
    /// Handles business logic validation and sends call to repository after validation.
    /// </summary>
    public class EmployeeService
    {
        private readonly EmployeeRepository _repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="repo"> The object to handle repository operations. </param>
        /// <param name="validate"> The object to handle validation operations. </param>
        public EmployeeService(EmployeeRepository repo)
        {
            this._repo = repo;
        }

        /// <summary>
        /// Validates input and sends input parameters to the repository.
        /// </summary>
        /// <param name="name"> The _name of the manager from the user. </param>
        /// <param name="salary"> The salary of the manager from the user. </param>
        /// <returns> The details of the employee If True, else invalid error message. </returns>
        public string AddManager(string name, decimal salary)
        {
            if (InputValidator.IsPositive(salary))
            {
                    return this._repo.AddManager(name, salary);
            }

            return "Invalid input, Enter only +ve numbers as salary";
        }

        /// <summary>
        /// Validates input and sends input parameters to the repository.
        /// </summary>
        /// <param name="name"> The _name of the developer from the user. </param>
        /// <param name="salary"> The salary of the developer from the user. </param>
        /// <returns> The details of the employee If True, else invalid error message. </returns>
        public string AddDeveloper(string name, decimal salary)
        {
            if (InputValidator.IsPositive(salary))
            {
                return this._repo.AddDeveloper(name, salary);
            }

            return "Invalid input, Enter only +ve numbers as salary";
        }
    }
}