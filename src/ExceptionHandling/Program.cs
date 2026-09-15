namespace Assignments
{
    using ExceptionHandling.Task1;
    using ExceptionHandling.Task2;
    using ExceptionHandling.Task3;
    using ExceptionHandling.Task4;
    using ExceptionHandling.Task5;

    /// <summary>
    /// Manages Exception handling application tasks.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of project execution
        /// </summary>
        public static void Main()
        {
            string? choice;
            do
            {
                Console.Clear();
                Console.WriteLine("------------------ MAIN MENU --------------------");
                Console.WriteLine("Choose one option from the below:");
                Console.WriteLine("1. Task 1 - Try-Catch-Finally block simulation\n" +
                    "2. Task 2 - Throwing and Catching exceptions\n" +
                    "3. Task 3 - Custom exception class for invalid input\n" +
                    "4. Task 4 - Global unhandled exception via AppDomain event\n" +
                    "5. Task 5 - Using and global exception handler\n" +
                    "6. Exit application\n");

                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Division task1 = new Division();
                        task1.Run();
                        break;
                    case "2":
                        ExceptionHandling.Task2.IntegerArray task2 = new ExceptionHandling.Task2.IntegerArray();
                        task2.Run();
                        break;
                    case "3":
                        ExceptionHandling.Task3.IntegerArray task3 = new ExceptionHandling.Task3.IntegerArray();
                        task3.Run();
                        break;
                    case "4":
                        ExceptionHandling.Task4.ApplicationRunner.Run();
                        break;
                    case "5":
                        ExceptionHandling.Task5.ApplicationRunner.Run();
                        break;
                    case "6":
                        Console.WriteLine("Exiting application...");
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

                Console.WriteLine("Reloading MainMenu...");
                Thread.Sleep(1000);
            }
            while (choice != "6");
        }
    }
}