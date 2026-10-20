namespace Assignment14_B
{
    /// <summary>
    /// Manages calculation operations.
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Adds two integers.
        /// </summary>
        /// <param name="operand1">An integer that represents operand 1</param>
        /// <param name="operand2">An integer that represents operand 2</param>
        /// <returns>Resultant of addition operation.</returns>
        public int Add(int operand1, int operand2)
        {
            return operand1 + operand2;
        }

        /// <summary>
        /// Subtracts two integers.
        /// </summary>
        /// <param name="operand1">An integer that represents operand 1</param>
        /// <param name="operand2">An integer that represents operand 2</param>
        /// <returns>Resultant of subtraction operation.</returns>
        public int Subtract(int operand1, int operand2)
        {
            return operand1 - operand2;
        }
    }
}