namespace CollectionsAndGenerics.Controller
{
    using CollectionsAndGenerics.Services;
    using CollectionsAndGenerics.View;

    /// <summary>
    /// Controlls overall application flow.
    /// </summary>
    internal class MainController
    {
        private readonly StackOperationsService<char> _stackService;
        private readonly QueueOperationsService<string> _queueService;
        private readonly ListOperationsService<string> _listService;
        private readonly DictionaryOperationsService<string, int> _dictService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainController"/> class.
        /// </summary>
        /// <param name="stackService">Object to handle stack services</param>
        /// <param name="queueService">Object to handle queue services</param>
        /// <param name="listService">Object to handle list services</param>
        /// <param name="dictService">Object to handle dictionary services</param>
        public MainController(StackOperationsService<char> stackService, QueueOperationsService<string> queueService, ListOperationsService<string> listService, DictionaryOperationsService<string, int> dictService)
        {
            this._stackService = stackService;
            this._queueService = queueService;
            this._listService = listService;
            this._dictService = dictService;
        }

        /// <summary>
        /// Entry point of collections and generics demonstration.
        /// </summary>
        public void Run()
        {
            string? choice;

            do
            {
                ConsoleView.DisplayMessage("=================================================");
                ConsoleView.DisplayMessage("      COLLECTIONS AND GENERICS DEMONSTRATION");
                ConsoleView.DisplayMessage("=================================================");
                ConsoleView.DisplayMessage("1. Book Management System (List");
                ConsoleView.DisplayMessage("2. String Reversal Utility (Stack)");
                ConsoleView.DisplayMessage("3. People Queue Management (Queue)");
                ConsoleView.DisplayMessage("4. Student Grade Management (Dictionary)");
                ConsoleView.DisplayMessage("5. IEnumerable Demo");
                ConsoleView.DisplayMessage("6. IReadOnlyDictionary Demo");
                ConsoleView.DisplayMessage("7. Exit");
                ConsoleView.DisplayMessage("\nEnter your choice: ");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        new ListController(this._listService).Run();
                        break;

                    case "2":
                        new StackController(this._stackService).Run();
                        break;

                    case "3":
                        new QueueController(this._queueService).Run();
                        break;

                    case "4":
                        new DictController(this._dictService).Run();
                        break;

                    case "5":
                        new EnumerableController().Run();
                        break;

                    case "6":
                        new DictionaryExplorer().Run();
                        break;

                    case "7":
                        ConsoleView.DisplayMessage("Exiting application...");
                        return;

                    default:
                        ConsoleView.DisplayMessage("Invalid choice. Please try again.");
                        break;
                }

                ConsoleView.DisplayMessage("\nConsole will be refreshed within 5 seconds... Kindly wait");

                Thread.Sleep(5000);
                Console.Clear();
            }
            while (true);
        }

        /// <summary>
        /// Initializes list operation.
        /// </summary>
        public void InitializeList()
        {
            new ListController(_listService).Run();
        }

        /// <summary>
        /// Initializes stack operation.
        /// </summary>
        public void InitializeStack()
        {
            new StackController(_stackService).Run();
        }

        /// <summary>
        /// Initializes queue operation.
        /// </summary>
        public void InitializeQueue()
        {
            new QueueController(_queueService).Run();
        }

        /// <summary>
        /// Initializes dictionary operation.
        /// </summary>
        public void InitializeDict()
        {
            new DictController(_dictService).Run();
        }
    }
}
