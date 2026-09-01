namespace Debugging
{
    public class MathUtils : IMathUtils
    {
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }
        public int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }
        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }
        public int Divide(int number1, int number2)
        {
            if(number2 == 0)
            {
                Console.WriteLine("Divisor is zero! Invalid operation. Returning zero...");
                return 0;
            }

            return number1 / number2;
        }
    }
}
