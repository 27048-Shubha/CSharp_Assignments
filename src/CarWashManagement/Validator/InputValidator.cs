using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Validator
{
    public static class InputValidator
    {
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

        public static bool IsValidPassword(string password) => password.Length >= 8;

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
