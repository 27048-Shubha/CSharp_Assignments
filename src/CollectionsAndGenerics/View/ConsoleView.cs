namespace CollectionsAndGenerics.View
{
    using System;

    /// <summary>
    /// Manages console operations.
    /// </summary>
    public static class ConsoleView
    {
        /// <summary>
        /// Displays message to the console.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public static void DisplayMessage(string message)
        {
            Console.WriteLine($"{message}");
        }

        /// <summary>
        /// Displays collection to the user.
        /// </summary>
        /// <param name="collection">Collection to be displayed.</param>
        public static void DisplayCollection(IReadOnlyCollection<string> collection)
        {
            if(collection.Count == 0)
            {
                ConsoleView.DisplayMessage("Currently empty");
            }

            foreach (string item in collection)
            {
                ConsoleView.DisplayMessage($"{item}");
            }
        }

        /// <summary>
        /// Displays dictionary to the user.
        /// </summary>
        /// <param name="dict">Dictionary to be displayed.</param>
        public static void DisplayDictionary(IReadOnlyDictionary<string, int> dict)
        {
            if (dict.Count == 0)
            {
                ConsoleView.DisplayMessage("Currently empty");
            }

            foreach (var item in dict)
            {
                ConsoleView.DisplayMessage( $"{item.Key} : Grade {item.Value}");
            }
        }
    }
}
