namespace Assignment15_FilesAndStream.Helper
{
    using System.Diagnostics;

    /// <summary>
    /// Manages timer operations.
    /// </summary>
    public class Timer
    {
        private Stopwatch _stopWatch;

        /// <summary>
        /// Starts stopwatch timer.
        /// </summary>
        public void StartTimer()
        {
            this._stopWatch = Stopwatch.StartNew();
        }

        /// <summary>
        /// Stops stopwatch timer.
        /// </summary>
        public void StopTimer()
        {
            this._stopWatch.Stop();
        }

        /// <summary>
        /// Returns total time taken.
        /// </summary>
        /// <returns>Total time taken.</returns>
        public long GetTimeTaken()
        {
            return this._stopWatch.ElapsedMilliseconds;
        }
    }
}