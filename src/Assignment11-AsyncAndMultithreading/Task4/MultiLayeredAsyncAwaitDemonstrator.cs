namespace Assignment11_AsyncAndMultithreading.Task4
{
    using System.Text.Json;

    /// <summary>
    /// Demonstrates the concept of multi-layered async/await operations
    /// </summary>
    internal class MultiLayeredAsyncAwaitDemonstrator
    {
        private readonly HttpClient _client = new ();

        /// <summary>
        /// Runs task 4 operations.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. </returns>
        public async Task Run()
        {
            Console.WriteLine();

            try
            {
                long finalResult = await this.MethodC();

                Console.WriteLine($"Final Result: {finalResult}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Task<int> MethodA()
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Method A: Performing analysis...");

                long sum = 0;

                for (int i = 1; i <= 100000; i++)
                {
                    sum += i;
                }

                return (int)(sum % 10) + 1;
            });
        }

        private async Task<string> MethodB()
        {
            int id = await this.MethodA();

            Console.WriteLine($"Method B: Result from A : {id} ");

            string url = $"https://jsonplaceholder.typicode.com/todos/{id}";

            Console.WriteLine($"Method B: Calling web service");

            string response = await this._client.GetStringAsync(url);

            Console.WriteLine($"Method B: Web service response received.");

            return response;
        }

        private async Task<long> MethodC()
        {
            string result = await this.MethodB();

            Console.WriteLine($"Method C: Result from B: {result}");

            using JsonDocument document = JsonDocument.Parse(result);

            JsonElement root = document.RootElement;

            long id = root.GetProperty("id").GetInt64();

            Console.WriteLine($"Method C: Extracted Id = {id}");

            return id;
        }
    }
}
