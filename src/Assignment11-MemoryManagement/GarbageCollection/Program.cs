namespace GarbageCollection.Program
{
    using GarbageCollection.Student;

    /// <summary>
    /// Manages entry flow of the demonstration.
    /// </summary>
    public class Program
    {
        private static List<Student>? _students = new List<Student>();
        private static string name = "Shubha";
        private static int age = 20;

        /// <summary>
        /// Creates objects of students class.
        /// </summary>
        public static void CreateObjects()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                if (_students != null)
                {
                    _students.Add(new Student(Program.name, Program.age));
                }
            }

            Console.WriteLine("Objects created.");
        }

        /// <summary>
        /// Triggers garbage collector.
        /// </summary>
        public static void TriggerGC()
        {
            _students = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("Garbage collection completed.");
            Console.ReadLine();
        }

        /// <summary>
        /// Entry point of the program.
        /// </summary>
        public static void Main()
        {
            Program.CreateObjects();
            Program.TriggerGC();
        }
    }
}