using CarWashManagement.Validator;

namespace CarWashManagement.View
{
    /// <summary>
    /// Manages console operations of the car wash application.
    /// </summary>
    internal class ConsoleView
    {
        private string PhoneNumberRule => "Phone number must contain 10 digits";

        private string PasswordRule => "Password should contain minimum of 8 characters";

        private string EmailIdRule => "Email id should follow universal format with @ and . contained in it";

        /// <summary>
        /// Gets choice from the user.
        /// </summary>
        /// <returns>Choice received from the user.</returns>
        public int GetUserChoice()
        {
            Console.Write("Enter choice: ");
            return int.Parse(Console.ReadLine());
        }

        /// <summary>
        /// Gets name from the user.
        /// </summary>
        /// <param name="nameType">First name or last name.</param>
        /// <returns>Name entered by the user.</returns>
        public string GetName(string nameType)
        {
            Console.Write($"Enter {nameType} name: ");
            string name = Console.ReadLine();

            return name ?? "Name not provided";
        }

        /// <summary>
        /// Gets password from the user.
        /// </summary>
        /// <param name="isConfirmPassword">Password entered by the user.</param>
        /// <returns>Password received from the user.</returns>
        public string GetPassword(bool isConfirmPassword)
        {
            while (true)
            {
                if (isConfirmPassword)
                {
                    Console.Write("Enter password again for confirmation: ");
                }
                else
                {
                    Console.Write("Enter password: ");
                }
                string password = Console.ReadLine();

                if (InputValidator.IsValidPassword(password))
                {
                    return password;
                }
                else
                {
                    this.Display(this.PasswordRule);
                }
            }
        }

        /// <summary>
        /// Gets phone number from the user.
        /// </summary>
        /// <returns>Phone number to the user.</returns>
        public string GetPhoneNumber()
        {
            Console.Write("Enter phone number: ");
            string phoneNumber = Console.ReadLine();

            while (true)
            {
                if (InputValidator.IsValidPhoneNumber(phoneNumber))
                {
                    return phoneNumber;
                }
                else
                {
                    this.Display(this.PhoneNumberRule);
                }
            }
        }

        /// <summary>
        /// Gets email id from the user.
        /// </summary>
        /// <returns>Email id entered by the user.</returns>
        public string GetEmailId()
        {
            while (true)
            {
                Console.Write("Enter email id: ");
                string emailId = Console.ReadLine();

                if (InputValidator.IsValidEmailId(emailId))
                {
                    return emailId;
                }
                else
                {
                    this.Display(this.EmailIdRule);
                }
            }
        }

        /// <summary>
        /// Displays main menu of the application.
        /// </summary>
        public void DisplayMainMenu()
        {
            Console.WriteLine("Welcome to Car Wash Management System!\n" +
                "1. Register\n" +
                "2. Login\n" +
                "3. Exit\n");
        }

        /// <summary>
        /// Displays invalid choice message.
        /// </summary>
        public void DisplayInvalidChoice()
        {
            Console.WriteLine("Invalid choice! Kindly enter valid inputs only!");
        }

        /// <summary>
        /// Displays exit message.
        /// </summary>
        public void DisplayExitMessage()
        {
            Console.WriteLine("Thank you for using our car wash management application");
            Console.WriteLine("Quitting application...");
        }

        /// <summary>
        /// Displays login success message.
        /// </summary>
        public void DisplayLoginSuccess()
        {
            Console.WriteLine("Logged in successfully!");
        }

        /// <summary>
        /// Displayed login failure message.
        /// </summary>
        public void DisplayLoginFailed()
        {
            Console.WriteLine("Login failed!");
        }

        /// <summary>
        /// Displays message to the console.
        /// </summary>
        /// <param name="message">Message to be displayed.</param>
        public void Display(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
