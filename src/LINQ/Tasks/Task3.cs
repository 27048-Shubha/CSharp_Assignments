namespace LINQ.Tasks
{
    using LINQ.Models.DTOs;

    /// <summary>
    /// Performs operations on numeric collections using LINQ.
    /// </summary>
    public class Task3
    {
        private readonly int[] _numbers = new int[] { 10, 9, 12, 9, 22, 9, 11, 3, 19, 3 };
        private int _target = 22;

        /// <summary>
        /// Returns array of integers.
        /// </summary>
        /// <returns>Array of integers</returns>
        public int[] GetArray()
        {
            return this._numbers;
        }

        /// <summary>
        /// Finds the second highest number from the collection.
        /// </summary>
        /// <returns>The second highest number.</returns>
        public int FindSecondHighestNumber()
        {
            return this._numbers.OrderByDescending(number => number).Skip(1).First();
        }

        /// <summary>
        /// Finds unique pairs of numbers whose sum equals the target value.
        /// </summary>
        /// <returns>A list containing the matching number pairs.</returns>
        public List<PairDTO> UniquePairsAddUptoTarget()
        {
            List<PairDTO> pairs = this._numbers.SelectMany(
                            (value1, i) => this._numbers
                            .Skip(i + 1)
                            .Where(value2 => value1 + value2 == this._target)
                            .Select(value2 => new PairDTO()
                            {
                                Value1 = value1,
                                Value2 = value2,
                            })).ToList();

            return pairs;
        }
    }
}
