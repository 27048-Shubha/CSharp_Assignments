namespace Assignment11_AsyncAndMultithreading.Task5
{
    /// <summary>
    /// Demonstrates debugging and fixing deadlocks.
    /// </summary>
    public class DeadLockSimulator
    {
        /// <summary>
        /// Runs task 5 operations.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. </returns>
        public async Task Run()
        {
            Console.WriteLine("Running non-deadlock method:");
            await this.NonDeadLockMethod();

            Console.WriteLine("Press 'y' to simulate deadlock, else any key to continue");
            string userChoice = Console.ReadLine() ?? string.Empty;
            if (userChoice == "y")
            {
                Console.WriteLine("======WARNING:YOU ARE RUNNING A DEADLOCK CODE========");
                this.DeadLockMethod();
            }
        }

        private void DeadLockMethod()
        {
            // Note: Do not use .Result or .Wait() in production code.
            var result = this.SomeAsyncOperation().Result;
            Console.WriteLine(result);
        }

        private async Task NonDeadLockMethod()
        {
            // Note: Do not use .Result or .Wait() in production code.
            var result = await this.SomeAsyncOperation();
            Console.WriteLine(result);
        }

        private async Task<string> SomeAsyncOperation()
        {
            await Task.Delay(1000);
            return "Hello, World!";
        }
    }
}
