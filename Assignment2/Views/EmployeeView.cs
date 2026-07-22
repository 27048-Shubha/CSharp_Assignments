using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Views
{
    internal class EmployeeView
    {
        public void DisplayEmployeeMenu()
        {
            Console.WriteLine("Welcome to EMPLOYEE SYSTEM\n");
            Console.WriteLine("[D] to enter details of Developer\n");
            Console.WriteLine("[M] to enter details of Manager\n");
        }

        public char GetEmployeeMenuInput()
        {
            return Char.Parse(Console.ReadLine());
        }

        public string GetEmployeeName()
        {
            Console.WriteLine("Enter Name\n");
            return Console.ReadLine();
        }
        public decimal GetEmployeeSalary ()
        {
            Console.WriteLine("Enter Salary\n");
            return decimal.Parse(Console.ReadLine());
        }

        public void DisplayDefault()
        {
            Console.WriteLine("Kindly Enter valid inputs only");
        }
        public void DisplayMessage(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
