namespace MemoryOptimization
{
    /// <summary>
    /// Class representing a memory eater to demonstrate memory optimization.
    /// </summary>
    public class MemoryEater
    {
        private readonly int _threshold = 1000;

        /// <summary>
        /// List to demonstrate memory optimization.
        /// </summary>
        private readonly List<int[]> _memAlloc = new List<int[]>();

        /// <summary>
        /// Allocates memory to the list.
        /// </summary>
        public void Allocate()
        {
            while (true)
            {
                if (this._memAlloc.Count > this._threshold)
                {
                    Console.WriteLine($"Maximum threshold ({this._threshold}) reached.");
                    return;
                }

                this._memAlloc.Add(new int[1000]);

                // Assume memAlloc variable is used only within this loop
                Thread.Sleep(10);
            }
        }
    }
}
