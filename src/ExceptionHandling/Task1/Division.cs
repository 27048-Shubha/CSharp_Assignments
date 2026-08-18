namespace ExceptionHandling.Task1
{
    using System;

    /// <summary>
    /// Manages division operation.
    /// </summary>
    public class Division
    {
        /// <summary>
        /// Divides and prints result else exception is thrown and handled.
        /// </summary>
        /// <param name="dividend">Numerator.</param>
        /// <param name="divisor">Denominator.</param>
        public void Divide(int dividend, int divisor)
        {
            bool status = true;
            try
            {
                Console.WriteLine($"Division result of {dividend} / {divisor} = {dividend / divisor}");
            }
            catch (DivideByZeroException exception)
            {
                status = false;
                Console.WriteLine($"Divisor should not be zero\n{exception.Message}");
            }
            finally
            {
                Console.WriteLine($"Operation status: {(status ? "Success" : "Failed")}");
            }
        }

        /// <summary>
        /// Gets user input and calls division operation.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Enter number1: ");
            int number1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number2: ");
            int number2 = int.Parse(Console.ReadLine());

            this.Divide(number1, number2);
        }
    }
}