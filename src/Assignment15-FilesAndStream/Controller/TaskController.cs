namespace Assignment15_FilesAndStream.Service
{
    using Assignment15_FilesAndStream.Controller;
    using Assignment15_FilesAndStream.Helper;

    public class TaskController
    {
        private const int OneMb = 1024 * 1024;

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n===== File & Stream Tasks =====");
                Console.WriteLine("1. File Data Processor");
                Console.WriteLine("2. Sync vs Async File Processing");
                Console.WriteLine("3. Basic File Usage");
                Console.WriteLine("4. Logging with Multiple Threads");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        new FileProcessorController(new SynchronousFileProcessor()).ExecuteBufferComparison();
                        break;

                    case 2:
                        FileGenerator.GenerateFile("source1.txt", OneMb);
                        FileGenerator.GenerateFile("source2.txt", OneMb);
                        FileGenerator.GenerateFile("source3.txt", OneMb);

                        new SyncAsynController(new SynchronousFileProcessor(), new AsynchronousFileProcessor()).ExecuteFileProcessingComparison().GetAwaiter().GetResult();
                        break;

                    case 3:
                        BasicFileUsage.Run();
                        break;

                    case 4:
                        LogController.Run();
                        break;

                    case 5:
                        Console.WriteLine("Quiting Application...");
                        return;

                    default:
                        Console.WriteLine("Enter valid inputs only (1 to 5)");
                        break;
                }
            }
        }
    }
}