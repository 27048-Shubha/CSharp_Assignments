namespace CollectionsAndGenerics.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// Manages sum calculation.
    /// </summary>
    public static class Calculation
    {
        /// <summary>
        /// Calculates sum of all elements in the given colleciton.
        /// </summary>
        /// <param name="collection">Collection whose sum to be calculated.</param>
        /// <returns>Sum of all elements</returns>
        public static int SumOfElements(IEnumerable<int> collection)
        {
            int sum = 0;
            foreach (int item in collection)
            {
                sum += item;
            }

            return sum;
        }
    }
}
