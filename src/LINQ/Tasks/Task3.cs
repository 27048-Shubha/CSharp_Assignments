using LINQ.Models.DTOs;
using System.Numerics;

namespace LINQ.Tasks
{
    public class Task3
    {
        private readonly int[] _numbers = new int[] { 10, 9, 12, 9, 22, 9, 11, 3, 19, 3 };
        private int _target = 22;

        public int FindSecondHighestNumber()
        {
            return this._numbers.OrderByDescending(number => number).Skip(1).First();
        }

        public List<PairDTO> UniquePairsAddUptoTarget()
        {
            List<PairDTO> pairs = this._numbers.SelectMany(
                            (a, i) => this._numbers
                            .Skip(i + 1)
                            .Where(b => a + b == this._target)
                            .Select(b => new PairDTO()
                            {
                                Value1 = a,
                                Value2 = b,
                            })).ToList();

            return pairs;
        }
    }
}
