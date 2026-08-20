namespace CarWashManagement.Controller
{
    using CarWashManagement.View;
    /// <summary>
    /// Controls entry point of the application.
    /// </summary>
    public class MainController
    {
        private readonly ConsoleView _console;
        private readonly UserController _userController;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainController"/> class.
        /// </summary>
        /// <param name="console">Object to handle console operation.</param>
        /// <param name="userController">Object to handle user control operation.</param>
        internal MainController(ConsoleView console, UserController userController)
        {
            this._console = console;
            this._userController = userController;
        }

        /// <summary>
        /// Entry point of the application.
        /// </summary>
        public void StartMenu()
        {
            while (true)
            {
                _console.DisplayMainMenu();
                int choice = _console.GetUserChoice();

                switch ((Enums.MainMenuChoice) choice)
                {
                    case Enums.MainMenuChoice.Register:
                        _userController.Register();
                        break;

                    case Enums.MainMenuChoice.Login:
                        _userController.Login();
                        break;

                    case Enums.MainMenuChoice.Exit:
                        _console.DisplayExitMessage();
                        return;

                    default:
                        _console.DisplayInvalidChoice();
                        break;
                }
            }
        }
    }
}
