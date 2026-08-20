using CarWashManagement.Service;
using CarWashManagement.View;

namespace CarWashManagement.Controller
{
    /// <summary>
    /// Controls between user repository and console operations.
    /// </summary>
    public class UserController
    {
        private readonly AuthService _authService = null;
        private readonly ConsoleView _console = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="console">Object to handle console operation.</param>
        /// <param name="authService">Object to control authentication.</param>
        internal UserController(ConsoleView console, AuthService authService)
        {
            this._authService = authService;
            this._console = console;
        }

        /// <summary>
        /// Manages registration operation.
        /// </summary>
        public void Register()
        {
            string firstName = _console.GetName("First");
            string lastName = _console.GetName("Last");
            string emailId = _console.GetEmailId();
            string phoneNumber = _console.GetPhoneNumber();
            string password = _console.GetPassword(false);
            string confirmPassword = _console.GetPassword(true);

            if (password != confirmPassword)
            {
                this._console.Display("Password doesn't match!");
            }

            _authService.Register(firstName, lastName, emailId, phoneNumber, password);
        }

        /// <summary>
        /// Manages login operation.
        /// </summary>
        public void Login()
        {
            string emailId = _console.GetEmailId();
            string password = _console.GetPassword(false);
            if (_authService.Login(emailId, password))
            {
                _console.DisplayLoginSuccess();
            }
            else
            {
                _console.DisplayLoginFailed();
            }
        }

        /// <summary>
        /// Handles logout operation.
        /// </summary>
        public void LogOut()
        {
            SessionManager.CurrentUser = null;
        }
    }
}
