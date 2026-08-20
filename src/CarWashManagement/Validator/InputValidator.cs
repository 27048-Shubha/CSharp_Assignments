using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Validator
{
    /// <summary>
    /// Handles validation operations of the user input.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Checks whether the email id entered is valid or not.
        /// </summary>
        /// <param name="emailId">Email id entered by the user.</param>
        /// <returns>True if email id is valid, else False.</returns>
        public static bool IsValidEmailId(string emailId)
        {
            if (string.IsNullOrEmpty(emailId))
            {
                return false;
            }

            int index = emailId.IndexOf('@');
            if (index < 1)
            {
                return false;
            }

            if (index != emailId.LastIndexOf('@'))
            {
                return false;
            }

            if(emailId.IndexOf('.') == emailId.Length)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks whether the phone number entered is valid or not.
        /// </summary>
        /// <param name="phoneNumber">Phone number entered by the user.</param>
        /// <returns>True if phonenumber is valid, else False.</returns>
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 10)
            {
                return false;
            }

            foreach (char character in phoneNumber)
            {
                if (!char.IsDigit(character))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks whether the password entered is valid or not.
        /// </summary>
        /// <param name="password">password entered by the user.</param>
        /// <returns>True if password is valid, else False.</returns>
        public static bool IsValidPassword(string password) => password.Length >= 8;

        /// <summary>
        /// Checks whether the register number entered is valid or not.
        /// </summary>
        /// <param name="registerNumber">Register number entered by the user.</param>
        /// <returns>True if register number is valid, else False.</returns>
        public static bool IsValidRegisterNumber(string registerNumber)
        {
            if (string.IsNullOrEmpty(registerNumber))
            {
                return false;
            }

            foreach (char character in registerNumber.Substring(0, 2))
            {
                if (!char.IsLetter(character))
                {
                    return false;
                }
            }

            foreach (char character in registerNumber.Substring(2, 4))
            {
                if (!char.IsDigit(character))
                {
                    return false;
                }
            }

            foreach (char character in registerNumber.Substring(4, 6))
            {
                if (!char.IsLetter(character))
                {
                    return false;
                }
            }

            foreach (char character in registerNumber.Substring(6, 10))
            {
                if (!char.IsDigit(character))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
