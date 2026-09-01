namespace Debugging
{
    internal class Program
    {
        static int num;
        static void Main(string[] args)
        {
            Program.Run();
        }

        static void Run()
        {
            MathUtils utilHandler = new MathUtils();

            Console.WriteLine("Enter operand 1: ");
            int number1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter operand 2: ");
            int number2 = int.Parse(Console.ReadLine());


            Console.WriteLine($"Addition of {number1} and {number2} results {utilHandler.Add(number1,number2)}");

            Console.WriteLine($"Subtraction of {number1} and {number2} results {utilHandler.Subtract(number1, number2)}");

            Console.WriteLine($"Multiplication of {number1} and {number2} results {utilHandler.Multiply(number1, number2)}");

            Console.WriteLine($"Division of {number1} and {number2} results {utilHandler.Divide(number1, number2)}");
        }
    }
}
