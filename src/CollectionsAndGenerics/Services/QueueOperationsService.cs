using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndGenerics.Services
{
    public class QueueOperationsService<T>
    {
        private Queue<T> _peopleName = new Queue<T>();

        public bool IsEmpty()
        {
            return this._peopleName.Count < 0;
        }

        public void Enqueue(T name)
        {
            this._peopleName.Enqueue(name);
        }

        public T Dequeue()
        {
            return this._peopleName.Dequeue();
        }

        public IReadOnlyList<T> GetAll()
        {
            return this._peopleName.ToList();
        }
    }
}
