namespace CollectionsAndGenerics.Controller
{
    using CollectionsAndGenerics.View;

    /// <summary>
    /// Controls enumerable demonstration.
    /// </summary>
    public class EnumerableController
    {
        /// <summary>
        /// Entry point of enumerables demonstration.
        /// </summary>
        public void Run()
        {
            List<int> listOfElements = new List<int> { 1, 2, 3, 4, 5 };
            int[] arrayOfElements = new int[] { 1, 2, 3, 4, 5 };
            Queue<int> queueOfElements = new Queue<int>(arrayOfElements);

            ConsoleView.DisplayMessage($"Sum of elements in list: {Calculation.SumOfElements(listOfElements)}");
            ConsoleView.DisplayMessage($"Sum of elements in array: {Calculation.SumOfElements(arrayOfElements)}");
            ConsoleView.DisplayMessage($"Sum of elements in queue: {Calculation.SumOfElements(queueOfElements)}");
        }
    }
}
