using CarWashManagement.View;

namespace CarWashManagement.Service
{
    /// <summary>
    /// Manages authentication service.
    /// </summary>
    public class AuthService
    {
        private UserService _userService = null;
        private ConsoleView _console = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthService"/> class.
        /// </summary>
        /// <param name="userService">Object to handle user service service.</param>
        /// <param name="console">Object to handle console operation.</param>
        internal AuthService(UserService userService, ConsoleView console)
        {
            this._userService = userService;
            this._console = console;
        }

        /// <summary>
        /// Log in operation.
        /// </summary>
        /// <param name="emailId">Email id entered by the user.</param>
        /// <param name="password">Password of entered by the user.</param>
        /// <returns>True if log in successful, else False</returns>
        public bool Login(string emailId, string password)
        {
            if (!_userService.IsEmailIdExists(emailId))
            {
                _console.Display("User doesn't exists!");
                return false;
            }

            if (string.Compare(password, this._userService.FetchPassword(emailId) ?? string.Empty) == 0)
            {
                SessionManager.CurrentUser = _userService.GetUserData(emailId);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Registers user.
        /// </summary>
        /// <param name="firstName">First name of the user.</param>
        /// <param name="lastName">Last name of the user.</param>
        /// <param name="emailId">Email id of the user.</param>
        /// <param name="phoneNumber">Phone number of the user.</param>
        /// <param name="password">Password of the user.</param>
        public void Register(string firstName, string lastName, string emailId, string phoneNumber, string password)
        {
            _userService.Register(firstName, lastName, emailId, phoneNumber, password);
        }
    }
}
