using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debugging
{
    /// <summary>
    /// Hold abstract methods for calculator operations.
    /// </summary>
    public interface IMathUtils
    {
        /// <summary>
        /// Adds two numbers.
        /// </summary>
        /// <param name="number1">User input for number 1.</param>
        /// <param name="number2">User input for number 2.</param>
        /// <returns>Sum of passed inputs.</returns>
        public int Add(int number1, int number2);

        /// <summary>
        /// Subtracts two numbers.
        /// </summary>
        /// <param name="number1">User input for number 1.</param>
        /// <param name="number2">User input for number 2.</param>
        /// <returns>Difference of passed inputs.</returns>
        public int Subtract(int number1, int number2);

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="number1">User input for number 1.</param>
        /// <param name="number2">User input for number 2.</param>
        /// <returns>Multiplication result of passed inputs.</returns>
        public int Multiply(int number1, int number2);

        /// <summary>
        /// Divides two numbers.
        /// </summary>
        /// <param name="number1">User input for number 1.</param>
        /// <param name="number2">User input for number 2.</param>
        /// <returns>Division result of passed inputs.</returns>
        public int Divide(int number1, int number2);
    }
}
