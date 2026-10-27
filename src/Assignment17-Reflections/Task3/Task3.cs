using Assignment17_Reflections.Utilities;
using System.Reflection;

namespace Assignment17_Reflections.Task3
{
    public class Task3
    {
        public void InvokeMethod(object obj, string methodName)
        {
            Type type = obj.GetType();
            MethodInfo? method = type.GetMethod(methodName);

            if (method == null)
            {
                Console.WriteLine($"Method not found: {methodName}");
                return;
            }

            method.Invoke(obj, null);
        }

        public void RunTask()
        {
            Student student = new Student("Shubha", 20);

            this.InvokeMethod(student, "DisplayName");
            this.InvokeMethod(student, "DisplayAge");
            this.InvokeMethod(student, "DisplayRollNumber");
        }

    }
}
