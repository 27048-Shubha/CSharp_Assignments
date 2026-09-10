using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndGenerics.Services
{
    public class ListOperationsService<T>
    {
        private List<T> _books = new List<T>();

        public bool IsExists(T title)
        {
            return this._books.Exists(bookTitle => bookTitle.Equals(title));
        }

        public void Add(T title)
        {
            this._books.Add(title);
        }

        public void Remove(T title)
        {
            if (this.IsExists(title))
            {
                this._books.Remove(title);
            }
        }

        public IReadOnlyList<T> GetAll()
        {
            return this._books;
        }
    }
}
