using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        public Enums.SupplierName SupplierName { get; set; }

        public int ProductId { get; set; }
    }
}
