namespace CollectionsAndGenerics.Services
{
    /// <summary>
    /// Manages list operations
    /// </summary>
    /// <typeparam name="T">Datatype of list elements.</typeparam>
    public class ListOperationsService<T>
    {
        private List<T> _books = new List<T>();

        /// <summary>
        /// CHecks whether the title exists in the list.
        /// </summary>
        /// <param name="title">Title to be searched.</param>
        /// <returns>True, if exists else False.</returns>
        public bool IsExists(T title)
        {
            return this._books.Exists(bookTitle => bookTitle.Equals(title));
        }

        /// <summary>
        /// Adds title to the list.
        /// </summary>
        /// <param name="title">Title of the book to be added.</param>
        public void Add(T title)
        {
            this._books.Add(title);
        }

        /// <summary>
        /// Removes a title from the list.
        /// </summary>
        /// <param name="title">Title of the book to be removed.</param>
        public void Remove(T title)
        {
            if (this.IsExists(title))
            {
                this._books.Remove(title);
            }
        }

        /// <summary>
        /// Gets and returns all the elements of the list
        /// </summary>
        /// <returns>Read only list of all books in the list.</returns>
        public IReadOnlyList<T> GetAll()
        {
            return this._books;
        }
    }
}
