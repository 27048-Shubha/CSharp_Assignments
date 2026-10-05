namespace Assignment11_AsyncAndMultithreading.Task6
{
    /// <summary>
    /// Demonstrates ConfigureAwait() demonstration.
    /// </summary>
    public class ConfigureAwaitDemonstrator
    {
        /// <summary>
        /// Runs task 6 operations.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. </returns>
        public async Task Run()
        {
            Console.WriteLine("Starting Task 6");
            Console.WriteLine($"Task 6 - Starting thread Id: {Thread.CurrentThread.ManagedThreadId}");

            int finalResult = await this.MethodB();

            Console.WriteLine($"Task 6 - Final thread Id: {Thread.CurrentThread.ManagedThreadId}");
        }

        private async Task<int> MethodA()
        {
            Console.WriteLine("Method A - Before await");
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(3000).ConfigureAwait(false);

            Console.WriteLine("Method A - After await");
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            int result = 100 + 100;
            return result;
        }

        private async Task<int> MethodB()
        {
            Console.WriteLine("Method B - Before await");
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            int result = await this.MethodA();

            Console.WriteLine("Method B - After await");
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            result += 100;

            return result;
        }
    }
}
