namespace Assignment17_Reflections.Task7
{
    using System.Diagnostics;
    using Assignment17_Reflections.Utilities;

    internal class Task7
    {
        public void RunTask()
        {
            object[] objects =
            {
            new Student("Shubha", 21),
            new Product { Name = "Notebook", Price = 45.5 },
            new Course { Title = "C#", Student = new Student("Shubha", 20) },
            };

            Console.WriteLine("SERIALIZATION TESTS");

            foreach (object obj in objects)
            {
                string original = ReflectionSerializer.Serialize(obj);
                string emitted = EmitSerializer.Serialize(obj);

                Console.WriteLine($"\nType: {obj.GetType().Name}");
                Console.WriteLine($"Reflection: original}");
                Console.WriteLine($"Emit: {emitted}");
                Console.WriteLine($"Correct (Is orginal and emitted strings are True) : {original == emitted}");
            }

            Student student = new Student("Shubha", 21);

            for (int i = 0; i < 1000; i++)
            {
                ReflectionSerializer.Serialize(student);
                EmitSerializer.Serialize(student);
            }

            const int iterations = 100_000;
            Stopwatch timer = new Stopwatch();

            timer.Start();
            for (int i = 0; i < iterations; i++)
            {
                ReflectionSerializer.Serialize(student);
            }

            timer.Stop();

            long reflectionTime = timer.ElapsedMilliseconds;

            timer.Restart();
            for (int i = 0; i < iterations; i++)
            {
                EmitSerializer.Serialize(student);
            }

            timer.Stop();

            long emitTime = timer.ElapsedMilliseconds;

            Console.WriteLine("\nPERFORMANCE COMPARISON");
            Console.WriteLine($"Iterations: {iterations}");
            Console.WriteLine($"Reflection: {reflectionTime} ms");
            Console.WriteLine($"Emit: {emitTime} ms");
        }
    }
}
