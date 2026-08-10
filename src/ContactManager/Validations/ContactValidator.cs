namespace ContactManager.Validations
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Helper class - Contains all the Validation.
    /// </summary>
    internal static class ContactValidator
    {
        /// <summary>
        /// Validates Phone number based on number of digits.
        /// </summary>
        /// <param name="phone">Input Phone number to be validated.</param>
        /// <returns>True if length == 10 else False.</returns>
        public static bool IsValidPhoneNumber(string phone)
        {
            phone = phone.Trim();
            if (string.IsNullOrWhiteSpace(phone) || phone.Trim().Length != 10)
            {
                return false;
            }

            foreach (char c in phone.Trim())
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Validates email id entered by the user.
        /// </summary>
        /// <param name="email">Input email to be validated.</param>
        /// <returns>True if matches regex patter or without whitespace else False.</returns>
        public static bool IsValidEmail(string? email)
        {
            return string.IsNullOrWhiteSpace(email) || Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        /// <summary>
        /// CHecks whether given input string is empty.
        /// </summary>
        /// <param name="input">Input string to be determined whether empty or not.</param>
        /// <returns>True if empty, else false.</returns>
        public static bool IsEmpty(string? input)
        {
            return input == string.Empty;
        }
    }
}