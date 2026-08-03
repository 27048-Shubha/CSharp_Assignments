namespace Assignment2.Models.Task2
{
    /// <summary>
    /// Abstract class of Employee containing name, salary and bonus calculation.
    /// </summary>
    public abstract class Employee
    {
        private string? name;
        private decimal salary;

        /// <summary>
        /// Gets or Sets name of the employee.
        /// </summary>
        /// <value>The name of the employee. </value>
        public string? Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <summary>
        /// Gets or sets salary of the employee.
        /// </summary>
        /// <value>The calculated bonus of the employee.</value>
        public decimal Salary
        {
            get { return this.salary; }
            set { this.salary = value; }
        }

        /// <summary>
        /// Abstract method to calculate bonus.
        /// </summary>
        /// <returns>The bonus of the employee.</returns>
        public abstract decimal CalculateBonus();

        /// <summary>
        /// Retrieves name and salary fo the employee.
        /// </summary>
        /// <returns>The name and salary of the employee.</returns>
        public string PrintDetails()
        {
            return $"Name: {this.Name}\nSalary: {this.Salary}";
        }
    }
}