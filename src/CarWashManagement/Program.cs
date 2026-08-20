using CarWashManagement.Controller;
using CarWashManagement.Repository;
using CarWashManagement.Service;
using CarWashManagement.View;

namespace Assignments
{
    /// <summary>
    /// Represents entry point of application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Serves as entry point of the application.
        /// </summary>
        public static void Main()
        {
            ConsoleView console = new ConsoleView();
            UserRepository userRepository = new UserRepository();
            UserService userService = new UserService(userRepository);
            AuthService authService = new AuthService(userService, console);
            UserController userController = new UserController(console, authService);
            MainController controller = new MainController(console, userController);
            controller.StartMenu();
        }
    }
}