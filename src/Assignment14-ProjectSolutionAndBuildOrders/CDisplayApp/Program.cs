namespace Assignment14_C
{
    using Assignment14_B;
    using Assignment14_D;
    using Assignment14_E;

    /// <summary>
    /// Represents the entry point for Project C - Display App.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of project C that manages and displays result of calculation.
        /// </summary>
        public static void Main()
        {
            int operand1 = 10;
            int operand2 = 20;

            Calculator calculator = new ();
            ReportGenerator report = new ();

            report.GenerateOperandReport(operand1, operand2);

            ConsoleHelper.WriteToConsole($"\n==============RESULT================");
            ConsoleHelper.WriteToConsole($"Result of Addition: {calculator.Add(operand1, operand2)}");
            ConsoleHelper.WriteToConsole($"Result of Subtraction: {calculator.Subtract(operand1, operand2)}");
        }
    }
}