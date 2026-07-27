namespace ContactManager.Helpers
{
    using System.Text.RegularExpressions;
    /// <summary>
    /// Helper class - Contains all the Validation
    /// </summary>
    internal class ContactValidator
    {
        private ConsoleView _console = new ConsoleView();

        /// <summary>
        /// Validates Phone number based on number of digits.
        /// </summary>
        /// <param name="phone">Input Phone number to be validated.</param>
        /// <returns>True if length == 10 else False.</returns>
        public static bool ValidatePhone(string phone)
        {
            phone = phone.Trim();
            if (string.IsNullOrEmpty(phone) || phone.Length != 10)
            {
                return false;
            }

            foreach (char c in phone)
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
        public static bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") && !string.IsNullOrWhiteSpace(email);
        }

        public static bool IsEmpty(string input)
        {
            return (input == string.Empty);
        }
    }
}