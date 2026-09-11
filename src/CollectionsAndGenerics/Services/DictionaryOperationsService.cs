namespace CollectionsAndGenerics.Services
{
    /// <summary>
    /// Manages dictionary operations
    /// </summary>
    /// <typeparam name="TKey">Datatype of key elements of dictionary.</typeparam>
    /// <typeparam name="TValue">Datatype of value elements of dictionary.</typeparam>
    public class DictionaryOperationsService <TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _students = new Dictionary<TKey, TValue>();

        /// <summary>
        /// Checks whether the key exists in the dictionary
        /// </summary>
        /// <param name="title">Key to be searched</param>
        /// <returns>True, if key exists else false.</returns>
        public bool IsExists(TKey title)
        {
            return this._students.ContainsKey(title);
        }

        /// <summary>
        /// Adds key value pair to the dictionary.
        /// </summary>
        /// <param name="name">Name of the student.</param>
        /// <param name="grade">Grade of the student.</param>
        public void Add(TKey name, TValue grade)
        {
            this._students.Add(name, grade);
        }

        /// <summary>
        /// Removes a specific key from the dictionary.
        /// </summary>
        /// <param name="name">Key to be removed.</param>
        public void Remove(TKey name)
        {
            if (this.IsExists(name))
            {
                this._students.Remove(name);
            }
        }

        /// <summary>
        /// Gets all the key value pairs in the dictionary.
        /// </summary>
        /// <returns>Readonly dictionary of student-grade pair.</returns>
        public IReadOnlyDictionary<TKey, TValue> GetAll()
        {
            return this._students;
        }
    }
}
