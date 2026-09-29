namespace LINQ.Repository
{
    using System.Text.Json;
    using LINQ.Models;

    /// <summary>
    /// Provides JSON file-based storage operations for suppliers.
    /// </summary>
    public class SupplierRepository
    {
        private readonly string _filePath;
        private readonly string _directoryName;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierRepository"/> class.
        /// </summary>
        internal SupplierRepository()
        {
            this.Suppliers = new List<Supplier>();
            this._directoryName = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            this._filePath = Path.Combine(this._directoryName, "suppliers.json");
        }

        /// <summary>
        /// Gets or sets the collection of suppliers loaded from storage.
        /// </summary>
        /// <value>The list of suppliers.</value>
        public List<Supplier> Suppliers { get; set; }

        /// <summary>
        /// Adds a supplier to storage.
        /// </summary>
        /// <param name="supplier">The supplier to add.</param>
        public void Add(Supplier supplier)
        {
            this.ReadFromJson();
            this.Suppliers.Add(supplier);
            this.WriteToJson();
        }

        /// <summary>
        /// Retrieves all suppliers from storage.
        /// </summary>
        /// <returns>A read-only collection of suppliers.</returns>
        public IReadOnlyList<Supplier> GetAll()
        {
            this.ReadFromJson();
            return this.Suppliers;
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
        /// Loads supplier data from the JSON file into memory.
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
                this.Suppliers = new List<Supplier>();
                return;
            }

            this.Suppliers = JsonSerializer.Deserialize<List<Supplier>>(json) ?? new List<Supplier>();
        }

        /// <summary>
        /// Persists the current supplier collection to the JSON file.
        /// </summary>
        public void WriteToJson()
        {
            string newData = JsonSerializer.Serialize(this.Suppliers);
            File.WriteAllText(this._filePath, newData);
        }
    }
}
