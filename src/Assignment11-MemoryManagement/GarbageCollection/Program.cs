namespace Assignments
{
    /// <summary>
    /// Manages entry flow of the demonstration.
    /// </summary>
    public class Program
    {
        private static List<Student> _students = new List<Student>();

        /// <summary>
        /// Creates objects of students class.
        /// </summary>
        public static void CreateObjects()
        {
            for (int i = 0; i < 10_000_000; i++)
            {
                _students.Add(new Student
                {
                    Name = "Shubha",
                    Age = 20,
                });
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

    /// <summary>
    /// Represents student details.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Name of the student.
        /// </summary>
        /// <value>Student name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Age of the student.
        /// </summary>
        /// <value>Student age.</value>
        public int Age { get; set; }
    }
}