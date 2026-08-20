namespace Assignment2.Validators
{
    /// <summary>
    /// Manages input validation operation.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Checks whether the input character is valid or not.
        /// </summary>
        /// <param name="input">The input to be validated.</param>
        /// <param name="value">Stores input if its a character. </param>
        /// <returns>True if input string is a character else false. </returns>
        public static bool IsValidChar(string input, out char value)
        {
            if (char.TryParse(input, out value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether the input decimal is valid or not.
        /// </summary>
        /// <param name="input">The input to be validated.</param>
        /// <param name="value">Stores input if its a decimal. </param>
        /// <returns>True if input string is a decimal else false. </returns>
        public static bool IsValidDecimal(string input, out decimal value)
        {
            if (decimal.TryParse(input, out value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether received input is zero or not.
        /// </summary>
        /// <param name="num">The input to be validated. </param>
        /// <returns>True if given input is zero else false. </returns>
        public static bool IsZero(decimal num)
        {
            return num == 0;
        }

        /// <summary>
        /// Checks whether received input is zero or not.
        /// </summary>
        /// <param name="num">The input to be validated. </param>
        /// <returns>True if given input is zero else false. </returns>
        public static bool IsZero(double num)
        {
            return num == 0;
        }

        /// <summary>
        /// Checks whether received input is negative or not.
        /// </summary>
        /// <param name="num">The input to be validated. </param>
        /// <returns>True if given input is negative else false. </returns>
        public static bool IsNegative(decimal num)
        {
            return num < 0;
        }

        /// <summary>
        /// Checks whether received input is zero or not.
        /// </summary>
        /// <param name="num">The input to be validated. </param>
        /// <returns>True if given input is zero else false. </returns>
        public static bool IsNegative(double num)
        {
            return num < 0;
        }

        /// <summary>
        /// Checks whether received input is string or not.
        /// </summary>
        /// <param name="input">The input to be validated. </param>
        /// <returns>True if given input is a string else false. </returns>
        public static bool IsString(string input)
        {
            if (input.Trim().Equals(string.Empty))
            {
                return false;
            }

            return input.All(char.IsLetter);
        }

        /// <summary>
        /// Checks whether received input is a number or not.
        /// </summary>
        /// <param name="input">The input to be validated. </param>
        /// <returns>True if given input is a number else false. </returns>
        public static bool IsNumber(string input)
        {
            if (input.Trim().Equals(string.Empty))
            {
                return false;
            }

            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
