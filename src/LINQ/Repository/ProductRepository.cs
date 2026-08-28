using LINQ.Models;
using System.IO;
using System.Text.Json;

namespace LINQ.Repository
{
    public class ProductRepository
    {
        private readonly string _filePath;
        private readonly string _directoryName;
        internal ProductRepository()
        {
            this.Products = new List<Product>();
            this._directoryName = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            this._filePath =  Path.Combine(this._directoryName, "products.json");
        }

        public List<Product> Products { get; set; }

        public void Add(Product product)
        {
            this.ReadFromJson();
            this.Products.Add(product);
            this.WriteToJson();
        }

        public IReadOnlyList<Product> GetAll()
        {
            this.ReadFromJson();
            return this.Products;
        }

        public void ReadFromJson()
        {
            string directory = Path.GetDirectoryName(this._filePath)!;

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (!File.Exists(this._filePath))
            {
                File.Create(this._filePath).Dispose();
            }

            var json = File.ReadAllText(this._filePath).Trim();

            if (string.IsNullOrWhiteSpace(json))
            {
                this.Products = new List<Product>();
                return;
            }

            this.Products = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public void WriteToJson()
        {
            string newData = JsonSerializer.Serialize(Products);
            File.WriteAllText(this._filePath, newData);
        }
    }
}
