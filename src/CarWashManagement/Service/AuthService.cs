using CarWashManagement.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarWashManagement.Service
{
    public class AuthService
    {
        private UserService _userService = null;
        private ConsoleView _console = null;

        internal AuthService(UserService userService, ConsoleView console)
        {
            this._userService = userService;
            this._console = console;
        }

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

        public void Register(string firstName, string lastName, string emailId, string phoneNumber, string password)
        {
            _userService.Register(firstName, lastName, emailId, phoneNumber, password);
        }
    }
}
