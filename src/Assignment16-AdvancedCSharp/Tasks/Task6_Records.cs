namespace Assignment16_AdvancedCSharp.Tasks
{
    using Models;

    /// <summary>
    /// Demonstrates record of books.
    /// </summary>
    internal class Task6_Records
    {
        /// <summary>
        /// Entry point of execution for task6.
        /// </summary>
        public void Run()
        {
            Book book1 = new Book("The order of pheonix", "JKRowling", "B1234");
            Book book2 = new Book("The prisoner of azkaban", "JKRowling", "B568");
            Book book3 = new Book("The philosophers stone", "JKRowling", "B2345");
            Book book4 = new Book("The order of pheonix", "JKRowling", "B1234");

            Display(book1);
            Display(book2);
            Display(book3);
            Display(book4);

            Console.WriteLine($"\nResult comparison of different books with different property: {book1 == book2}");
            Console.WriteLine($"Result comparison of different books with same property: {book1 == book4}");

            Book book5 = book2 with { Title = "The deathly hallows" };
            Console.WriteLine($"Result comparison of books created using with keyword: {book2 == book5}");
        }

        private static void Display(Book book)
        {
            var (title, author, isbn) = book;
            Console.WriteLine($"Title: {title}\nAuthor: {author}\nISBN: {isbn}\n");
        }
    }
}
