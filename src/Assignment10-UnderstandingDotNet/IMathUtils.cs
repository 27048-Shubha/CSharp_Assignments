using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debugging
{
    public interface IMathUtils
    {
        public int Add(int number1, int number2);
        public int Subtract(int number1, int number2);
        public int Multiply(int number1, int number2);
        public int Divide(int number1, int number2);
    }
}
