namespace ExceptionHandling.Task3
{
    using System;

    /// <summary>
    /// Manages array operations.
    /// </summary>
    public class IntegerArray
    {
        private int[] _array;

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerArray"/> class.
        /// </summary>
        internal IntegerArray()
        {
            this._array = new int[5];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerArray"/> class.
        /// </summary>
        /// <param name="size">Size of the integer array.</param>
        internal IntegerArray(int size)
        {
            this._array = new int[size];
        }

        /// <summary>
        /// Inserts elements into the array.
        /// </summary>
        public void InsertElements()
        {
            for (int i = 0; i < this._array.Length; i++)
            {
                Console.WriteLine($"Enter array element {i}: ");
                if (int.TryParse(Console.ReadLine(), out int element))
                {
                    this._array[i] = element;
                }
                else
                {
                    throw new InvalidUserInputException("Invalid input: User input must be an integer.");
                }
            }
        }

        /// <summary>
        /// Fetches element from the specified index.
        /// </summary>
        /// <returns>Element stored in the particular index.</returns>
        /// <exception cref="IndexOutOfRangeException">Throws when user prompts invalid index.</exception>
        public int FetchElement()
        {
            Console.WriteLine("Enter index value: ");
            int index = int.Parse(Console.ReadLine());
            try
            {
                return this._array[index];
            }
            catch (IndexOutOfRangeException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets user input and calls division operation.
        /// </summary>
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
                Console.WriteLine($"Invalid index\n{exception.Message}");
            }
        }
    }
}