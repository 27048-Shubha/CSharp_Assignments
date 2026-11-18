namespace MemoryOptimization
{
    using System.Diagnostics;
    using Assignment12_MemoryOptimization;

    /// <summary>
    /// Manages main flow of the project.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of execution.
        /// </summary>
        public static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            long before = GC.GetTotalMemory(true);
            Console.WriteLine("Running unoptimized code...");
            stopwatch.Start();
            MemoryEaterUnoptimized unOptimizedMemoryHandler = new ();
            unOptimizedMemoryHandler.Allocate();
            stopwatch.Stop();
            long after = GC.GetTotalMemory(true);

            long unoptimizedTime = stopwatch.ElapsedMilliseconds;
            long unoptimizedMemoryUsage = after - before;

            Console.WriteLine($"Time taken by unoptimized code: {unoptimizedTime} milliseconds");
            Console.WriteLine($"Memory used by unoptimized code: {unoptimizedMemoryUsage} bytes");

            Console.WriteLine("======================================================");
            before = GC.GetTotalMemory(true);
            stopwatch.Restart();
            MemoryEaterOptimized optimizedMemoryHandler = new ();
            optimizedMemoryHandler.Allocate();
            stopwatch.Stop();
            after = GC.GetTotalMemory(true);

            long optimizedTime = stopwatch.ElapsedMilliseconds;
            long optimizedMemoryUsage = after - before;

            Console.WriteLine($"Time taken by unoptimized code: {optimizedTime} milliseconds");
            Console.WriteLine($"Memory used by unoptimized code: {optimizedMemoryUsage} bytes");

            Console.WriteLine("======================================================");

            Console.WriteLine($"Time consumption difference: {unoptimizedTime - optimizedTime} milliseconds");
            Console.WriteLine($"Memory usage difference: {unoptimizedMemoryUsage - optimizedMemoryUsage} bytes");

            Console.WriteLine("\n[Press any key to end the program]");
            Console.ReadKey();
        }
    }
}