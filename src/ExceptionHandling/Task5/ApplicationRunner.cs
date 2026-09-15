using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionHandling.Task5;

namespace ExceptionHandling.Task5
{
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
            try
            {
                AppDomain.CurrentDomain.UnhandledException += ExceptionHandler;
                IntegerArray integerArray = new IntegerArray();
                integerArray.Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Exception handled using global try catch");
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
            }
        }

        /// <summary>
        /// Handles exception thrown globally through AppDomain.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="exception">Event arguments of unhandled exception.</param>
        public static void ExceptionHandler(object sender, UnhandledExceptionEventArgs exception) // Signature of UnhandledException event.
        {
            Console.WriteLine("Unexpected exception occured!");
            Console.WriteLine(((Exception)exception.ExceptionObject).Message);
        }
    }
}
