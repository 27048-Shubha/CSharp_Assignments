namespace Assignment11_AsyncAndMultithreading.Task2
{
    /// <summary>
    /// Demonstrates the concept of Task Parallel Library (TPL).
    /// </summary>
    public class Task2_ArrayManipulator
    {
        private int[] _integerArray = new int[10000];

        /// <summary>
        /// Manages exectuion of task 2 demonstration.
        /// </summary>
        public void Run()
        {
            this.InitializeArray();

            Console.WriteLine("Elements before squaring: ");
            this.DisplayArrayElements();

            this.SquareElements();

            Console.WriteLine("Elements after squaring: ");
            this.DisplayArrayElements();
        }

        private void InitializeArray()
        {
            for (int i = 0; i < this._integerArray.Length; i++)
            {
                this._integerArray[i] = i + 1;
            }
        }

        private void SquareElements()
        {
            Parallel.ForEach(
                Enumerable.Range(0, this._integerArray.Length),
                i =>
                {
                    this._integerArray[i] = this._integerArray[i] * this._integerArray[i];
                });
        }

        private void DisplayArrayElements()
        {
            foreach (int element in this._integerArray)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine();
        }
    }
}
