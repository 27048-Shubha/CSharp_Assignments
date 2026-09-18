namespace Assignment15_FilesAndStream.Helper
{
    using System.Diagnostics;

    public class Timer
    {
        private Stopwatch _stopWatch;

        internal Timer()
        {
            // Empty constructor
        }

        public void StartTimer()
        {
            this._stopWatch = Stopwatch.StartNew();
        }

        public void StopTimer()
        {
            this._stopWatch.Stop();
        }

        public long GetTimeTaken()
        {
            return this._stopWatch.ElapsedMilliseconds;
        }
    }
}