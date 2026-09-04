namespace Assignments
{
    internal class Program
    {
        private static List<Student> _students = new List<Student>();

        public static void CreateObjects()
        {
            for (int i=0; i<10_000_000; i++)
            {
                _students.Add(new Student
                {
                    Name = "Shubha",
                    Age = 20,
                });
            }

            Console.WriteLine("Objects created.");
        }

        public static void TriggerGC()
        {
            _students = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            Console.WriteLine("Garbage collection completed.");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Program.CreateObjects();
            Program.TriggerGC();
        }
    }

    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}