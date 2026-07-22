using Assignment2.Controllers;
using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program
    {
        EmployeeController employeeController = new EmployeeController();
        employeeController.InitializeEmpSystem();
    }
}
