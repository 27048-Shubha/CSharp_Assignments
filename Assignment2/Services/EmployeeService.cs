using Assignment2.Repository;

namespace Assignment2.Services
{
    public class EmployeeService
    {
        private EmployeeRepository _repo = new EmployeeRepository();
        public string AddManager(string name, decimal salary)
        {
            //if(_repo.ValidateSalary(salary))
            {
                return _repo.AddManager(name, salary);
            }
            return "Invalid Input";
        }
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
