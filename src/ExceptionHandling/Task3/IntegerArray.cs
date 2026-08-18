namespace ExceptionHandling.Task3
{
    using ExceptionHandling.Task3;
    using System;

    public class IntegerArray
    {
        private int[] _array;
        private int _size;

        internal IntegerArray(int size)
        {
            this._array = new int[size];
            this._size = size;
        }
        public void InsertElements()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine($"Enter array element {i}: ");
                if (int.TryParse(Console.ReadLine(), out int element))
                {
                    _array[i] = element;
                }
                else
                {
                    throw new InvalidUserInputException("Invalid input: User input must be an integer.");
                }
            }
        }
        public int FetchElement()
        {
            Console.WriteLine("Enter index value: ");
            int index = int.Parse(Console.ReadLine());
            try
            {
                return _array[index];
            }
            catch
            {
                throw new IndexOutOfRangeException("Valid index range: {0} to {size}}");
            }
        }

        public void Run()
        {
            Console.WriteLine("Enter size of the array: ");
            int size = int.Parse(Console.ReadLine());

            IntegerArray array = new IntegerArray(size);
            try
            {
                array.InsertElements();
                array.FetchElement();
            }
            catch (InvalidUserInputException exception)
            {
                Console.WriteLine(exception.Message);
            }

            catch (IndexOutOfRangeException exception)
            {
                Console.WriteLine($"{exception.Message}");
            }
        }
    }
}