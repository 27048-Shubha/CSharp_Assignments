namespace Assignment17_Reflections.Task7
{
    using System.Reflection;
    using System.Text.Json;

    public static class ReflectionSerializer
    {
        public static string Serialize(object obj)
        {
            var data = new Dictionary<string, object?>();

            foreach (PropertyInfo p in obj.GetType().GetProperties())
            {
                if (p.CanRead && p.GetIndexParameters().Length == 0 &&
                    p.GetMethod?.IsPublic == true)
                {
                    data[p.Name] = p.GetValue(obj);
                }
            }

            return JsonSerializer.Serialize(data);
        }
    }
}
