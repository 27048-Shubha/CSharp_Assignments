namespace Assignment16_AdvancedCSharp
{
    using Assignment16_AdvancedCSharp.Models.Enums;
    using Assignment16_AdvancedCSharp.Tasks;

    /// <summary>
    /// Manages entry point of exectuion of the application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Entry point of the execution.
        /// </summary>
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("=================================");
                Console.WriteLine(" Assignment 16 - Advanced C#");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Task1 - Notifier");
                Console.WriteLine("2. Task2 - Type Simulation");
                Console.WriteLine("3. Task3 - Anonymous Methods");
                Console.WriteLine("4. Task4 - Lambda Expressions");
                Console.WriteLine("5. Task5 - Delegates For Sorting");
                Console.WriteLine("6. Task6 - Records");
                Console.WriteLine("7. Task7 - Advanced Pattern Matching");
                Console.WriteLine("8. Quit");
                Console.WriteLine("=================================");

                Console.WriteLine("Enter task number:");

                if (Enum.TryParse<Menu>(Console.ReadLine(), out Menu choice))
                {
                    switch (choice)
                    {
                        case Menu.Task1:
                            RunTask1();
                            break;
                        case Menu.Task2:
                            RunTask2();
                            break;
                        case Menu.Task3:
                            RunTask3();
                            break;
                        case Menu.Task4:
                            RunTask4();
                            break;
                        case Menu.Task5:
                            RunTask5();
                            break;
                        case Menu.Task6:
                            RunTask6();
                            break;
                        case Menu.Task7:
                            RunTask7();
                            break;
                        case Menu.Task8:
                            Console.WriteLine("Quitting application...");
                            return;
                        default:
                            Console.WriteLine("Kindly enter valid inputs (1 to 8)");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Kindly enter valid inputs (1 to 7)");
                }

                Console.WriteLine("\nPress any key to continue");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void RunTask1()
        {
            Task1Notifier task1 = new ();
            task1.Run();
        }

        private static void RunTask2()
        {
            Task2TypeSimulation simulator = new Task2TypeSimulation();
            simulator.Run();
        }

        private static void RunTask3()
        {
            Task3AnonymousMethods anonymousMethods = new Task3AnonymousMethods();

            Console.WriteLine("Sorting using anonymous method:");
            anonymousMethods.SortUsingAnonymousMethod();

            Console.WriteLine("\nSorting using built-in method:");
            anonymousMethods.SortUsingBuiltInMethod();
        }

        private static void RunTask4()
        {
            Task4Lambda task4 = new Task4Lambda();
            task4.Run();
        }

        private static void RunTask5()
        {
            Task5DelegatesForSorting task5 = new ();
            task5.Run();
        }

        private static void RunTask6()
        {
            Task6Records task6 = new Task6Records();
            task6.Run();
        }

        private static void RunTask7()
        {
            Task7AdvancedPatternMatching task7 = new Task7AdvancedPatternMatching();
            task7.Run();
        }
    }
}