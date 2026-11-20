namespace Assignment16_AdvancedCSharp.Tasks
{
    using Assignment16_AdvancedCSharp.Models;

    /// <summary>
    /// Demonstrates record of books.
    /// </summary>
    public class Task6Records
    {
        /// <summary>
        /// Entry point of execution for task6.
        /// </summary>
        public void Run()
        {
            Book book1 = new Book("The order of phoenix", "JK Rowling", "B1234");
            Book book2 = new Book("The prisoner of azkaban", "JK Rowling", "B568");
            Book book3 = new Book("The philosopher's stone", "JK Rowling", "B2345");
            Book book4 = new Book("The order of pheonix", "JK Rowling", "B1234");

            DisplayBook(book1);
            DisplayBook(book2);
            DisplayBook(book3);
            DisplayBook(book4);

            Console.WriteLine($"\nResult comparison of different books with different property: {book1 == book2}");
            Console.WriteLine($"Result comparison of different books with same property: {book1 == book4}");

            Console.WriteLine("Record properties are init-only and cannot be modified after creation.");
            Console.WriteLine("==================================================================================");

            #pragma warning disable SA1101 // Known StyleCop issue with record 'with' expressions
            Book book5 = book2 with { Title = "The deathly hallows" };
            Console.WriteLine($"Result comparison of books created using with keyword: {book2 == book5}");
            Console.WriteLine($"Reference Equals: {ReferenceEquals(book1, book4)}");

            Console.WriteLine("\nOriginal Book:");
            DisplayBook(book2);

            Console.WriteLine("Copied Book:");
            DisplayBook(book5);
        }

        private static void DisplayBook(Book book)
        {
            var (title, author, isbn) = book;
            Console.WriteLine($"Title: {title}\nAuthor: {author}\nISBN: {isbn}\n");
        }
    }
}
