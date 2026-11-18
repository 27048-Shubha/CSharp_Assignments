namespace Assignment12_MemoryOptimization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class representing a memory eater to demonstrate memory optimization.
    /// </summary>
    public class MemoryEaterUnoptimized
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
                Thread.Sleep(10);
            }
        }
    }
}
