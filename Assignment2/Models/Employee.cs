namespace Assignment2.Models
{
    abstract class Employee
    {
        private string _name;
        private string _salary;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Salary
        {
            get { return _salary; }
        }
        public abstract int CalculateBonus();

    }
}
