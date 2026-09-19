namespace Assignments
{
    using Assignment16_AdvancedCSharp.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            //Task4();
            Task5();
        }

        public static void Task1()
        {
            Task1_Notifier notifer = new Task1_Notifier();
            notifer.OnAction += PrintToConsole;
            notifer.InvokeEvent();
        }

        public static void Task2()
        {
            Task3_TypeSimulation simulator = new Task3_TypeSimulation();
            simulator.SimulateVarUsage();
            simulator.SimulateDynamicUsage();
        }

        public static void Task3()
        {
            Task2_AnonymousMethods anonymousMethods = new Task2_AnonymousMethods();
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

        public static void Task4()
        {
            Task4_Lambda task4 = new Task4_Lambda();
            task4.Run();
        }

        public static void Task5()
        {
            Task5_DelegatesForSorting task5 = new ();
            task5.Run();
        }

        public static void PrintToConsole()
        {
            Console.WriteLine("Message from PrintToConsole!");
        }
    }
}