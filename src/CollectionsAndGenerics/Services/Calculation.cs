using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndGenerics.Controller
{
    public static class Calculation
    {
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
