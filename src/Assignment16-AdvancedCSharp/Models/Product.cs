using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        internal Product(string name, string category, double price)
        {
            Name = name;
            Category = category;
            Price = price;
        }

        public string Name { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }
    }
}
