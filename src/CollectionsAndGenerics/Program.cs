using CollectionsAndGenerics.Controller;
using CollectionsAndGenerics.Services;

namespace Assignments
{
    /// <summary>
    /// Entry point of execution.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Entry point of application execution.
        /// </summary>
        public static void Main()
        {
             StackOperationsService<char> stackService = new StackOperationsService<char>();
             QueueOperationsService<string> queueService = new QueueOperationsService<string>();
             ListOperationsService<string> listService = new ListOperationsService<string>();
             DictionaryOperationsService<string, int> dictService = new DictionaryOperationsService<string, int>();

             MainController controller = new MainController(stackService, queueService, listService, dictService);

             controller.Run();
        }
    }
}