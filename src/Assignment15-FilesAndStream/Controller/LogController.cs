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

                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            SimulateLogError();
                            break;

                        case 2:
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
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
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
                Logger.LogErrorFree($"Accessing by: i = {i}\nThread: {System.Threading.Thread.CurrentThread.ManagedThreadId}");
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
