namespace CarWashManagement.Controller
{
    using CarWashManagement.View;
    public class MainController
    {
        private readonly ConsoleView _console;
        private readonly UserController _userController;

        internal MainController(ConsoleView console, UserController userController)
        {
            this._console = console;
            this._userController = userController;
        }

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
