namespace Assignment16_AdvancedCSharp.Tasks
{
    /// <summary>
    /// Manages type simulation of var and dynamic
    /// </summary>
    public class Task2TypeSimulation
    {
        /// <summary>
        /// Simulate usage of var and dynamic keyword.
        /// </summary>
        public void Run()
        {
            SimulateVarUsage();
            SimulateDynamicUsage();
        }

        private static void SimulateVarUsage()
        {
            Console.WriteLine($"---------Usage of var keyword demonstration-----------");
            var number = 10;
            Console.WriteLine($"Value of variable: {number}\nType of variable: {number.GetType()}");

            // number = "Hello"; // Error CS0029: Cannot implicitly convert type 'string' to 'int'
            Console.WriteLine(
                "Since the variable is declared with var, its type is determined at compile time." +
                "Attempting to assign a value of a different type results in a compiler error.");
        }

        private static void SimulateDynamicUsage()
        {
            Console.WriteLine("---------Usage of dynamic keyword demonstration-----------");

            dynamic number = 10;

            Console.WriteLine($"Value of variable: {number}\nType of variable: {number.GetType()}");

            number = "Hello";

            Console.WriteLine($"Value of variable: {number}\nType of variable: {number.GetType()}");

            try
            {
                number.NonExistentMethod();
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
            {
                Console.WriteLine($"RuntimeBinderException: {ex.Message}");
            }

            Console.WriteLine(
                "Unlike var, dynamic bypasses compile-time checking. " +
                "Errors such as calling a non-existent method are detected only at runtime.");
        }
    }
}
