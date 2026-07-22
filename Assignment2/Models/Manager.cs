namespace Assignment2.Models
{
    public class Manager: Employee
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
        public new void PrintBonus()
        {
            base.PrintBonus();
      
        }

    }
}
