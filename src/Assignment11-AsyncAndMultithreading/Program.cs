namespace Assignments
{
    using Assignment11_AsyncAndMultithreading.Task1;
    using Assignment11_AsyncAndMultithreading.Task2;
    using Assignment11_AsyncAndMultithreading.Task3;
    using Assignment11_AsyncAndMultithreading.Task4;
    using Assignment11_AsyncAndMultithreading.Task5;
    using Assignment11_AsyncAndMultithreading.Task6;
    using Assignment11_AsyncAndMultithreading.Task7;

    /// <summary>
    /// Manages entry point of the program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of execution.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. </returns>
        public static async Task Main()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("================================");
                Console.WriteLine(" Async & Multithreading Demonstration");
                Console.WriteLine("================================");
                Console.WriteLine("1. Understanding and Implementing Async/Await");
                Console.WriteLine("2. Task Parallel Library (TPL)");
                Console.WriteLine("3. Multi-Threading with Threads");
                Console.WriteLine("4. Multi-Layered Async/Await Operations");
                Console.WriteLine("5. Debugging and Fixing Deadlocks");
                Console.WriteLine("6. ConfigureAwait(false) Demonstration");
                Console.WriteLine("7. Async Void vs Async Task Exceptions");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine() ?? string.Empty;

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        await new ContentManager()
                            .Run();
                        break;

                    case "2":
                        new Task2_ArrayManipulator()
                            .Run();
                        break;

                    case "3":
                        new Task3_ArrayManipulator()
                            .Run();
                        break;

                    case "4":
                        await new MultiLayeredAsyncAwaitDemonstrator()
                            .Run();
                        break;

                    case "5":
                        await new DeadLockSimulator()
                            .Run();
                        break;

                    case "6":
                        await new ConfigureAwaitDemonstrator()
                            .Run();
                        break;

                    case "7":
                        await new ThreadExceptionDemonstrator()
                            .Run();
                        break;

                    case "8":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}