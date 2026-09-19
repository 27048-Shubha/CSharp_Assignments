using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment16_AdvancedCSharp.Tasks
{
    internal class Task2_AnonymousMethods
    {
        private int[] _integerArray = new int[] { 1, 9, 2, 11, 3, 4, 12, 5, 6, 7 };

        public delegate void SortArray();

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

        public void SortUsingBuiltInMethod()
        {
            Array.Sort(this._integerArray);
        }

        public void ResetArray()
        {
            this._integerArray = new int[] { 1, 9, 2, 11, 3, 4, 12, 5, 6, 7 };
        }

        public void DisplayArray()
        {
            foreach (int element in this._integerArray)
            {
                Console.Write($"{element}  ");
            }
        }
    }
}
