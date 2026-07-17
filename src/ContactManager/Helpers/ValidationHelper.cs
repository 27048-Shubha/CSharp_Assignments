// Helpers / Validator.cs
using System;
using System.Collections.Generic;

namespace ContactManager.Helpers
{
    /// <summary>
    /// Helper class - Contains all the Validation
    /// </summary>
    internal class ValidationHelper
    {
        private ConsoleManager _console = new ConsoleManager();

        /// <summary>
        /// Validate Phone number based on number of digists
        /// </summary>
        /// <param name="phone">Input Phone number to be validated</param>
        /// <returns>True if length == 10 else False </returns>
        public static bool ValidatePhone(string phone)
        {
            bool isValid = phone == null || phone.Length != 10;

            foreach (char c in phone)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return isValid;
        }
    }
}