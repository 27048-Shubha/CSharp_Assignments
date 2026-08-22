namespace Assignment2.Models
{
    /// <summary>
    /// Handles bonus calculation of the Manager inherited from the Employee.
    /// </summary>
    public class Manager : Employee
    {
        /// <summary>
        /// Gets bonus value of the manager.
        /// </summary>
        /// <value> The bonus salary of the manager. </value>
        public decimal Bonus { get; } = 0.20m;

        /// <summary>
        /// Calculates bonus of the manager.
        /// </summary>
        /// <returns> The calculted bonus of the manager. </returns>
        public override decimal CalculateBonus()
        {
            return this.Salary * this.Bonus;
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