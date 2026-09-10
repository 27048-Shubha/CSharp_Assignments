using CollectionsAndGenerics.Controller;
using CollectionsAndGenerics.Services;
using CollectionsAndGenerics.View;

namespace Assignments
{
    internal class Program
    {
        public static void Main(string[] args)
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