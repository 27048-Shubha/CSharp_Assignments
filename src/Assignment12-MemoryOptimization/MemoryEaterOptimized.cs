namespace MemoryOptimization
{
    /// <summary>
    /// Class representing a memory eater to demonstrate memory optimization.
    /// </summary>
    public class MemoryEaterOptimized
    {
        /// <summary>
        /// List to demonstrate memory optimization.
        /// </summary>
        private readonly List<int[]> _memAlloc = new List<int[]>();

        /// <summary>
        /// Allocates memory to the list.
        /// </summary>
        public void Allocate()
        {
            for (int i = 0; i < 1000; i++)
            {
                this._memAlloc.Add(new int[1000]);

                if (this._memAlloc.Count > 100)
                {
                    this._memAlloc.Clear();
                }

                // Assume memAlloc variable is used only within this loop
                Thread.Sleep(10);
            }
        }
    }
}
