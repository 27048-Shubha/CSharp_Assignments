namespace Assignment2.Models
{
    /// <summary>
    /// Abstract class of Employee containing Name, Salary and calculates Bonus
    /// </summary>
    public abstract class Employee
    {
        private string _name;
        private decimal _salary;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public abstract decimal CalculateBonus();

        public string PrintDetails()
        {
            return $"Name: {Name}\nSalary: {Salary}";
        }

    }
}
