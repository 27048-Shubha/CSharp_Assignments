using LINQ.Models;
using System.IO;
using System.Text.Json;

namespace LINQ.Repository
{
    public class OrderRepository
    {
        private readonly string _filePath;
        private readonly string _directoryName;
        internal OrderRepository()
        {
            this.Orders = new List<Order>();
            this._directoryName = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            this._filePath = Path.Combine(this._directoryName, "orders.json");
        }

        public List<Order> Orders { get; set; }

        public void Add(Order order)
        {
            this.ReadFromJson();
            this.Orders.Add(order);
            this.WriteToJson();
        }

        public IReadOnlyList<Order> GetAll()
        {
            this.ReadFromJson();
            return this.Orders;
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
                this.Orders = new List<Order>();
                return;
            }

            this.Orders = JsonSerializer.Deserialize<List<Order>>(json) ?? new List<Order>();
        }

        public void WriteToJson()
        {
            string newData = JsonSerializer.Serialize(Orders);
            File.WriteAllText(this._filePath, newData);
        }
    }
}
