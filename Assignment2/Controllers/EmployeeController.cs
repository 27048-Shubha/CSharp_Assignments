using Assignment2.Services;
using Assignment2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Controllers
{
    internal class EmployeeController
    {
        private EmployeeView _console = new EmployeeView();
        private EmployeeService _service = new EmployeeService();
        public void Initialize()
        {
            _console.DisplayEmployeeMenu();
            char choice = _console.GetEmployeeMenuInput();
            string name;
            decimal salary;

            switch(choice)
            {
                case 'D':
                case 'd':
                    name = _console.GetEmployeeName();
                    salary = Console.GetEmployeeSalary();
                    _service.AddEmployee(name, salary);

                    break;

                case 'M':
                case 'm':
                    name = _console.GetEmployeeName();
                    salary = Console.GetEmployeeSalary();
                    _service.AddEmployee(name, salary);
                    break;

                default:
                    _console.DisplayDefault();
                    break;
            }
        } 
    }
}
