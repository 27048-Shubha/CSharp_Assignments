using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Transactions;

namespace LINQ.Repository
{
    public class ProductRepository
    {
        internal ProductRepository()
        {
            this.Products = new List<Product>();
        }

        public List<Product> Products { get; set; }

        public void Add(Product product)
        {
            this.Products.Add(product);
        }

        public IReadOnlyList<Product> GetAll()
        {
            return (IReadOnlyList<Product>)this.Products;
        }

        //public List<Product> ReadFromJson()
        //{
        //    if (!File.Exists(filePath))
        //    {
        //        return new List<Product>();
        //    }

        //    var json = File.ReadAllText(filePath).Trim();

        //    if (string.IsNullOrWhiteSpace(json))
        //    {
        //        return new List<Product>();
        //    }

        //    if (json.StartsWith("["))
        //    {
        //        return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        //    }

        //    if (json.StartsWith("{"))
        //    {
        //        var products = JsonSerializer.Deserialize<Product>(json);

        //        return products is null
        //            ? new List<Product>()
        //            : new List<Product> { products };
        //    }

        //    return new List<Product>();
        //}

        //public void WriteToJson()
        //{

        //}
    }
}
