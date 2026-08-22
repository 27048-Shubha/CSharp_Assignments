namespace Assignment2.Models
{
    /// <summary>
    /// Abstract class of Employee containing name, salary and _bonus calculation.
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Gets or Sets name of the employee.
        /// </summary>
        /// <value>The name of the employee. </value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets salary of the employee.
        /// </summary>
        /// <value>The calculated bonus of the employee.</value>
        public decimal Salary { get; set; }

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