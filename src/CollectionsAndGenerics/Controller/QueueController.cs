using CollectionsAndGenerics.Services;
using CollectionsAndGenerics.View;

namespace CollectionsAndGenerics.Controller
{
    /// <summary>
    /// Controlls queue operations.
    /// </summary>
    public class QueueController
    {
        private readonly QueueOperationsService<string> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueController"/> class.
        /// </summary>
        /// <param name="service">Object to handle queue services</param>
        internal QueueController(QueueOperationsService<string> service)
        {
            this._service = service;
        }

        /// <summary>
        /// Entry point of queue operation demonstration.
        /// </summary>
        public void Run()
        {
            this.DisplayHeader();

            this.DisplayQueue();

            ConsoleView.DisplayMessage("\n\n--------- Adding People to the Queue ---------");

            this.AddSamplePeople();

            this.DisplayQueue();

            ConsoleView.DisplayMessage("\n--------- Serving First Person ---------");

            string dequeuedPerson = this._service.Dequeue();

            ConsoleView.DisplayMessage(
                $"Served Person: {dequeuedPerson}");

            this.DisplayQueue();
        }

        private void DisplayHeader()
        {
            ConsoleView.DisplayMessage("======================================================");
            ConsoleView.DisplayMessage("  QUEUE DEMONSTRATION: PEOPLE QUEUE MANAGEMENT SYSTEM");
            ConsoleView.DisplayMessage("======================================================");
        }

        private void AddSamplePeople()
        {
            string[] people =
            {
                "Shubha",
                "Bob",
                "Ferb",
                "Finneas",
                "Patrick",
            };

            foreach (string person in people)
            {
                this._service.Enqueue(person);
            }
        }

        private void DisplayQueue()
        {
            IReadOnlyList<string> people = this._service.GetAll();

            ConsoleView.DisplayMessage("\nPeople Waiting in the Queue:");

            ConsoleView.DisplayMessage("------------------------------------------------");

            ConsoleView.DisplayCollection(people);
        }
    }
}
