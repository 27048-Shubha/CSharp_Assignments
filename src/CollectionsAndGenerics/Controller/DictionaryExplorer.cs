namespace CollectionsAndGenerics.Controller
{
    using System.Collections.Generic;
    using CollectionsAndGenerics.View;

    public class DictionaryExplorer
    {
        public void Run()
        {
            IReadOnlyDictionary<string, int> dictionary = GenerateDictionary();
            // dictionary["Apple"] = 10; // This line should throw an error because IReadOnlyDictionary is immutable

            this.PrintDictionary(dictionary);
            ConsoleView.DisplayMessage("dictionary[\"Apple\"] = 10; throws error because IReadOnlyDictionary is immutable");
        }

        public IReadOnlyDictionary<string, int> GenerateDictionary()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("Apple", 10);
            dictionary.Add("Mango", 20);
            dictionary.Add("Orange", 15);
            dictionary.Add("Banana", 30);
            dictionary.Add("JackFruit", 50);

            return dictionary;
        }

        public void PrintDictionary(IReadOnlyDictionary<string, int> dictionary)
        {
            ConsoleView.DisplayMessage("Content in Dictionary:");

            foreach (var pair in dictionary)
            {
                ConsoleView.DisplayMessage($"Key: {pair.Key}, Value: {pair.Value}");
            }
        }
    }
}
