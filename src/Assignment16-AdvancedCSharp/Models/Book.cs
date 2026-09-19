using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public record Book
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="title">Title of the book.</param>
        /// <param name="author">Author of the book.</param>
        /// <param name="isbn">ISBN of the book.</param>
        public Book(string title, string author, string isbn)
        {
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
        }

        /// <summary>
        /// Gets or initializes the title of the book.
        /// </summary>
        /// <value>Title of the book.</value>
        public string Title { get; init; }

        /// <summary>
        /// Gets or initializes the  of the book.
        /// </summary>
        /// <value>Author of the book.</value>
        public string Author { get; init; }

        /// <summary>
        /// Gets or initializes the isbn of the book.
        /// </summary>
        /// <value>ISBN of the book.</value>
        public string ISBN { get; init; }

        /// <summary>
        /// Deconstructs fields of the book class.
        /// </summary>
        /// <param name="title">Title of the book.</param>
        /// <param name="author">Author of the book.</param>
        /// <param name="isbn">ISBN of the book.</param>
        public void Deconstruct(out string title, out string author, out string isbn)
        {
            title = this.Title;
            author = this.Author;
            isbn = this.ISBN;
        }
    }
}
