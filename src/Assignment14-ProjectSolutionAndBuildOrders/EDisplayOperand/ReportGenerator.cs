namespace Assignment14_E
{
    using Assignment14_D;

    /// <summary>
    /// Manages report generation operations.
    /// </summary>
    public class ReportGenerator
    {
        /// <summary>
        /// Displays information about operands.
        /// </summary>
        /// <param name="operand1">An integer representing operand 1</param>
        /// <param name="operand2">An integer representing operand 2</param>
        public void GenerateOperandReport(int operand1, int operand2)
        {
            ConsoleHelper.WriteToConsole($"==========OPERAND DETAILS============");
            ConsoleHelper.WriteToConsole($"Operand 1: {operand1}");
            ConsoleHelper.WriteToConsole($"Operand 2: {operand2}");
        }
    }
}
