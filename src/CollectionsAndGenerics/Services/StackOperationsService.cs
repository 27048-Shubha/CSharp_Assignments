using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndGenerics.Services
{
    public class StackOperationsService<T>
    {
        private Stack<T> _stack = new Stack<T>();

        public bool IsEmpty()
        {
            return _stack.Count == 0;
        }

        public void Push(T character)
        {
            this._stack.Push(character);
        }

        public T Pop()
        {
            return this._stack.Pop();
        }
    }
}
