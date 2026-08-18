namespace ExceptionHandling.Task2
{
    using System;
    public class Array
    {
        private int[] _nums;
        private int _size;

        internal Array(int size)
        {
            this._nums = new int[size];
            this._size = size;
        }
        public void InsertElements()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine($"Enter array element {i}: ");
                _nums[i] = int.Parse(Console.ReadLine());
            }
        }
        public int FetchElement()
        {
            Console.WriteLine("Enter index value: ");
            int index = int.Parse(Console.ReadLine());
            try
            {
                return _nums[index];
            }
            catch
            {
                throw new IndexOutOfRangeException("Valid index range: {0} to {size}}");
            }
        }

        public void Run()
        {
            Console.WriteLine("Enter size of the array: ");
            int arraySize = int.Parse(Console.ReadLine());

            Array array = new Array(arraySize);
            array.InsertElements();
            try
            {
                array.FetchElement();
            }
            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine($"{exception.Message}");
            }
        }
    }
}