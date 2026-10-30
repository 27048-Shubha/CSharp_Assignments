namespace ReflectionTasks
{
    using Assignment17_Reflections.Task1;
    using Assignment17_Reflections.Task2;
    using Assignment17_Reflections.Task3;
    using Assignment17_Reflections.Task4;
    using Assignment17_Reflections.Task5;
    using Assignment17_Reflections.Task6;
    using Assignment17_Reflections.Task7;
    using Enums.TaskMenu;

    /// <summary>
    /// Entry point of application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point method for the application
        /// </summary>
        public static void Main()
        {
            while (true)
            {
                DisplayMenu();

                Console.Write("\nEnter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Kindly enter valid inputs only.");
                    continue;
                }

                TaskMenu taskChoice = (TaskMenu)choice;

                switch (taskChoice)
                {
                    case TaskMenu.Task1:
                        new Task1().RunTask();
                        break;

                    case TaskMenu.Task2:
                        new Task2().RunTask();
                        break;

                    case TaskMenu.Task3:
                        new Task3().RunTask();
                        break;

                    case TaskMenu.Task4:
                        new Task4().RunTask();
                        break;

                    case TaskMenu.Task5:
                        new Task5().RunTask();
                        break;

                    case TaskMenu.Task6:
                        new Task6().RunTask();
                        break;

                    case TaskMenu.Task7:
                        new Task7().RunTask();
                        break;

                    case TaskMenu.Quit:
                        Console.WriteLine("Exiting application...");
                        return;

                    default:
                        Console.WriteLine("Kindly enter valid inputs only.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("==================================");
            Console.WriteLine("      Reflection API Tasks");
            Console.WriteLine("==================================");
            Console.WriteLine("1. Inspect Assembly Metadata");
            Console.WriteLine("2. Dynamic Object Inspector");
            Console.WriteLine("3. Dynamic Method Invoker");
            Console.WriteLine("4. Dynamic Type Builder");
            Console.WriteLine("5. Plugin System");
            Console.WriteLine("6. Mocking Framework");
            Console.WriteLine("7. Serialization API");
            Console.WriteLine("0. Quit");
            Console.WriteLine("==================================");
        }
    }
}