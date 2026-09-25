namespace Assignment16_AdvancedCSharp.Tasks
{
    /// <summary>
    /// Demonstrates task 4 with lambda expression and statement.
    /// </summary>
    internal class Task4_Lambda
    {
        private readonly List<int> _integerList = new List<int> { 1, 2, 3, 5, 6, 7, 8, 9, 10 };

        /// <summary>
        /// Entry point of task 4 demonstration.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("\nOriginal list: ");
            this.Display(this._integerList);

            IEnumerable<int> filteredNumbers = this._integerList.Where(n => n % 2 != 0);
            Console.WriteLine("\n[Using Lambda expression] Odd Numbers: ");
            this.Display(filteredNumbers);

            IEnumerable<int> squaredNumbers = filteredNumbers.Select(n => { return n * n; });
            Console.WriteLine("\n[Using Lambda statement] Squared Numbers: ");
            this.Display(squaredNumbers);
        }

        private void Display(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
