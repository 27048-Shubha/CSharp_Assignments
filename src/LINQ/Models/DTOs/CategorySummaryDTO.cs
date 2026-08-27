using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ.Models.DTOs
{
    public class CategorySummaryDTO
    {
        public Enums.ProductCategory Category { get; set; }
        public decimal Count { get; set; }

        public Product MostExpensiveProduct { get; set; }
    }
}
