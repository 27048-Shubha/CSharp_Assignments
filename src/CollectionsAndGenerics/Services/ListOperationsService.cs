namespace CollectionsAndGenerics.Services
{
    /// <summary>
    /// Manages list operations
    /// </summary>
    /// <typeparam name="T">Datatype of list elements.</typeparam>
    public class ListOperationsService<T>
    {
        private List<T> _items = new List<T>();

        /// <summary>
        /// CHecks whether the item exists in the list.
        /// </summary>
        /// <param name="item">Title to be searched.</param>
        /// <returns>True, if exists else False.</returns>
        public bool IsExists(T item)
        {
            return this._items.Contains(item);
        }

        /// <summary>
        /// Adds item to the list.
        /// </summary>
        /// <param name="item">Title of the book to be added.</param>
        public void Add(T item)
        {
            this._items.Add(item);
        }

        /// <summary>
        /// Removes a item from the list.
        /// </summary>
        /// <param name="item">Title of the book to be removed.</param>
        public void Remove(T item)
        {
            if (this.IsExists(item))
            {
                this._items.Remove(item);
            }
        }

        /// <summary>
        /// Gets and returns all the elements of the list
        /// </summary>
        /// <returns>Read only list of all books in the list.</returns>
        public IReadOnlyList<T> GetAll()
        {
            return this._items;
        }
    }
}
