namespace Assignments
{
    using Assignment16_AdvancedCSharp.Tasks;

    /// <summary>
    /// Manages entry point of exectuion of the application.
    /// </summary>
    public class Program
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

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            RunTask1();
                            break;
                        case 2:
                            RunTask2();
                            break;
                        case 3:
                            RunTask3();
                            break;
                        case 4:
                            RunTask4();
                            break;
                        case 5:
                            RunTask5();
                            break;
                        case 6:
                            RunTask6();
                            break;
                        case 7:
                            RunTask7();
                            break;
                        case 8:
                            Console.WriteLine("Press any key to quit application");
                            Console.ReadKey();
                            return;
                        default:
                            Console.WriteLine("Kindly enter valid inputs (1 to 7)");
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
            Task1_Notifier task1 = new ();
            task1.Run();
        }

        private static void RunTask2()
        {
            Task2_TypeSimulation simulator = new Task2_TypeSimulation();
            simulator.SimulateVarUsage();
            simulator.SimulateDynamicUsage();
        }

        private static void RunTask3()
        {
            Task3_AnonymousMethods anonymousMethods = new Task3_AnonymousMethods();
            Console.WriteLine("Before sorting:");
            anonymousMethods.DisplayArray();

            anonymousMethods.SortUsingAnonymousMethod();
            Console.WriteLine("\nAfter sorting (Using anonymous method):");
            anonymousMethods.DisplayArray();

            anonymousMethods.ResetArray();

            anonymousMethods.SortUsingBuiltInMethod();
            Console.WriteLine("\nAfter sorting (Using Built-in method):");
            anonymousMethods.DisplayArray();
        }

        private static void RunTask4()
        {
            Task4_Lambda task4 = new Task4_Lambda();
            task4.Run();
        }

        private static void RunTask5()
        {
            Task5_DelegatesForSorting task5 = new ();
            task5.Run();
        }

        private static void RunTask6()
        {
            Task6_Records task6 = new Task6_Records();
            task6.Run();
        }

        private static void RunTask7()
        {
            Task7_AdvancedPatternMatching task7 = new Task7_AdvancedPatternMatching();
            task7.Run();
        }
    }
}