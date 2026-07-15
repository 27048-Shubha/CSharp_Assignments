//Helpers / Helpers.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Helpers
{
    /// <summary>
    /// Helper class - Contains all the Validation
    /// </summary>
    internal class Helpers
    {
        private ConsoleManager _console = new ConsoleManager();

        /// <summary>
        /// Validate Phone number based on number of digists
        /// </summary>
        /// <param name="phone">Input Phone number to be validated</param>
        /// <returns>True if length == 10 else False </returns>
        public static bool ValidatePhone(string phone)
        {
            if (phone.Length != 10)
            {
                _console.DisplayInvalidPhoneMessage();
                return false;
            }
            return true;
        }
    }
}