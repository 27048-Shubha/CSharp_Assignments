namespace Assignments
{
    /// <summary>
    /// Manages flow of demonstration.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Creates array of integers to represent heap memory creation.
        /// </summary>
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

        /// <summary>
        /// Performs calculation to represent stack memory creation.
        /// </summary>
        public static void Calculate()
        {
            Console.WriteLine("Running Calculate()...");

            Span<int> numbers = stackalloc int[1024];

            int result = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = 10;
                result += numbers[i];
            }

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Result: {result}");

            Console.WriteLine("=========================================");
            Console.WriteLine("PRESS ANY KEY TO CONTINUE.");
            Console.ReadLine();
        }

        /// <summary>
        /// Entry point of the program.
        /// </summary>
        public static void Main()
        {
            CreateArray();
            Calculate();
        }
    }
}