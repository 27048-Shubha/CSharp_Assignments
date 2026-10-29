namespace Assignment17_Reflections.Task_5.HostApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IPlugin> plugins = new ();

            var AvailableDLLs = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            foreach (var item in AvailableDLLs)
            {
                Console.WriteLine($"DLL Info: {item}");

                Assembly assembly = Assembly.LoadFrom(item);

                Console.WriteLine($"Assembly: {assembly.FullName}");

                foreach (Type type in assembly.GetTypes())
                {
                    Console.WriteLine($"Assembly name: {type.Name}");
                    Console.WriteLine($"{type.Name} - {typeof(IPlugin).IsAssignableFrom(type)}");

                    if (typeof(IPlugin).IsAssignableFrom(type) && !type.IsInterface)
                    {
                        IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                        plugins.Add(plugin);
                    }

                }

                Console.WriteLine("\n--------------------------------------------------\n");
            }

            Console.WriteLine("Available plugins: ");
            int count = 0;
            foreach (var plugin in plugins)
            {
                Console.WriteLine($"{++count}. {plugin.Name}");
            }

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine());

            IPlugin selectedPlugin = plugins[choice - 1];
            selectedPlugin.Encrypt("Hello");
            selectedPlugin.Decrypt();
        }
    }
}