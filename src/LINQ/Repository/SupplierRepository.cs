using LINQ.Models;
using System.IO;
using System.Text.Json;

namespace LINQ.Repository
{
    public class SupplierRepository
    {
        private readonly string _filePath;
        private readonly string _directoryName;

        internal SupplierRepository()
        {
            this.Suppliers = new List<Supplier>();
            this._directoryName = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            this._filePath = Path.Combine(this._directoryName, "suppliers.json");
        }

        public List<Supplier> Suppliers { get; set; }

        public void Add(Supplier supplier)
        {
            this.ReadFromJson();
            this.Suppliers.Add(supplier);
            this.WriteToJson();
        }

        public IReadOnlyList<Supplier> GetAll()
        {
            this.ReadFromJson();
            return this.Suppliers;
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
                this.Suppliers = new List<Supplier>();
                return;
            }

            this.Suppliers = JsonSerializer.Deserialize<List<Supplier>>(json) ?? new List<Supplier>();
        }

        public void WriteToJson()
        {
            string newData = JsonSerializer.Serialize(this.Suppliers);
            File.WriteAllText(this._filePath, newData);
        }
    }
}
