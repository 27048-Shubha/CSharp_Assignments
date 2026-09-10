namespace CollectionsAndGenerics.View
{
    using System;

    public static class ConsoleView
    {
        public static void DisplayMessage(string message)
        {
            Console.WriteLine($"{message}");
        }

        public static void DisplayList(IReadOnlyCollection<string> list)
        {
            if(list.Count == 0)
            {
                ConsoleView.DisplayMessage("Currently empty");
            }

            foreach (string item in list)
            {
                ConsoleView.DisplayMessage($"{item}");
            }
        }

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
