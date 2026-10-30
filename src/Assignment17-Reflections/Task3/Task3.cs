namespace Assignment17_Reflections.Task3
{
    using System.Reflection;
    using Assignment17_Reflections.Utilities;

    /// <summary>
    /// Manages dynamic method invoker (task 3)
    /// </summary>
    public class Task3
    {
        /// <summary>
        /// Executes the workflow of the task 3.
        /// </summary>
        public void RunTask()
        {
            Student student = new Student("Shubha", 20);

            Console.WriteLine(new string('=', 50));
            Console.WriteLine("DYNAMIC METHOD INVOKER");
            Console.WriteLine(new string('=', 50));

            Console.WriteLine($"Object Type : {student.GetType().Name}");
            Console.WriteLine($"Student Name: Shubha");
            Console.WriteLine($"Student Age : 20");

            Console.WriteLine(new string('-', 50));
            this.InvokeMethod(student, "DisplayName");

            Console.WriteLine(new string('-', 50));
            this.InvokeMethod(student, "DisplayAge");

            Console.WriteLine(new string('-', 50));
            this.InvokeMethod(student, "DisplayRollNumber");

            Console.WriteLine(new string('=', 50));
        }

        private void InvokeMethod(object obj, string methodName)
        {
            Type type = obj.GetType();
            MethodInfo? method = type.GetMethod(methodName);

            if (method == null)
            {
                Console.WriteLine($"[ERROR] Method '{methodName}' not found.");
                return;
            }

            Console.WriteLine($"[INVOKING] {methodName}");
            method.Invoke(obj, null);
            Console.WriteLine($"[SUCCESS] Method '{methodName}' executed.");
        }
    }
}