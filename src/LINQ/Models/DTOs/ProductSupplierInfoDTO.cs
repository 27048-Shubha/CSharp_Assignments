using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models.DTOs
{
    public class ProductSupplierInfoDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public Enums.ProductCategory ProductCategory { get; set; }
        public int SupplierId { get; set; }

        public Enums.SupplierName SupplierName { get; set; }
    }
}
