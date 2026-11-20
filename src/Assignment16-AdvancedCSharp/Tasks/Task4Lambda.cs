namespace Assignment16_AdvancedCSharp.Tasks
{
    /// <summary>
    /// Demonstrates task 4 with lambda expression and statement.
    /// </summary>
    public class Task4Lambda
    {
        private readonly List<int> _integerList = new List<int> { 1, 2, 3, 5, 6, 7, 8, 9, 10 };

        /// <summary>
        /// Entry point of task 4 demonstration.
        /// </summary>
        public void Run()
        {
            Console.WriteLine("\nOriginal list: ");
            this.Display(this._integerList);

            List<int> filteredNumbers = this._integerList.Where(n => n % 2 != 0).ToList();
            Console.WriteLine("\n[Using Lambda expression] Odd Numbers: ");
            this.Display(filteredNumbers);

            List<long> squaredNumbers = filteredNumbers.Select(n => { return (long)n * (long)n; }).ToList();
            Console.WriteLine("\n[Using Lambda statement] Squared Numbers: ");
            this.Display(squaredNumbers);
        }

        private void Display(List<int> numbers)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }

        private void Display(List<long> numbers)
        {
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
