namespace ExceptionHandling.Task4
{
    using System;

    /// <summary>
    /// Manages and handles global exception via AppDomain events.
    /// </summary>
    internal class ApplicationRunner
    {
        /// <summary>
        /// Calls method in IntegterArray class.
        /// </summary>
        public static void Run()
        {
            AppDomain.CurrentDomain.UnhandledException += ApplicationRunner.OnUnhandledException;
            IntegerArray integerArray = new IntegerArray();
            integerArray.Run();
        }

        /// <summary>
        /// Handles exception thrown globally through AppDomain.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="exception">Event arguments of unhandled exception.</param>
        public static void OnUnhandledException(object sender, UnhandledExceptionEventArgs exception) // Signature of UnhandledException event.
        {
            Console.WriteLine($"Exception handled using AppDomain UnhandledException event.");
            Console.WriteLine("Unexpected exception occured!");
            Console.WriteLine(((Exception)exception.ExceptionObject).Message);
            Console.WriteLine("Terminating...");
        }
    }
}
