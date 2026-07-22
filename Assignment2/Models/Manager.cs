namespace Assignment2.Models
{
    public class Manager : Employee
    {
        private decimal _bonus;
        public decimal Bonus
        {
            get;
            set
            {
                _bonus = value;
            }
        }
        public override decimal CalculateBonus()
        {
            this.Bonus = base.Salary * 10;
            return this.Bonus;
        }
        public new string PrintDetails()
        {
            return $"{base.PrintDetails()}\nBonus: {this.CalculateBonus()}";

        }
    }
}
