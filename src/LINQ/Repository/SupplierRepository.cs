using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Repository
{
    public class SupplierRepository
    {
        internal SupplierRepository()
        {
            this.Suppliers = new List<Supplier>();
        }

        public List<Supplier> Suppliers { get; set; }

        public void Add(Supplier product)
        {
            this.Suppliers.Add(product);
        }

        public IReadOnlyList<Supplier> GetAll()
        {
            return (IReadOnlyList<Supplier>)this.Suppliers;
        }
    }
}
