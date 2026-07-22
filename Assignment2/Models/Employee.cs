namespace Assignment2.Models
{
    /// <summary>
    /// Abstract class of Employee containing Name, Salary and calculates Bonus.
    /// </summary>
    public abstract class Employee
    {
        private string _name;
        private decimal _salary;

        /// <summary>
        /// Gets or Sets Name of the Employee.
        /// </summary>
        /// <value>Name of the Employee</value>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets Salary of the Employee.
        /// </summary>
        /// <value>Calculated Bonus of the Employee.</value>
        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        /// <summary>
        /// Abstract Method to Calculate Bonus.
        /// </summary>
        /// <returns> Bonus of the Employee</returns>
        public abstract decimal CalculateBonus();

        /// <summary>
        /// Retrieves Name and Salary fo the Employee.
        /// </summary>
        /// <returns>Name and Salary of the Employee</returns>
        public string PrintDetails()
        {
            return $"Name: {Name}\nSalary: {Salary}";
        }
    }
}
