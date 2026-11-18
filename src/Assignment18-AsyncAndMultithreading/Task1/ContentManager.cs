namespace Assignment11_AsyncAndMultithreading.Task1
{
    /// <summary>
    /// Demonstrates implementation of async and await.
    /// </summary>
    public class ContentManager
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContentManager"/> class.
        /// </summary>
        /// <param name="httpClient">An object containing instance of <see cref="HttpClient"/> class</param>
        internal ContentManager(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        /// <summary>
        /// Manages exectuion of task 1 demonstration.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. </returns>
        public async Task Run()
        {
            string content = await this.DownloadContentAsync("https://www.geeksforgeeks.org/dsa/data-structure-meaning/");
            this.DisplayContent(content);
        }

        private async Task<string> DownloadContentAsync(string url)
        {
            return await this._httpClient.GetStringAsync(url);
        }

        private void DisplayContent(string content)
        {
            Console.WriteLine($"Content fetched from url: ");
            Console.WriteLine(content);
        }
    }
}
