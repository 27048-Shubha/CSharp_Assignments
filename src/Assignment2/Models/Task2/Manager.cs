namespace Assignment2.Models.Task2
{
    /// <summary>
    /// Handles _bonus calculation of the Manager inherited from the Employee.
    /// </summary>
    public class Manager : Employee
    {
        private decimal _bonus;

        /// <summary>
        /// Gets or sets _bonus value of the manager.
        /// </summary>
        /// <value> The _bonus _salary of the manager. </value>
        public decimal Bonus
        {
            get
            {
                return this._bonus;
            }

            set
            {
                this._bonus = value;
            }
        }

        /// <summary>
        /// Calculates _bonus of the manager.
        /// </summary>
        /// <returns> The calculted _bonus of the manager. </returns>
        public override decimal CalculateBonus()
        {
            this.Bonus = this.Salary * 0.20m;
            return this.Bonus;
        }

        /// <summary>
        /// Displays the details and the _bonus of the manager.
        /// </summary>
        /// <returns> The details of the manager. </returns>
        public new string PrintDetails()
        {
            return $"{base.PrintDetails()}\nBonus: {this.CalculateBonus()}";
        }
    }
}