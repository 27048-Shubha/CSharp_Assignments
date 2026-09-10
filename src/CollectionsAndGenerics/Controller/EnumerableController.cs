namespace CollectionsAndGenerics.Controller
{
    using CollectionsAndGenerics.View;
    using System.Collections.Generic;

    public class EnumerableController
    {
        public void Run()
        {
            List<int> listOfElements = new List<int> { 1, 2, 3, 4, 5 };
            int[] arrayOfElemetns = new int[] { 1, 2, 3, 4, 5 };
            Queue<int> queueOfElements = new Queue<int>();
            foreach (int item in arrayOfElemetns)
            {
                queueOfElements.Enqueue(item);
            }

            ConsoleView.DisplayMessage($"Sum of elements in list: {Calculation.SumOfElements(listOfElements)}");
            ConsoleView.DisplayMessage($"Sum of elements in array: {Calculation.SumOfElements(arrayOfElemetns)}");
            ConsoleView.DisplayMessage($"Sum of elements in queue: {Calculation.SumOfElements(queueOfElements)}");
        }
    }
}
