using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public record Book
    {
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }

        public string Title { get; init; }
        public string Author { get; init; }
        public string ISBN { get; init; }

        public void Deconstruct(out string title, out string author, out string isbn)
        {
            title = Title;
            author = Author;
            isbn = ISBN;
        }
    }
}
