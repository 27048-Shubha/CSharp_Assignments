namespace Assignment2.Services
{
    using Assignment2.Repository;
    using Assignment2.Validators;

    /// <summary>
    /// Handles business logic validation and sends call to repository after validation.
    /// </summary>
    public class EmployeeService
    {
        private EmployeeRepository repo;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeService"/> class.
        /// </summary>
        /// <param name="repo"> The object to handle repository operations. </param>
        /// <param name="validate"> The object to handle validation operations. </param>
        public EmployeeService(EmployeeRepository repo)
        {
            this.repo = repo;
        }

        /// <summary>
        /// Validates input and sends input parameters to the repository.
        /// </summary>
        /// <param name="name"> The name of the manager from the user. </param>
        /// <param name="salary"> The salary of the manager from the user. </param>
        /// <returns> The details of the employee If True, else invalid error message. </returns>
        public string AddManager(string name, string salary)
        {
            if (InputValidator.IsNumber(salary))
            {
                decimal amount = Convert.ToDecimal(salary);
                if (!InputValidator.IsZero(amount) && !InputValidator.IsNegative(amount))
                {
                    return this.repo.AddManager(name, amount);
                }
            }

            return "Invalid input, Enter only +ve numbers as salary";
        }

        /// <summary>
        /// Validates input and sends input parameters to the repository.
        /// </summary>
        /// <param name="name"> The name of the developer from the user. </param>
        /// <param name="salary"> The salary of the developer from the user. </param>
        /// <returns> The details of the employee If True, else invalid error message. </returns>
        public string AddDeveloper(string name, string salary)
        {
            if (InputValidator.IsNumber(salary))
            {
                decimal amount = Convert.ToDecimal(salary);
                if (!InputValidator.IsZero(amount) && !InputValidator.IsNegative(amount))
                {
                    return this.repo.AddDeveloper(name, amount);
                }
            }

            return "Invalid input, Enter only +ve numbers as salary";
        }
    }
}