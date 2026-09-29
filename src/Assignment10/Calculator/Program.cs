namespace Calculator
{
    /// <summary>
    /// Handles main flow of the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Execution start of the application.
        /// </summary>
        public static void Main()
        {
            Program.Run();
        }

        /// <summary>
        /// Runs basic calculator operations.
        /// </summary>
        public static void Run()
        {
            MathUtils mathUtils = new MathUtils();

            try
            {
                int number1, number2;
                while (true)
                {
                    Console.WriteLine("Enter operand1: ");
                    if (int.TryParse(Console.ReadLine(), out number1))
                    {
                        break;
                    }

                    Console.WriteLine("Invalid input! Enter only integers");
                }

                while (true)
                {
                    Console.WriteLine("Enter operand2: ");
                    if (int.TryParse(Console.ReadLine(), out number2))
                    {
                        break;
                    }

                    Console.WriteLine("Invalid input! Enter only integers");
                }

                Console.WriteLine($"Addition of {number1} and {number2} results {mathUtils.Add(number1, number2)}");

                Console.WriteLine($"Subtraction of {number1} and {number2} results {mathUtils.Subtract(number1, number2)}");

                Console.WriteLine($"Multiplication of {number1} and {number2} results {mathUtils.Multiply(number1, number2)}");

                Console.WriteLine($"Division of {number1} and {number2} results {mathUtils.Divide(number1, number2)}");
            }
            catch (DivideByZeroException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                Console.WriteLine("Press any key to quit...");
                Console.ReadKey();
            }
        }
    }
}
