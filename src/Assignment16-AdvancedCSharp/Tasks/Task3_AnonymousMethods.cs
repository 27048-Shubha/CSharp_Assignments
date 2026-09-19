namespace Assignment16_AdvancedCSharp.Tasks
{
    /// <summary>
    /// Demonstrates usage of anonymous methods.
    /// </summary>
    internal class Task3_AnonymousMethods
    {
        private int[] _integerArray = new int[] { 1, 9, 2, 11, 3, 4, 12, 5, 6, 7 };

        /// <summary>
        /// A delegate to sort array.
        /// </summary>
        public delegate void SortArray();

        /// <summary>
        /// Sorts array using anonymous method.
        /// </summary>
        public void SortUsingAnonymousMethod()
        {
            SortArray sortedArray = delegate()
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (this._integerArray[i] < this._integerArray[j])
                        {
                            int temp = this._integerArray[i];
                            this._integerArray[i] = this._integerArray[j];
                            this._integerArray[j] = temp;
                        }
                    }
                }
            };

            sortedArray();
        }

        /// <summary>
        /// Sorts array using built in method.
        /// </summary>
        public void SortUsingBuiltInMethod()
        {
            Array.Sort(this._integerArray);
        }

        /// <summary>
        /// Resets array to default values.
        /// </summary>
        public void ResetArray()
        {
            this._integerArray = new int[] { 1, 9, 2, 11, 3, 4, 12, 5, 6, 7 };
        }

        /// <summary>
        /// Displays array to the console.
        /// </summary>
        public void DisplayArray()
        {
            foreach (int element in this._integerArray)
            {
                Console.Write($"{element}  ");
            }
        }
    }
}
