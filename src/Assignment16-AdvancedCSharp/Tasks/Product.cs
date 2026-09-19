using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment16_AdvancedCSharp.Tasks
{
    public class Product
    {
        internal Product(string name, string category, double price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }

        public string Name { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }
    }
}
