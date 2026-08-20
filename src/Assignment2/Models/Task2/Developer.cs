namespace Assignment2.Models.Task2
{
    /// <summary>
    /// Handles _bonus calculation of the Developer inherited from the Employee.
    /// </summary>
    public class Developer : Employee
    {
        private decimal _bonus;

        /// <summary>
        /// Gets or sets _bonus value of the developer.
        /// </summary>
        /// <value> The _bonus _salary of the developer. </value>
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
        /// Calculates _bonus of the developer.
        /// </summary>
        /// <returns> The calculted _bonus of the developer. </returns>
        public override decimal CalculateBonus()
        {
            this.Bonus = this.Salary * 0.10m;
            return this.Bonus;
        }

        /// <summary>
        /// Displays the details and the _bonus of the developer.
        /// </summary>
        /// <returns> The details of the developer. </returns>
        public new string PrintDetails()
        {
            return $"{base.PrintDetails()}\nBonus: {this.CalculateBonus()}";
        }
    }
}