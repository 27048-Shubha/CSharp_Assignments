namespace Assignment11_AsyncAndMultithreading.Task7
{
    /// <summary>
    /// Demonstrates async void and async task exceptions.
    /// </summary>
    public class ThreadExceptionDemonstrator
    {
        /// <summary>
        /// Runs task 7 operations.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. </returns>
        public async Task Run()
        {
            Console.WriteLine("=======WARNING: Application may crash on running this=======");
            try
            {
                await this.TaskMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine("TaskMethod Exception Caught:");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine();

            try
            {
                this.VoidMethod();
            }
            catch (Exception ex)
            {
                Console.WriteLine("VoidMethod Exception Caught:");
                Console.WriteLine(ex.Message);
            }
        }

        private async void VoidMethod()
        {
            await Task.Delay(2000);
            throw new Exception("Exception from async void method");
        }

        private async Task TaskMethod()
        {
            await Task.Delay(2000);
            throw new Exception("Exception from async task method");
        }
    }
}
