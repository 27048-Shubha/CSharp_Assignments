using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Services
{
    public class EmployeeService
    {
        private EmployeeRepository _repo = new EmployeeRepository();
        public int AddEmployee(string name, int salary)
        {
            if(_repo.ValidateName(salary))
            {
                _repo.AddEmployee(name, salary);
            }
        }
    }
}
