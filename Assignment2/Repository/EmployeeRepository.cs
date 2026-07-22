using Assignment2.Models.Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Repository
{
    /// <summary>
    /// Handles Object Creation of Manager and Developer class
    /// </summary>
    public class EmployeeRepository
    {
        /// <summary>
        /// Creates object for Manager
        /// </summary>
        /// <param name="name"> Name of the Manager </param>
        /// <param name="salary"> Salary of the Manager </param>
        /// <returns> Details of Manager </returns>
        public string AddManager(string name, decimal salary)
        {
            Manager manager = new Manager();
            manager.Name = name;
            manager.Salary = salary;
            manager.CalculateBonus();
            return manager.PrintDetails();
        }

        /// <summary>
        /// Creates object for Developer
        /// </summary>
        /// <param name="name"> Name of the Developer </param>
        /// <param name="salary"> Salary of the Developer </param>
        /// <returns> Details of Developer </returns>
        public string AddDeveloper(string name, decimal salary)
        {
            Developer dev = new Developer();
            dev.Name = name;
            dev.Salary = salary;
            dev.CalculateBonus();
            return dev.PrintDetails();
        }
    }
}
