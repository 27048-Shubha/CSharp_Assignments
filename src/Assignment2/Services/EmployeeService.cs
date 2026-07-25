using Assignment2.Repository;
using Assignment2.Validations;
using Assignment2.Views;

namespace Assignment2.Services
{
    /// <summary>
    /// Handles Pre-Check (Validation) Before Input Value enters the Repository
    /// </summary>
    public class EmployeeService
    {
        private ValidateInput _validate;
        private EmployeeRepository _repo;

        public EmployeeService(EmployeeRepository _repo,ValidateInput _validate)
        {
            this._repo = _repo;
            this._validate = _validate;
        }

        /// <summary>
        /// Checks and passes the name, salary to the Employee Repository
        /// </summary>
        /// <param name="name"> Name of the Manager entered by the user </param>
        /// <param name="salary"> Salary of the Manager entered by the user </param>
        /// <returns> Details of the Employee If True, else Invalid Error Message </returns>
        public string AddManager(string name, string salary)
        {
            if(_validate.IsNumber(salary))
            {
                decimal amount = Convert.ToDecimal(salary);
                if (!_validate.IsZero(amount) && !_validate.IsNegative(amount))
                {
                    return _repo.AddManager(name, amount);
                }
            }
            return "Invalid Input, Enter Only +ve Numbers";
        }

        /// <summary>
        /// Checks and passes the name, salary to the Employee Repository
        /// </summary>
        /// <param name="name"> Name of the Developer entered by the user </param>
        /// <param name="salary"> Salary of the Developer entered by the user </param>
        /// <returns> Details of the Employee If True, else Invalid Error Message </returns>
        public string AddDeveloper(string name, string salary)
        {
            if (_validate.IsNumber(salary))
            {
                decimal amount = Convert.ToDecimal(salary);
                if (!_validate.IsZero(amount) && !_validate.IsNegative(amount))
                {
                    return _repo.AddDeveloper(name, amount);
                }
            }
            return "Invalid Input, Enter Only +ve Numbers";
        }
    }
}