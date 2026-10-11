namespace Assignment15_FilesAndStream.Controller
{
    using Assignment15_FilesAndStream.Service;

    /// <summary>
    /// Manages log simulation.
    /// </summary>
    internal class LogController
    {
        /// <summary>
        /// Runs log tasks based on user choice.
        /// </summary>
        public static void Run()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\n===== Logger Simulation Menu =====");
                    Console.WriteLine("1. Simulate Logger Error (No Synchronization)");
                    Console.WriteLine("2. Simulate Efficient Logger");
                    Console.WriteLine("3. Simulate Logger Using Lock");
                    Console.WriteLine("4. Simulate Individual Log Files Per Thread");
                    Console.WriteLine("5. Back / Exit");
                    Console.Write("Enter your choice: ");

                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        Console.WriteLine("Invalid input.");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("1. Simulate Logger Error (No Synchronization) - May throw IOException when multiple threads access the same file concurrently.");
                            Thread.Sleep(2000);
                            SimulateLogError();
                            break;

                        case 2:
                            Console.WriteLine("2. Simulate Efficient Logger - Handles concurrent file access safely without exceptions.");
                            SimulateEfficientLogger();
                            break;

                        case 3:
                            SimulateLockLogger();
                            break;

                        case 4:
                            SimulateIndividualLogFile();
                            break;

                        case 5:
                            Console.WriteLine("Returning to Main Menu...");
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please enter a value between 1 and 5.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.GetType().FullName);
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void SimulateLogError()
        {
            Parallel.For(0, 5, i =>
            {
                Logger.LogError($"Accessing by: i = {i}\nThread: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            });
        }

        private static void SimulateEfficientLogger()
        {
            Parallel.For(0, 5, i =>
            {
                try
                {
                    Logger.LogErrorFree(
                        $"Accessing by: i = {i}\nThread: {Thread.CurrentThread.ManagedThreadId}");
                }
                catch (IOException ex)
                {
                    Console.WriteLine(
                        $"Expected file access exception: {ex.Message}");
                }
            });
        }

        private static void SimulateLockLogger()
        {
            Parallel.For(0, 5, i =>
            {
                Logger.LockLogger($"Accessing by: i = {i}\nThread: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            });
        }

        private static void SimulateIndividualLogFile()
        {
            Parallel.For(0, 5, i =>
            {
                Logger.IndividualLogger($"Accessing by: i = {i}\nThread: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}
