namespace MemoryOptimization
{
    /// <summary>
    /// Manages main flow of the project.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of execution.
        /// </summary>
        public static void Main()
        {
            MemoryEater me = new MemoryEater();
            me.Allocate();
            Console.WriteLine("Program ended");
        }
    }
}