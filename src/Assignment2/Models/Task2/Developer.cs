namespace Assignment2.Models.Task2
{
    /// <summary>
    /// Handles bonus calculation of the Developer inherited from the Employee.
    /// </summary>
    public class Developer : Employee
    {
        private decimal bonus;

        /// <summary>
        /// Gets or sets bonus value of the developer.
        /// </summary>
        /// <value> The bonus salary of the developer. </value>
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
        /// Calculates bonus of the developer.
        /// </summary>
        /// <returns> The calculted bonus of the developer. </returns>
        public override decimal CalculateBonus()
        {
            this.Bonus = this.Salary * 0.10m;
            return this.Bonus;
        }

        /// <summary>
        /// Displays the details and the bonus of the developer.
        /// </summary>
        /// <returns> The details of the developer. </returns>
        public new string PrintDetails()
        {
            return $"{this.PrintDetails()}Bonus: {this.CalculateBonus()}";
        }
    }
}