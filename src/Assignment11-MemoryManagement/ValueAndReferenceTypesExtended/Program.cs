namespace Assignments
{
    internal class Program
    {
        public static void CreateArray()
        {
            Console.WriteLine("Running CreateArray()...");

            int[] array = new int[10_000_000];

            for (int i = 0; i < 10_000_000; i++)
            {
                array[i] = i;
            }

            Console.WriteLine($"Array Length: {array.Length}");
        }

        public static void Calculate()
        {
            Console.WriteLine("Running Calculate()...");

            int number1 = 10;
            int number2 = 10;
            int number3 = 10;
            int number4 = 10;
            int number5 = 10;
            int number6 = 10;
            int number7 = 10;
            int number8 = 10;
            int number9 = 10;
            int number10 = 10;

            int result = number1 + number2 + number3 + number4 + number5 + number6 + number7 + number8 + number9 + number10;

            Console.WriteLine($"Result: {result}");
            Console.ReadLine();
        }

        public static void Main(string[] args)
        {
            Program.CreateArray();
            Program.Calculate();
        }
    }
}