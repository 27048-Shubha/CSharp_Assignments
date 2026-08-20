using CarWashManagement.Models;
using CarWashManagement.Service;
using CarWashManagement.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Controller
{
    public class UserController
    {
        private readonly AuthService _authService = null;
        private readonly ConsoleView _console = null;

        internal UserController(ConsoleView console, AuthService authService)
        {
            this._authService = authService;
            this._console = console;
        }

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

        public void LogOut()
        {
            SessionManager.CurrentUser = null;
        }
    }
}
