namespace CollectionsAndGenerics.Services
{
    /// <summary>
    /// Manages queue operations
    /// </summary>
    /// <typeparam name="T">Datatype of queue elements.</typeparam>
    public class QueueOperationsService<T>
    {
        private Queue<T> _queue = new Queue<T>();

        /// <summary>
        /// Checks whether the queue is empty.
        /// </summary>
        /// <returns>True, if queue is empty else False.</returns>
        public bool IsEmpty()
        {
            return this._queue.Count <= 0;
        }

        /// <summary>
        /// Enqueues element into the queue.
        /// </summary>
        /// <param name="name">Element to be added to the queue.</param>
        public void Enqueue(T name)
        {
            this._queue.Enqueue(name);
        }

        /// <summary>
        /// Dequeues element from the queue.
        /// </summary>
        /// <returns>Element to be removed from the queue.</returns>
        public T Dequeue()
        {
            return this._queue.Dequeue();
        }

        /// <summary>
        /// Returns all the elements of the queue.
        /// </summary>
        /// <returns>Read only list of people from the list. </returns>
        public IReadOnlyList<T> GetAll()
        {
            return this._queue.ToList();
        }
    }
}
