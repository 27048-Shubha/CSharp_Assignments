namespace Assignment2.Validators
{
    /// <summary>
    /// Manages input validation operation.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Represents minimum balance amount.
        /// </summary>
        private static readonly decimal MinimumBalance = 100m;

        /// <summary>
        /// Checks whether the input character is valid or not.
        /// </summary>
        /// <param name="input">The input to be validated.</param>
        /// <param name="value">Stores input if its a character. </param>
        /// <returns>True if input string is a character else false. </returns>
        public static bool IsValidChar(string input, out char value)
        {
            return char.TryParse(input, out value);
        }

        /// <summary>
        /// Checks whether the input decimal is valid or not.
        /// </summary>
        /// <param name="input">The input to be validated.</param>
        /// <param name="value">Stores input if its a decimal. </param>
        /// <returns>True if input string is a decimal else false. </returns>
        public static bool IsValidDecimal(string input, out decimal value)
        {
            return decimal.TryParse(input, out value);
        }

        /// <summary>
        /// Checks whether the input double is valid or not.
        /// </summary>
        /// <param name="input">The input to be validated.</param>
        /// <param name="value">Stores input if its a double. </param>
        /// <returns>True if input string is a double else false. </returns>
        public static bool IsValidDouble(string input, out double value)
        {
            return double.TryParse(input, out value);
        }

        /// <summary>
        /// Checks whether received input is zero or not.
        /// </summary>
        /// <param name="number">The input to be validated. </param>
        /// <returns>True if given input is zero else false. </returns>
        public static bool IsZero(decimal number)
        {
            return number == 0;
        }

        /// <summary>
        /// Checks whether received input is zero or not.
        /// </summary>
        /// <param name="number">The input to be validated. </param>
        /// <returns>True if given input is zero else false. </returns>
        public static bool IsPositive(double number)
        {
            return number > 0;
        }

        /// <summary>
        /// Checks whether received input is zero or not.
        /// </summary>
        /// <param name="number">The input to be validated. </param>
        /// <returns>True if given input is zero else false. </returns>
        public static bool IsPositive(decimal number)
        {
            return number > 0;
        }

        /// <summary>
        /// Checks whether received input is negative or not.
        /// </summary>
        /// <param name="number">The input to be validated. </param>
        /// <returns>True if given input is negative else false. </returns>
        public static bool IsNegative(decimal number)
        {
            return number < 0;
        }

        /// <summary>
        /// Checks whether received input is string or not.
        /// </summary>
        /// <param name="input">The input to be validated. </param>
        /// <returns>True if given input is a string else false. </returns>
        public static bool IsValidAlphabeticInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter);
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

            return input.All(char.IsDigit);
        }

        /// <summary>
        /// Checks whether withdrawal is allowed or not.
        /// </summary>
        /// <param name="currentBalance">Current account balance.</param>
        /// <param name="withdrawalAmount">Amount to be withdrawn.</param>
        /// <param name="isSavingsAccount">Flag to indicate account type</param>
        /// <returns>True if withdrawal possible, else false</returns>
        public static bool IsWithdrawalAllowed(
            decimal currentBalance,
            decimal withdrawalAmount,
            bool isSavingsAccount)
        {
            return currentBalance - withdrawalAmount >= (isSavingsAccount ? MinimumBalance : 0);
        }
    }
}
