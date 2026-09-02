namespace LINQ.Helpers
{
    using System.Diagnostics;

    /// <summary>
    /// Manages timer operations.
    /// </summary>
    public static class Timer
    {
        /// <summary>
        /// Starts a stopwatch used to measure query execution time.
        /// </summary>
        /// <returns> A running <see cref="Stopwatch"/> instance.</returns>
        public static Stopwatch StartTimer()
        {
            return Stopwatch.StartNew();
        }

        /// <summary>
        /// Stops stop watch and prints execution time.
        /// </summary>
        /// <param name="stopwatch">Running stopwatch instance.</param>
        public static void PrintExecutionTime(Stopwatch stopwatch)
        {
            stopwatch.Stop();

            Console.WriteLine(
                $"Execution Time: {stopwatch.Elapsed.TotalMilliseconds:F4} ms\n");
        }
    }
}