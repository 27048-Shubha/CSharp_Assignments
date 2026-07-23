namespace Assignment2.Models.Task2
{
    /// <summary>
    /// Handles Bonus Calculation of Developer interited from Employee.
    /// </summary>
    public class Developer : Employee
    {
        private decimal _bonus;

        /// <summary>
        /// Gets or Sets Bonus of the Developer.
        /// </summary>
        /// <value>Bonus salary of the Developer.</value>
        public decimal Bonus
        {
            get;
            set
            {
                _bonus = value;
            }
        }

        /// <summary>
        /// Calculates Bonus of the Developer.
        /// </summary>
        /// <returns> Calculated Bonus. </returns>
        public override decimal CalculateBonus()
        {
            Bonus = Salary * 0.10m;
            return Bonus;
        }

        /// <summary>
        /// Displays Bonus of the Developer after calling PrintDetails from Base Class.
        /// </summary>
        /// <returns> Details of the Developer. </returns>
        public new string PrintDetails()
        {
            return $"{base.PrintDetails()}Bonus: {CalculateBonus()}";
        }
    }
}