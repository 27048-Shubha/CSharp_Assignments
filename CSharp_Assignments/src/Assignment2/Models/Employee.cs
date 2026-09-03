namespace Assignment2.Models
{
    /// <summary>
    /// Abstract class of Employee containing name, salary and _bonus calculation.
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="name">Name of the employee.</param>
        /// <param name="salary">Salary of the employee.</param>
        internal Employee(string name, decimal salary)
        {
            this.Name = name;
            this.Salary = salary;
        }

        /// <summary>
        /// Gets or Sets name of the employee.
        /// </summary>
        /// <value>The name of the employee. </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets salary of the employee.
        /// </summary>
        /// <value>The calculated bonus of the employee.</value>
        public decimal Salary { get; set; }

        /// <summary>
        /// Calculates the bonus amount for the employee based on the employee type and its bonus calculation rules.
        /// </summary>
        /// <returns> The bonus amount applicable to the employee.  </returns>
        public abstract decimal CalculateBonus();

        /// <summary>
        /// Retrieves name, salary and bonus fo the employee.
        /// </summary>
        /// <param name="bonus">Bonus of the employee.</param>
        /// <returns>The name, salary and bonus of the employee.</returns>
        public string PrintDetails(decimal bonus)
        {
            return $"Name: {this.Name}\nSalary: {this.Salary}\n Bonus: {bonus}";
        }
    }
}