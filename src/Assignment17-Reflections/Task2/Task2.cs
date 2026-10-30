namespace Assignment17_Reflections.Task2
{
    using System.Reflection;
    using Assignment17_Reflections.Utilities;

    /// <summary>
    /// Manages dynamic object inspection (task 2)
    /// </summary>
    public class Task2
    {
        /// <summary>
        /// Executes the workflow of the task 2.
        /// </summary>
        public void RunTask()
        {
            Student student = new Student("Shubha", 20);

            Console.WriteLine(new string('=', 50));
            Console.WriteLine("DYNAMIC OBJECT INSPECTOR");
            Console.WriteLine(new string('=', 50));

            Console.WriteLine("\n[BEFORE MODIFICATION]");
            this.DisplayProperties(student);

            Console.Write("\n[UPDATING NAME PROPERTY] ");
            this.SetProperty(student, "Name", "Shree");

            Console.Write("\n[UPDATING AGE PROPERTY] ");
            this.SetProperty(student, "Age", 22);

            Console.WriteLine("\n[AFTER MODIFICATION]");
            this.DisplayProperties(student);

            Console.WriteLine(new string('=', 50));
        }

        private void DisplayProperties(object obj)
        {
            Type type = obj.GetType();

            Console.WriteLine($"Type: {type.Name}");

            Console.WriteLine($"Properties: ");

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object? value = property.GetValue(obj);
                Console.WriteLine($"{property.Name} = {value}");
            }
        }

        private void SetProperty(object obj, string propertyName, object? newValue)
        {
            Type type = obj.GetType();

            PropertyInfo property = type.GetProperty(propertyName);

            if (property == null)
            {
                Console.WriteLine($"Property not found: {propertyName}");
                return;
            }

            if (!property.CanWrite)
            {
                Console.WriteLine("Property cannot be modified.");
                return;
            }

            try
            {
                object? convertedValue = newValue;
                if (newValue != null && property.PropertyType != newValue.GetType())
                {
                    convertedValue = Convert.ChangeType(newValue, property.PropertyType);
                }

                property.SetValue(obj, convertedValue);
                Console.WriteLine("Property updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating property: {ex.Message}");
            }
        }
    }
}
