using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Validations
{
    public class ValidateInput
    {
        public bool IsZero(decimal n)
        {
            return (n == 0);
        }
        public bool IsNegative(decimal n)
        {
            return (n < 0);
        }
        public bool IsString(string input)
        {
            return input.All(Char.IsLetter);
        }
        public bool IsNumber(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }
    }
}
