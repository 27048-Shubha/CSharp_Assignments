namespace Assignment16_AdvancedCSharp.Tasks
{
    /// <summary>
    /// Demonstrates usage of anonymous methods.
    /// </summary>
    public class Task3AnonymousMethods
    {
        private static readonly int[] SourceNumbers =
        {
            1, 9, 2, 11, -3, 2, 12, 5, 6, 7,
        };

        /// <summary>
        /// Sorts the array using anonymous method.
        /// </summary>
        public void SortUsingAnonymousMethod()
        {
            int[] numbers = (int[])SourceNumbers.Clone();

            Console.WriteLine("Before sorting:");
            DisplayArray(numbers);

            Array.Sort(
                numbers,
                delegate(int first, int second)
                {
                    return first.CompareTo(second);
                });

            Console.WriteLine("\nAfter sorting (Using anonymous method):");
            DisplayArray(numbers);
        }

        /// <summary>
        /// Sorts the array using built-in method.
        /// </summary>
        public void SortUsingBuiltInMethod()
        {
            int[] numbers = (int[])SourceNumbers.Clone();

            Console.WriteLine("Before sorting:");
            DisplayArray(numbers);

            Array.Sort(numbers);

            Console.WriteLine("\nAfter sorting (Using built-in method):");
            DisplayArray(numbers);
        }

        /// <summary>
        /// Displays array to the console.
        /// </summary>
        /// <param name="numbers">Integer array of numbers</param>
        private static void DisplayArray(int[] numbers)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
