namespace LINQ.Repository
{
    using System.Text.Json;
    using LINQ.Models;

    /// <summary>
    /// Provides JSON file-based storage operations for products.
    /// </summary>
    public class ProductRepository
    {
        private readonly string _filePath;
        private readonly string _directoryName;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        internal ProductRepository()
        {
            this.Products = new List<Product>();
            this._directoryName = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            this._filePath =  Path.Combine(this._directoryName, "products.json");
        }

        /// <summary>
        /// Gets or sets the collection of products loaded from storage.
        /// </summary>
        /// <value>The list of products.</value>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Adds a product to storage.
        /// </summary>
        /// <param name="product">The product to add.</param>
        public void Add(Product product)
        {
            this.ReadFromJson();
            this.Products.Add(product);
            this.WriteToJson();
        }

        /// <summary>
        /// Retrieves all products from storage.
        /// </summary>
        /// <returns>A read-only collection of products.</returns>
        public IReadOnlyList<Product> GetAll()
        {
            this.ReadFromJson();
            return this.Products;
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
        /// Loads product data from the JSON file into memory.
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
                this.Products = new List<Product>();
                return;
            }

            this.Products = JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        /// <summary>
        /// Persists the current product collection to the JSON file.
        /// </summary>
        public void WriteToJson()
        {
            string newData = JsonSerializer.Serialize(this.Products);
            File.WriteAllText(this._filePath, newData);
        }
    }
}
