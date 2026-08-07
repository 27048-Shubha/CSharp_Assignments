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
        /// <param name="price">Input to be checked.</param>
        /// <param name="priceDecimal">Stores decimal value of input if true,else false.</param>
        /// <returns>True if parsing is su   cessfull, else False.</returns>
        public static bool IsValidDecimal(string? price, out decimal? priceDecimal)
        {
            if (decimal.TryParse(price, out decimal input))
            {
                priceDecimal = input;
                return true;
            }
            else
            {
                priceDecimal = null;
                return false;
            }
        }

        /// <summary>
        /// Checks whether the input is int or not.
        /// </summary>
        /// <param name="stock">Input to be checked.</param>
        /// <param name="stockInt">Stores int value of input if true,else false.</param>
        /// <returns>True if parsing is sucessfull, else False.</returns>
        public static bool IsValidInt(string stock, out int? stockInt)
        {
            if (int.TryParse(stock, out int value))
            {
                stockInt = value;
                return true;
            }

            stockInt = null;
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

        public static bool IsValidDate(string? input, out DateOnly? date)
        {
            date = default;
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return DateOnly.TryParseExact(input, "dd-MM-yyyy", out DateOnly inputDate);
        }
    }
}