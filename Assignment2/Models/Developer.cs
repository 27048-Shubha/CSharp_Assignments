namespace Assignment2.Models
{
    public class Developer : Employee
    {
        private int _bonus;
        public int Bonus
        {
            get;
            set
            {
                _bonus = value;
            }
        }
        public new int CalculateBonus()
        {
            return base.Salary * 100;
        }
    }
}
