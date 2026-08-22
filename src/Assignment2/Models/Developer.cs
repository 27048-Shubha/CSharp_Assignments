namespace Assignment2.Models
{
    /// <summary>
    /// Handles bonus calculation of the Developer inherited from the Employee.
    /// </summary>
    public class Developer : Employee
    {
        /// <summary>
        /// Gets bonus value of the developer.
        /// </summary>
        /// <value> The bonus salary of the developer. </value>
        public decimal Bonus { get; } = 0.10m;

        /// <summary>
        /// Calculates bonus of the developer.
        /// </summary>
        /// <returns> The calculted bonus of the developer. </returns>
        public override decimal CalculateBonus()
        {
            return this.Salary * this.Bonus;
        }

        /// <summary>
        /// Displays the developer's _name, salary, and calculated bonus.
        /// </summary>
        /// <returns> The details of the developer. </returns>
        public new string PrintDetails()
        {
            return $"{base.PrintDetails()}\nBonus: {this.CalculateBonus()}";
        }
    }
}