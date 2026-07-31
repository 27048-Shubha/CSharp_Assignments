namespace Assignment3_InventoryManagement.Helper
{
    /// <summary>
    /// Manages Validations for Input Data Type.
    /// </summary>
    public static class TypeValidation
    {
        /// <summary>
        /// Checks whether the input is decimal or not.
        /// </summary>
        /// <param name="price">Input to be checked.</param>
        /// <param name="priceDecimal">Stores decimal value of input if true,else false.</param>
        /// <returns>True if parsing is sucessfull, else False.</returns>
        public static bool IsValidDecimal(string? price, out decimal priceDecimal)
        {
            if (decimal.TryParse(price, out priceDecimal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks whether the input is int or not.
        /// </summary>
        /// <param name="stock">Input to be checked.</param>
        /// <param name="stockInt">Stores int value of input if true,else false.</param>
        /// <returns>True if parsing is sucessfull, else False.</returns>
        public static bool IsValidInt(string stock, out int stockInt)
        {
            if (int.TryParse(stock, out stockInt))
            {
                return true;
            }
            else
            {
                return false;
            }
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
    }
}
