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
            MathUtils utilHandler = new MathUtils();

            try
            {
                Console.WriteLine("Enter operand 1: ");
                int number1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter operand 2: ");
                int number2 = int.Parse(Console.ReadLine());

                Console.WriteLine($"Addition of {number1} and {number2} results {utilHandler.Add(number1, number2)}");

                Console.WriteLine($"Subtraction of {number1} and {number2} results {utilHandler.Subtract(number1, number2)}");

                Console.WriteLine($"Multiplication of {number1} and {number2} results {utilHandler.Multiply(number1, number2)}");

                Console.WriteLine($"Division of {number1} and {number2} results {utilHandler.Divide(number1, number2)}");
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.ReadKey();
        }
    }
}
