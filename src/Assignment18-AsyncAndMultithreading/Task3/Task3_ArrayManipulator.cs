namespace Assignment11_AsyncAndMultithreading.Task3
{
    /// <summary>
    /// Demonstrates the concept of multi-threading with threads.
    /// </summary>
    public class Task3_ArrayManipulator
    {
        /// <summary>
        /// Manages exectuion of task 3 demonstration.
        /// </summary>
        public void Run()
        {
            Thread thread1 = new Thread(() => this.Sort());
            Thread thread2 = new Thread(() => this.SquareElements());

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        private void InitializeArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = array.Length - i;
            }

            Console.WriteLine("Initial array elements: ");
            this.DisplayArrayElements(array);
        }

        private void Sort()
        {
            Console.WriteLine("=========Sort operation=========");

            int[] integerArray = new int[10];
            this.InitializeArray(integerArray);

            Array.Sort(integerArray);

            Console.WriteLine("\nSorted Array: ");
            this.DisplayArrayElements(integerArray);
        }

        private void SquareElements()
        {
            Console.WriteLine("=========Squaring operation=========");

            int[] integerArray = new int[10];
            this.InitializeArray(integerArray);

            for (int i = 0; i < integerArray.Length; i++)
            {
                integerArray[i] = integerArray[i] * integerArray[i];
            }

            this.DisplayArrayElements(integerArray);
        }

        private void DisplayArrayElements(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine();
        }
    }
}
