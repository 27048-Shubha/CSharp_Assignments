namespace ExpenseTracker.Validator
{
    /// <summary>
    /// Manages Validations for Input Data Type.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Checks whether the input is decimal or not.
        /// </summary>
        /// <param name="inputString">Input to be checked.</param>
        /// <param name="inputDecimal">Stores decimal value of input if true,else false.</param>
        /// <returns>True if parsing is su   cessfull, else False.</returns>
        public static bool IsValidDecimal(string inputString, out decimal inputDecimal)
        {
            if (decimal.TryParse(inputString, out decimal input))
            {
                inputDecimal = input;
                return true;
            }
            else
            {
                inputDecimal = 0;
                return false;
            }
        }

        /// <summary>
        /// Checks whether the input is int or not.
        /// </summary>
        /// <param name="inputString">Input to be checked.</param>
        /// <param name="inputInt">Stores int value of input if true,else false.</param>
        /// <returns>True if parsing is sucessfull, else False.</returns>
        public static bool IsValidInt(string inputString, out int? inputInt)
        {
            if (int.TryParse(inputString, out int input))
            {
                inputInt = input;
                return true;
            }

            inputInt = null;
            return false;
        }

        /// <summary>
        /// Checks whether the given string is empty or not.
        /// </summary>
        /// <param name="str">String to be checked.</param>
        /// <returns>True if Not Empty or Null else False.</returns>
        public static bool IsNotNull(string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static bool IsValidDate(string? input, out DateOnly date)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return DateOnly.TryParseExact(input, "dd/MM/yyyy", out date);
        }
    }
}