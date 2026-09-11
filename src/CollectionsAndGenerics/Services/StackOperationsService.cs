namespace CollectionsAndGenerics.Services
{
    /// <summary>
    /// Manages stack operations
    /// </summary>
    /// <typeparam name="T">Datatype of stack elements.</typeparam>
    public class StackOperationsService<T>
    {
        private Stack<T> _stack = new Stack<T>();

        /// <summary>
        /// Checks whether the stack is empty.
        /// </summary>
        /// <returns>True, if stack is empty else False.</returns>
        public bool IsEmpty()
        {
            return _stack.Count == 0;
        }

        /// <summary>
        /// Pushes element into the stack.
        /// </summary>
        /// <param name="character">The element to be pushed.</param>
        public void Push(T character)
        {
            this._stack.Push(character);
        }

        /// <summary>
        /// Pops element from the stack.
        /// </summary>
        /// <returns>Popped element from the stack.</returns>
        public T Pop()
        {
            return this._stack.Pop();
        }
    }
}
