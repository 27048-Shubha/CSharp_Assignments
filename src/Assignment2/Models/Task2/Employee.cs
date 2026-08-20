namespace Assignment2.Models.Task2
{
    /// <summary>
    /// Abstract class of Employee containing name, _salary and _bonus calculation.
    /// </summary>
    public abstract class Employee
    {
        private string? _name;
        private decimal _salary;

        /// <summary>
        /// Gets or Sets name of the employee.
        /// </summary>
        /// <value>The name of the employee. </value>
        public string? Name
        {
            get { return this._name; }
            set { this._name = value ?? "Name not defined"; }
        }

        /// <summary>
        /// Gets or sets _salary of the employee.
        /// </summary>
        /// <value>The calculated _bonus of the employee.</value>
        public decimal Salary
        {
            get { return this._salary; }
            set { this._salary = value; }
        }

        /// <summary>
        /// Abstract method to calculate _bonus.
        /// </summary>
        /// <returns>The _bonus of the employee.</returns>
        public abstract decimal CalculateBonus();

        /// <summary>
        /// Retrieves name and _salary fo the employee.
        /// </summary>
        /// <returns>The name and _salary of the employee.</returns>
        public string PrintDetails()
        {
            return $"Name: {this.Name}\nSalary: {this.Salary}";
        }
    }
}