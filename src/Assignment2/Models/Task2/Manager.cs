namespace Assignment2.Models.Task2
{
    /// <summary>
    /// Handles bonus calculation of the Manager inherited from the Employee.
    /// </summary>
    public class Manager : Employee
    {
        private decimal bonus;

        /// <summary>
        /// Gets or sets bonus value of the manager.
        /// </summary>
        /// <value> The bonus salary of the manager. </value>
        public decimal Bonus
        {
            get
            {
                return this.bonus;
            }

            set
            {
                this.bonus = value;
            }
        }

        /// <summary>
        /// Calculates bonus of the manager.
        /// </summary>
        /// <returns> The calculted bonus of the manager. </returns>
        public override decimal CalculateBonus()
        {
            this.Bonus = this.Salary * 0.20m;
            return this.Bonus;
        }

        /// <summary>
        /// Displays the details and the bonus of the manager.
        /// </summary>
        /// <returns> The details of the manager. </returns>
        public new string PrintDetails()
        {
            return $"{base.PrintDetails()}\nBonus: {this.CalculateBonus()}";
        }
    }
}