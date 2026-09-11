namespace CollectionsAndGenerics.Controller
{
    using System.Collections.Generic;
    using CollectionsAndGenerics.Services;
    using CollectionsAndGenerics.View;

    /// <summary>
    /// Controlls list operations.
    /// </summary>
    internal class ListController
    {
        private readonly ListOperationsService<string> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListController"/> class.
        /// </summary>
        /// <param name="service">Object to handle list services</param>
        internal ListController(ListOperationsService<string> service)
        {
            this._service = service;
        }

        /// <summary>
        /// Entry point of list operation demonstration.
        /// </summary>
        public void Run()
        {
            this.DisplayHeader();
            this.DisplayList();

            ConsoleView.DisplayMessage("\n---------Adding five book titles to the list---------");

            this.AddSampleBooks();
            this.DisplayList();

            ConsoleView.DisplayMessage("\n---Removing a book (Grandma's Bag Full of Stories) from the list---");
            this._service.Remove("Grandma's Bag Full of Stories");
            this.DisplayList();

            ConsoleView.DisplayMessage("\n-------Check if a particular book is in the list-------");
            this.CheckBook("Fundamentals of C#");
            this.CheckBook("Fundamentals of Java");

            this.DisplayList();
        }

        private void DisplayList()
        {
            IReadOnlyList<string> bookList = this._service.GetAll();
            ConsoleView.DisplayMessage("\nBooks Available:");
            ConsoleView.DisplayMessage("--------------------------------------------------------");
            ConsoleView.DisplayCollection(bookList);
            ConsoleView.DisplayMessage("\n");
        }

        private void DisplayHeader()
        {
            ConsoleView.DisplayMessage("=================================================");
            ConsoleView.DisplayMessage("   LIST DEMONSTRATION: STUDENT GRADE MANAGEMENT SYSTEM");
            ConsoleView.DisplayMessage("=================================================");
        }

        private void AddSampleBooks()
        {
            string[] books =
            {
                "The Alchemist",
                "The Arabian Dessert",
                "Grandma's Bag Full of Stories",
                "Fundamentals of C#",
                "To My Younger Self",
            };

            foreach (string book in books)
            {
                this._service.Add(book);
            }
        }

        private void CheckBook(string title)
        {
            if (this._service.IsExists(title))
            {
                ConsoleView.DisplayMessage($"{title} exists in the list");
            }
            else
            {
                ConsoleView.DisplayMessage($"{title} does not exist in the list");
            }
        }
    }
}
