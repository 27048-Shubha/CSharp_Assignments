namespace LINQ.Repository
{
    using System.IO;
    using System.Text.Json;
    using LINQ.Models;

    /// <summary>
    /// Provides JSON file-based storage operations for orders.
    /// </summary>
    public class OrderRepository
    {
        private readonly string _filePath;
        private readonly string _directoryName;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderRepository"/> class.
        /// </summary>
        internal OrderRepository()
        {
            this.Orders = new List<Order>();
            this._directoryName = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            this._filePath = Path.Combine(this._directoryName, "orders.json");
        }

        /// <summary>
        /// Gets or sets the collection of orders loaded from storage.
        /// </summary>
        /// <value>The list of orders.</value>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Adds an order to storage.
        /// </summary>
        /// <param name="order">The order to add.</param>
        public void Add(Order order)
        {
            this.ReadFromJson();
            this.Orders.Add(order);
            this.WriteToJson();
        }

        /// <summary>
        /// Retrieves all orders from storage.
        /// </summary>
        /// <returns>A read-only collection of orders.</returns>
        public IReadOnlyList<Order> GetAll()
        {
            this.ReadFromJson();
            return this.Orders;
        }

        /// <summary>
        /// Removes all data from the underlying JSON file.
        /// </summary>
        public void ClearFile()
        {
            if (File.Exists(this._filePath))
            {
                File.WriteAllText(this._filePath, string.Empty);
            }
        }

        /// <summary>
        /// Loads order data from the JSON file into memory.
        /// </summary>
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

        /// <summary>
        /// Persists the current order collection to the JSON file.
        /// </summary>
        public void WriteToJson()
        {
            string newData = JsonSerializer.Serialize(this.Orders);
            File.WriteAllText(this._filePath, newData);
        }
    }
}
