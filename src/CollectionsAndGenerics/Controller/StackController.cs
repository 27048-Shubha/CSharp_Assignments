namespace CollectionsAndGenerics.Controller
{
    using System.Text;
    using CollectionsAndGenerics.Services;
    using CollectionsAndGenerics.View;

    /// <summary>
    /// Controlls stack operations.
    /// </summary>
    internal class StackController
    {
        private readonly StackOperationsService<char> _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="StackController"/> class.
        /// </summary>
        /// <param name="service">Object to handle stack services</param>
        internal StackController(StackOperationsService<char> service)
        {
            this._service = service;
        }

        /// <summary>
        /// Entry point of stack operation demonstration.
        /// </summary>
        public void Run()
        {
            this.DisplayHeader();

            // Push each character of a given string onto the stack.
            ConsoleView.DisplayMessage("\n---Pushing each character of a the word \"HELLOWORLD\" into the stack...---");
            this.PushCharacters();

            // Pop each character off the stack and append it to a new string.
            ConsoleView.DisplayMessage("\n---Poping each character off the stack....---");

            // Display the original and reversed string.
            ConsoleView.DisplayMessage($"\nReversed (Popped value): {this.PopCharacters()}");
        }

        private void DisplayHeader()
        {
            ConsoleView.DisplayMessage("=======================================================");
            ConsoleView.DisplayMessage("         STACK DEMONSTRATION - STRING REVERSAL");
            ConsoleView.DisplayMessage("=======================================================");
        }

        private void PushCharacters()
        {
            string word = "HELLOWORLD!";

            foreach (char character in word)
            {
                this._service.Push(character);
            }
        }

        private string PopCharacters()
        {
            StringBuilder resultString = new();

            while (!this._service.IsEmpty())
            {
                char poppedCharacter = this._service.Pop();
                ConsoleView.DisplayMessage($"Popped value: {poppedCharacter}");
                resultString.Append(poppedCharacter);
            }

            return resultString.ToString();
        }
    }
}
