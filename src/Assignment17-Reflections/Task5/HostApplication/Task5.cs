namespace Assignment17_Reflections.Task5
{
    using System.Reflection;
    using Assignment17_Reflections.Task5.PluginInterface;

    /// <summary>
    /// Manages plugin system (task 5)
    /// </summary>
    public class Task5
    {
        /// <summary>
        /// Executes the workflow of the task 5.
        /// </summary>
        public void RunTask()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("PLUGIN SYSTEM");
            Console.WriteLine(new string('=', 50));

            List<IPlugin> plugins = new ();

            var availableDLLs = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            foreach (var item in availableDLLs)
            {
                Console.WriteLine($"DLL Info: {item}");

                Assembly assembly = Assembly.LoadFrom(item);

                Console.WriteLine($"Assembly: {assembly.FullName}");

                foreach (Type type in assembly.GetTypes())
                {
                    if (typeof(IPlugin).IsAssignableFrom(type) &&
                        !type.IsInterface &&
                        !type.IsAbstract)
                    {
                        Console.WriteLine($"Plugin Found: {type.Name}");

                        IPlugin plugin = (IPlugin)Activator.CreateInstance(type) !;
                        plugins.Add(plugin);
                    }
                }

                Console.WriteLine(new string('=', 50));
            }

            int choice;

            while (true)
            {
                Console.WriteLine("\nAvailable Plugins:\n");

                for (int i = 0; i < plugins.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {plugins[i].Name}");
                }

                Console.WriteLine($"[{plugins.Count + 1}] Exit");

                Console.Write("\nEnter plugin choice: ");

                if (int.TryParse(Console.ReadLine(), out choice) &&
                    choice >= 1 &&
                    choice <= plugins.Count)
                {
                    IPlugin selectedPlugin = plugins[choice - 1];
                    selectedPlugin.Encrypt("Hello");
                    selectedPlugin.Decrypt();

                    Console.WriteLine(new string('=', 50));
                }

                if (choice == plugins.Count + 1)
                {
                    Console.WriteLine("Exiting task 5");
                    break;
                }

                Console.WriteLine($"Invalid choice. Please enter a number between 1 and {plugins.Count}.");
            }
        }
    }
}