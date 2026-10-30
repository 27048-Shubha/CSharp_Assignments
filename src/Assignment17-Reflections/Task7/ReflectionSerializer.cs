namespace Assignment17_Reflections.Task7
{
    using System.Reflection;
    using System.Text.Json;

    /// <summary>
    /// Manages serialization using reflection.
    /// </summary>
    public static class ReflectionSerializer
    {
        /// <summary>
        /// Serializes provided object.
        /// </summary>
        /// <param name="obj">Object t be serialized.</param>
        /// <returns>The serialized data.</returns>
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
