namespace Debugging
{
    /// <summary>
    /// Implements methods for calculator operations.
    /// </summary>
    public class MathUtils : IMathUtils
    {
        /// <summary>
        /// Adds two numbers.
        /// </summary>
        /// <param name="number1">User input for number 1.</param>
        /// <param name="number2">User input for number 2.</param>
        /// <returns>Sum of passed inputs.</returns>
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// Subtracts two numbers.
        /// </summary>
        /// <param name="number1">User input for number 1.</param>
        /// <param name="number2">User input for number 2.</param>
        /// <returns>Difference of passed inputs.</returns>
        public int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="number1">User input for number 1.</param>
        /// <param name="number2">User input for number 2.</param>
        /// <returns>Multiplication result of passed inputs.</returns>
        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        /// <summary>
        /// Divides two numbers.
        /// </summary>
        /// <param name="number1">User input for number 1.</param>
        /// <param name="number2">User input for number 2.</param>
        /// <returns>Division result of passed inputs.</returns>
        public int Divide(int number1, int number2)
        {
            if (number2 == 0)
            {
                Console.WriteLine("Divisor is zero! Invalid operation. Returning zero...");
                return 0;
            }

            return number1 / number2;
        }
    }
}
