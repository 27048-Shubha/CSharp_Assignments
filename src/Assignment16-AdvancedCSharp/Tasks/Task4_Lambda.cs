namespace Assignment16_AdvancedCSharp.Tasks
{
    internal class Task4_Lambda
    {
        private readonly List<int> _integerList = new List<int> { 1, 2, 3, 5, 6, 7, 8, 9, 10 };
        
        public void Run()
        {
            IEnumerable<int> filteredNumbers = this._integerList.Where(n => n % 2 != 0);
            Console.WriteLine("\nOdd Numbers: ");
            this.Display(filteredNumbers);

            IEnumerable<int> squaredNumbers = filteredNumbers.Select(n => { return n * n; });
            Console.WriteLine("\nSquared Numbers: ");
            this.Display(squaredNumbers);
        }

        public void Display(IEnumerable<int> numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write($"{number} ");
            }
        }
    }
}
