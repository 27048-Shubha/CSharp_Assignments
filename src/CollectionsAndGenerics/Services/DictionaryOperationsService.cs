using System.Diagnostics;
using System.Xml.Linq;

namespace CollectionsAndGenerics.Services
{
    public class DictionaryOperationsService <TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _students = new Dictionary<TKey, TValue>();

        public bool IsExists(TKey title)
        {
            return this._students.ContainsKey(title);
        }

        public void Add(TKey name, TValue grade)
        {
            this._students.Add(name, grade);
        }

        public void Remove(TKey name)
        {
            if (this.IsExists(name))
            {
                this._students.Remove(name);
            }
        }

        public IReadOnlyDictionary<TKey, TValue> GetAll()
        {
            return this._students;
        }
    }
}
