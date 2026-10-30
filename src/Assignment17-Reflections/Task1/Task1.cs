namespace Assignment17_Reflections.Task1
{
    using System.Reflection;

    /// <summary>
    /// Manages inspection fo assembly metadata.(task 1)
    /// </summary>
    public class Task1
    {
        /// <summary>
        /// Executes the workflow of the task 1.
        /// </summary>
        public void RunTask()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("INSPECT ASSEMBLY METADATA");
            Console.WriteLine(new string('=', 50));

            Assembly assembly = Assembly.GetExecutingAssembly();

            IEnumerable<Type> types = assembly.GetTypes()
                                .Where(t => t.Namespace != null)
                                .Where(t => t.Namespace.StartsWith("Assignment17_Reflections"))
                                .Where(t => !t.IsNested)
                                .Where(t => !t.Name.Contains("<>"));

            Console.WriteLine($"Assembly name: {assembly.FullName}");

            foreach (Type type in types)
            {
                Console.WriteLine(new string('=', 50));
                Console.WriteLine($"Type: {type.FullName}");

                Console.WriteLine(new string('=', 50));
                Console.WriteLine("Methods:");

                MethodInfo[] methods = type.GetMethods(
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.Static |
                    BindingFlags.DeclaredOnly);

                if (methods.Any())
                {
                    foreach (MethodInfo method in methods)
                    {
                        Console.WriteLine(method.Name);
                    }
                }
                else
                {
                    Console.WriteLine("None");
                }

                Console.WriteLine();

                Console.WriteLine("Properties:");

                PropertyInfo[] properties = type.GetProperties(
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.Static |
                    BindingFlags.DeclaredOnly);

                if (properties.Any())
                {
                    foreach (PropertyInfo property in properties)
                    {
                        Console.WriteLine(property.Name);
                    }
                }
                else
                {
                    Console.WriteLine("None");
                }

                Console.WriteLine();

                Console.WriteLine("Fields:");

                FieldInfo[] fields = type.GetFields(
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Instance |
                    BindingFlags.Static |
                    BindingFlags.DeclaredOnly);

                if (fields.Any())
                {
                    foreach (FieldInfo field in fields)
                    {
                        Console.WriteLine(field.Name);
                    }
                }
                else
                {
                    Console.WriteLine("None");
                }

                Console.WriteLine();

                Console.WriteLine("Events:");

                EventInfo[] events = type.GetEvents(
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.Static |
                    BindingFlags.DeclaredOnly);

                if (events.Any())
                {
                    foreach (EventInfo eventInfo in events)
                    {
                        Console.WriteLine(eventInfo.Name);
                    }
                }
                else
                {
                    Console.WriteLine("None");
                }

                Console.WriteLine(new string('=', 50));
            }
        }
    }
}
