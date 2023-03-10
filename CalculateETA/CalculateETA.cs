using System;

namespace CalculateETA
{
    /// <summary>
    /// Calculate the left time to finish current iteration on single-thread and multi-thread applications.
    /// </summary>
    public class CalculateETA
    {
        #region Variables (Multi-Threading)

        private static int counter;
        private static uint counterUint;

        #endregion Variables (Multi-Threading)
               
        /// <summary>
        /// Returns true if the counter is resetted to zero. Returns false if the counter is already zero. (int methods)
        /// </summary>
        /// <returns>True or false</returns>
        public bool ResetCounter()
        {
            if (counter == 0)
            {
                return false;
            }
            else
            {
                //
                counter = 0;

                //
                return true;
            }
        }

        /// <summary>
        /// Returns true if the counter is resetted to zero. Returns false if the counter is already zero. (uint methods)
        /// </summary>
        /// <returns>True or false</returns>
        public bool ResetCounterUint()
        {
            if (counterUint == 0)
            {
                return false;
            }
            else
            {
                //
                counterUint = 0;

                //
                return true;
            }
        }

        #region Single-Thread

        #region Safe Methods

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long)
        /// </summary>
        /// <param name="index">The index of current iteration.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds.</param>
        /// <returns>The left time to finish iteration. (long)</returns>
        public static long? CalcETA(uint index, uint totalIndex, long totalElapsedTimeInMs)
        {
            //
            if (index == 0 || totalIndex == 0 || totalElapsedTimeInMs == 0)
            {
                return null;
            }

            //
            uint leftCount = totalIndex - index;

            //
            long avarageElapsedTime = totalElapsedTimeInMs / index;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long)
        /// </summary>
        /// <param name="index">The index of current iteration.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="tickFrequency">The frequency of tick.</param>
        /// <returns>The left time to finish iteration. (long)</returns>        
        public static long? CalcETA(uint index, uint totalIndex, long totalElapsedTicks, long tickFrequency)
        {
            //
            if (index == 0 || totalIndex == 0 || totalElapsedTicks == 0 || tickFrequency == 0)
            {
                return null;
            }

            //
            uint leftCount = totalIndex - index;

            //
            long seconds = totalElapsedTicks / tickFrequency;

            //
            long avarageElapsedTime = seconds / index;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (double)
        /// </summary>
        /// <param name="index">The index of current iteration.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        /// <returns>The left time to finish iteration. (double)</returns>
        public static double? CalcETA(uint index, uint totalIndex, TimeSpan timeSpan)
        {
            //
            if (index == 0 || totalIndex == 0 || timeSpan == TimeSpan.Zero)
            {
                return null;
            }

            //
            uint leftCount = totalIndex - index;

            //
            double seconds = timeSpan.TotalSeconds;

            //
            double avarageElapsedTime = seconds / index;

            //
            double eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long)
        /// </summary>
        /// <param name="index">The index of current iteration.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds.</param>
        /// <returns>The left time to finish iteration. (long)</returns>
        public static long? CalcETA(int index, int totalIndex, long totalElapsedTimeInMs)
        {
            //
            if (index == 0 || totalIndex == 0 || totalElapsedTimeInMs == 0)
            {
                return null;
            }

            //
            int leftCount = totalIndex - index;

            //
            long avarageElapsedTime = totalElapsedTimeInMs / index;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long)
        /// </summary>
        /// <param name="index">The index of current iteration.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="tickFrequency">The frequency of tick.</param>
        /// <returns>The left time to finish iteration. (long)</returns>        
        public static long? CalcETA(int index, int totalIndex, long totalElapsedTicks, long tickFrequency)
        {
            //
            if (index == 0 || totalIndex == 0 || totalElapsedTicks == 0 || tickFrequency == 0)
            {
                return null;
            }

            //
            int leftCount = totalIndex - index;

            //
            long seconds = totalElapsedTicks / tickFrequency;

            //
            long avarageElapsedTime = seconds / index;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (double)
        /// </summary>
        /// <param name="index">The index of current iteration.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        /// <returns>The left time to finish iteration. (double)</returns>
        public static double? CalcETA(int index, int totalIndex, TimeSpan timeSpan)
        {
            //
            if (index == 0 || totalIndex == 0 || timeSpan == TimeSpan.Zero)
            {
                return null;
            }

            //
            int leftCount = totalIndex - index;

            //
            double seconds = timeSpan.TotalSeconds;

            //
            double avarageElapsedTime = seconds / index;

            //
            double eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        #endregion Safe Methods

        #region Unsafe Methods

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long)
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds.</param>
        /// <returns>The left time to finish iteration. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        public static long CalcETAUnsafe(uint index, uint totalIndex, long totalElapsedTimeInMs)
        {
            //
            uint leftCount = totalIndex - index;

            //
            long avarageElapsedTime = totalElapsedTimeInMs / index;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long)
        /// </summary>
        /// <param name="index">The index of current iteration.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="tickFrequency">The frequency of tick.</param>
        /// <returns>The left time to finish iteration. (long)</returns>   
        /// <exception cref="System.DivideByZeroException">Throws exception if index or tickFrequecny is zero.</exception>
        public static long CalcETAUnsafe(uint index, uint totalIndex, long totalElapsedTicks, long tickFrequency)
        {
            //
            uint leftCount = totalIndex - index;

            //
            long seconds = totalElapsedTicks / tickFrequency;

            //
            long avarageElapsedTime = seconds / index;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (double)
        /// </summary>
        /// <param name="index">The index of current iteration.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        /// <returns>The left time to finish iteration. (double)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        public static double CalcETAUnsafe(uint index, uint totalIndex, TimeSpan timeSpan)
        {
            //
            uint leftCount = totalIndex - index;

            //
            double seconds = timeSpan.TotalSeconds;

            //
            double avarageElapsedTime = seconds / index;

            //
            double eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long)
        /// </summary>
        /// <param name="index">The index of current iteration.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds.</param>
        /// <returns>The left time to finish iteration. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        public static long CalcETAUnsafe(int index, int totalIndex, long totalElapsedTimeInMs)
        {
            //
            int leftCount = totalIndex - index;

            //
            long avarageElapsedTime = totalElapsedTimeInMs / index;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long)
        /// </summary>
        /// <param name="index">The index of current iteration.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="tickFrequency">The frequency of tick.</param>
        /// <returns>The left time to finish iteration. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index or tickFrequency is zero.</exception>
        public static long CalcETAUnsafe(int index, int totalIndex, long totalElapsedTicks, long tickFrequency)
        {
            //
            int leftCount = totalIndex - index;

            //
            long seconds = totalElapsedTicks / tickFrequency;

            //
            long avarageElapsedTime = seconds / index;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (double)
        /// </summary>
        /// <param name="index">The index of current iteration.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        /// <returns>The left time to finish iteration. (double)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        public static double CalcETAUnsafe(int index, int totalIndex, TimeSpan timeSpan)
        {
            //
            int leftCount = totalIndex - index;

            //
            double seconds = timeSpan.TotalSeconds;

            //
            double avarageElapsedTime = seconds / index;

            //
            double eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        #endregion Unsafe Methods

        #endregion Single-Thread

        #region Multi-Thread

        #region Safe Methods

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds</param>
        public static long? CalcETA(uint totalIndex, long totalElapsedTimeInMs)
        {
            //
            if (totalIndex == 0 || totalElapsedTimeInMs == 0)
            {
                return null;
            }

            //
            counterUint++;

            //
            uint leftCount = totalIndex - counterUint;

            //
            long avarageElapsedTime = totalElapsedTimeInMs / counterUint;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="tickFrequency">The frequency of tick.</param>
        /// <returns>The left time to finish iteration. (long)</returns>
        public static long? CalcETA(uint totalIndex, long totalElapsedTicks, long tickFrequency)
        {
            //
            if (totalIndex == 0 || totalElapsedTicks == 0 || tickFrequency == 0)
            {
                return null;
            }

            //
            long seconds = totalElapsedTicks / tickFrequency;

            //
            counterUint++;

            //
            uint leftCount = totalIndex - counterUint;

            //
            long avarageElapsedTime = seconds / counterUint;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (double) on Multi-Threading iterations
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        public static double? CalcETA(uint totalIndex, TimeSpan timeSpan)
        {
            //
            if (totalIndex == 0 || timeSpan == TimeSpan.Zero)
            {
                return null;
            }

            //
            double seconds = timeSpan.TotalMilliseconds;

            //
            counterUint++;

            //
            uint leftCount = totalIndex - counterUint;

            //
            double avarageElapsedTime = seconds / counterUint;

            //
            double eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds</param>
        /// <returns>The left time to finish iteration. </returns>
        public static long? CalcETA(int totalIndex, long totalElapsedTimeInMs)
        {
            //
            if (totalIndex == 0 || totalElapsedTimeInMs == 0)
            {
                return null;
            }

            //
            counter++;

            //
            int leftCount = totalIndex - counter;

            //
            long avarageElapsedTime = totalElapsedTimeInMs / counter;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="tickFrequency">The frequency of tick.</param>
        /// <returns>The left time to finish iteration. (long)</returns>
        public static long? CalcETA(int totalIndex, long totalElapsedTicks, long tickFrequency)
        {
            //
            if (totalIndex == 0 || totalElapsedTicks == 0 || tickFrequency == 0)
            {
                return null;
            }

            //
            long seconds = totalElapsedTicks / tickFrequency;

            //
            counter++;

            //
            int leftCount = totalIndex - counter;

            //
            long avarageElapsedTime = seconds / counter;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (double) on Multi-Threading iterations
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        /// <returns>The left time to finish iteration. (double)</returns>
        public static double? CalcETA(int totalIndex, TimeSpan timeSpan)
        {
            //
            if (totalIndex == 0 || timeSpan == TimeSpan.Zero)
            {
                return null;
            }

            //
            double seconds = timeSpan.TotalMilliseconds;

            //
            counter++;

            //
            int leftCount = totalIndex - counter;

            //
            double avarageElapsedTime = seconds / counter;

            //
            double eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        #endregion Safe Methods

        #region Unsafe Methods

        /// <summary>
        /// [Logically Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds</param>
        public static long CalcETAUnsafe(uint totalIndex, long totalElapsedTimeInMs)
        {
            //
            counterUint++;

            //
            uint leftCount = totalIndex - counterUint;

            //
            long avarageElapsedTime = totalElapsedTimeInMs / counterUint;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="tickFrequency">The frequency of tick.</param>
        /// <returns>The left time to finish iteration. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if tickFrequency is zero.</exception>
        public static long CalcETAUnsafe(uint totalIndex, long totalElapsedTicks, long tickFrequency)
        {
            //
            long seconds = totalElapsedTicks / tickFrequency;

            //
            counterUint++;

            //
            uint leftCount = totalIndex - counterUint;

            //
            long avarageElapsedTime = seconds / counterUint;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Logically Unsafe] Returns calculated estimated time to finish iteration on seconds (double) on Multi-Threading iterations
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        public static double CalcETAUnsafe(uint totalIndex, TimeSpan timeSpan)
        {
            //
            double seconds = timeSpan.TotalMilliseconds;

            //
            counterUint++;

            //
            uint leftCount = totalIndex - counterUint;

            //
            double avarageElapsedTime = seconds / counterUint;

            //
            double eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Logically Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds</param>
        /// <returns>The left time to finish iteration. </returns>
        public static long CalcETAUnsafe(int totalIndex, long totalElapsedTimeInMs)
        {
            //
            counter++;

            //
            int leftCount = totalIndex - counter;

            //
            long avarageElapsedTime = totalElapsedTimeInMs / counter;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="tickFrequency">The frequency of tick.</param>
        /// <returns>The left time to finish iteration. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if tickFrequency is zero.</exception>
        public static long? CalcETAUnsafe(int totalIndex, long totalElapsedTicks, long tickFrequency)
        {
            //
            long seconds = totalElapsedTicks / tickFrequency;

            //
            counter++;

            //
            int leftCount = totalIndex - counter;

            //
            long avarageElapsedTime = seconds / counter;

            //
            long eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        /// <summary>
        /// [Logically Unsafe] Returns calculated estimated time to finish iteration on seconds (double) on Multi-Threading iterations
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        /// <returns>The left time to finish iteration. (double)</returns>
        public static double CalcETAUnsafe(int totalIndex, TimeSpan timeSpan)
        {
            //
            double seconds = timeSpan.TotalMilliseconds;

            //
            counter++;

            //
            int leftCount = totalIndex - counter;

            //
            double avarageElapsedTime = seconds / counter;

            //
            double eta = leftCount * avarageElapsedTime;

            //
            return eta;
        }

        #endregion Unsafe Methods

        #endregion Multi-Thread

        #region Visual Format

        /// <summary>
        /// Returns estimated left time to finish on TimeSpan format.
        /// </summary>
        /// <param name="eTATimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns TimeSpan.Zero if etaTimeInMs is either null or negative. Return TimeSpan format.</returns>
        public static TimeSpan TimeSpanETA(long? eTATimeInMs)
        {
            //
            if (eTATimeInMs == null)
            {
                return TimeSpan.Zero;
            }
            else if (eTATimeInMs < 0)
            {
                return TimeSpan.Zero;
            }

            //
            return new TimeSpan(0, 0, 0, 0, (int)eTATimeInMs);
        }

        /// <summary>
        /// Returns estimated left time to finish on string format. (HH:MM.SS.MMM)
        /// </summary>
        /// <param name="eTATimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTimeInMs is null. Returns "Negative" if etaTimeInMs is negative. Returns TimeSpan format.</returns>
        public static string NumberFormatETA(long? eTATimeInMs)
        {
            //
            if (eTATimeInMs == null)
            {
                return "Uncalculatable";
            }
            else if (eTATimeInMs < 0)
            {
                return "Negative";
            }

            //
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, milliseconds: (int)eTATimeInMs);

            //
            return $"{ts.Hours}:{ts.Minutes}:{ts.Seconds}:{ts.Milliseconds}";
        }

        /// <summary>
        /// Returns estimated time to finish on naming format. (xxx ms or xx second(s) or xx minute(s) and yy (second(s)...)
        /// </summary>
        /// <param name="eTATimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTimeInMs is null. Returns "Negative" if etaTimeInMs is negative. Returns string format.</returns>
        public static string NameETA(long? eTATimeInMs)
        {
            //
            if (eTATimeInMs == null)
            {
                return "Uncalculatable";
            }
            else if (eTATimeInMs < 0)
            {
                return "Negative";
            }
            else if (eTATimeInMs < 1000)
            {
                return $"{eTATimeInMs:0} ms";
            }

            //
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, milliseconds: (int)eTATimeInMs);

            //
            if (ts.TotalSeconds < 60)
            {
                return $"{ts.Seconds} second(s)";
            }
            else if (ts.TotalSeconds < 3600)
            {
                return $"{ts.Minutes} minute(s) and {ts.Seconds} second(s)";
            }
            else if (ts.TotalSeconds < 86400)
            {
                return $"{ts.Hours} hour(s) and {ts.Minutes} minute(s)";
            }
            else
            {
                return $"{ts.Days} day(s) and {ts.Hours} hour(s)";
            }
        }

        #endregion VisualFormat
    }
}