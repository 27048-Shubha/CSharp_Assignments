namespace GarbageCollection.Program
{
    using GarbageCollection.Student;

    /// <summary>
    /// Manages entry flow of the demonstration.
    /// </summary>
    public class Program
    {
        private const int ObjectCount = 1_000_000;

        /// <summary>
        /// Creates objects of students class.
        /// </summary>
        public static void CreateObjects()
        {
            List<Student>? students = new List<Student>();

            for (int i = 0; i < ObjectCount; i++)
            {
                students.Add(new Student("Shubha", 20));
            }

            Console.WriteLine("Objects created.");
        }

        /// <summary>
        /// Triggers garbage collector.
        /// </summary>
        public static void TriggerGC()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("Garbage collection completed.");

            Console.WriteLine("=========================================");
            Console.WriteLine("PRESS ANY KEY TO CONTINUE.");
            Console.ReadLine();
        }

        /// <summary>
        /// Entry point of the program.
        /// </summary>
        public static void Main()
        {
            long memoryBeforeCreation = GC.GetTotalMemory(forceFullCollection: true);
            Console.WriteLine($"Memory size before creation: {memoryBeforeCreation}");
            Program.CreateObjects();

            long memoryAfterCreation = GC.GetTotalMemory(forceFullCollection: false);
            Console.WriteLine($"Memory size after creation: {memoryAfterCreation}");
            Program.TriggerGC();

            long memoryAfterGC = GC.GetTotalMemory(forceFullCollection: true);
            Console.WriteLine($"Memory size after garbage collection: {memoryAfterGC}");
        }
    }
}