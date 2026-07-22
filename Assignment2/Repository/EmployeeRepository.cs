using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Repository
{
    class EmployeeRepository
    {
        public void AddDeveloper(string name, decimal salary)
        {
            Developer dev = new Developer();
            dev.Name = name;
            dev.Salary = salary;
            dev.CalculateBonus();
            dev.PrintDetails();
        }
    }
}
