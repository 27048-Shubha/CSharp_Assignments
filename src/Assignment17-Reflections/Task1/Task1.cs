namespace Assignment17_Reflections.Task1
{
    using System.Reflection;
    public class Task1
    {
        public void RunTask()
        {
            string assemblyPath = Assembly.GetExecutingAssembly().Location;

            Assembly assembly = Assembly.LoadFile(assemblyPath);
            Console.WriteLine($"Assembly name: {assembly.FullName}");

            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                Console.WriteLine($"Type: {type.FullName}");

                Console.WriteLine("Methods:");
                foreach (MethodInfo method in type.GetMethods())
                {
                    Console.WriteLine($"{method.Name}");
                }

                Console.WriteLine("Properties:");
                foreach (PropertyInfo property in type.GetProperties())
                {
                    Console.WriteLine($"{property.Name}");
                }

                Console.WriteLine("Fields:");
                foreach (FieldInfo field in type.GetFields())
                {
                    Console.WriteLine($"{field.Name}");
                }

                Console.WriteLine("Events:");
                foreach (EventInfo eventInfo in type.GetEvents())
                {
                    Console.WriteLine($"{eventInfo.Name}");
                }
            }
        }
    }
}
