namespace Assignment17_Reflections.Task2
{
    using System.Reflection;
    using Assignment17_Reflections.Utilities;

    public class Task2
    {
        public void DisplayProperties(object obj)
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

        public void SetProperty(object obj, string propertyName, object? newValue)
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

        public void RunTask()
        {
            Student student = new Student("Shubha", 20);

            Console.WriteLine("Before modification: ");
            this.DisplayProperties(student);

            Console.WriteLine("Updating name: ");
            this.SetProperty(student, "Name", "Shree");

            Console.WriteLine("Updating age: ");
            this.SetProperty(student, "Age", 22);

            Console.WriteLine("After modification: ");
            this.DisplayProperties(student);
        }
    }
}
