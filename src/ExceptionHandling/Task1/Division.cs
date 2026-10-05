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
            int number1, number2;

            while (true)
            {
                Console.WriteLine("Enter number1: ");
                if (int.TryParse(Console.ReadLine(), out number1))
                {
                    break;
                }
                Console.WriteLine("Invalid input! Enter only integers");
            }

            Console.WriteLine("Enter number2: ");
            while (true)
            {
                Console.WriteLine("Enter number2: ");
                if (int.TryParse(Console.ReadLine(), out number2))
                {
                    break;
                }
                Console.WriteLine("Invalid input! Enter only integers");
            }

            this.Divide(number1, number2);
        }
    }
}