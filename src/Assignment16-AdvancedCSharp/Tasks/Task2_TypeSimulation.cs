namespace Assignment16_AdvancedCSharp.Tasks
{
    internal class Task3_TypeSimulation
    {
        public void SimulateVarUsage()
        {
            var variable = 10;
            Console.WriteLine($"Value of variable: {variable}\nType of variable: {variable.GetType()}");

            Console.WriteLine($"Since variable is of type var, Its type is determined at compile time.\nTherefore value of another type cannot be assigned to variable.\n");
        }

        public void SimulateDynamicUsage()
        {
            dynamic variable = 10;
            Console.WriteLine($"Value of variable: {variable}\nType of variable: {variable.GetType()}");

            variable = "Hello";
            Console.WriteLine($"Value of variable: \nType of variable: {variable.GetType()}");
            Console.WriteLine($"Since variable is of type dynamic, Its type is determined at run time.\nTherefore value of another type can be assigned to variable.");
        }
    }
}
