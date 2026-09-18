namespace Assignment15_FilesAndStream.Tasks
{
    using System.Diagnostics;
    using Assignment15_FilesAndStream.Controller;
    using Assignment15_FilesAndStream.Helper;

    public class TaskController
    {
        private readonly FileDataProcessorSync _syncHandler;
        private readonly FileDataProcessorAsync _asyncHandler;

        internal TaskController()
        {
            this._syncHandler = new FileDataProcessorSync();
            this._asyncHandler = new FileDataProcessorAsync();
        }

        public void Run()
        {
            while (true)
            {
                switch ()
                {
                    case 1:
                        this.RunTask1();
                        break;

                    case 2:
                        FileGenerator.GenerateFile("source1.txt", 1024 * 1024);
                        FileGenerator.GenerateFile("source2.txt", 1024 * 1024);
                        FileGenerator.GenerateFile("source3.txt", 1024 * 1024);

                        RunTask2().GetAwaiter().GetResult();
                        return;

                    case 3:
                        BasicFileUsage.Run();
                        break;

                    case 4:
                        LogController.Run();
                        break;

                    case 5:
                        return;

                    default:
                        break;
                }
            }
        }
    }
}