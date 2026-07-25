using Assignment2.Models.Task2;

namespace Assignment2.Models.Task2
{
    /// <summary>
    /// Handles Bonus Calculation of the Manager inherited from the Employee.
    /// </summary>
    public class Manager : Employee
    {
        private decimal _bonus;

        /// <summary>
        /// Gets or Sets Bonus value of the Manager
        /// </summary>
        /// <value> Bonus salary of the Manager </value>
        public decimal Bonus
        {
            get
            {
                return _bonus;
            }
            set
            {
                _bonus = value;
            }
        }

        /// <summary>
        /// Calculates Bonus of the Developer.
        /// </summary>
        /// <returns> Calculted Bonus. </returns>
        public override decimal CalculateBonus()
        {
            this.Bonus = base.Salary * 0.20m;
            return this.Bonus;
        }

        /// <summary>
        /// Displays Bonus of the Developer after calling PrintDetails from Base Class.
        /// </summary>
        /// <returns> Details of the Developer. </returns>
        public new string PrintDetails()
        {
            return $"{base.PrintDetails()} \nBonus: {this.CalculateBonus()}";
        }
    }
}