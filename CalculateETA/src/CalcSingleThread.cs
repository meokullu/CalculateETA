using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateETA
{
    /// <summary>
    /// Single-Thread
    /// </summary>
    public partial class CalculateETA
    {
        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds. (long) If iteration takes close to one millisecond, use CalcETA(index, totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        public static long? CalcETA(uint? index, uint? totalIndex, long? totalElapsedTimeInMs)
        {
            // Checking at least one the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (index.HasValue == false || totalIndex.HasValue == false || totalElapsedTimeInMs.HasValue == false)
            {
                // Returning null value to indicate at least one of the given parameters was null.
                return null;
            }

            // Checking if index value is zero. Index value is a dividor on calculation of avarageElapsedTimeInMs.
            if (index.Value == 0)
            {
                // Returning null value to indicate index value is zero.
                return null;
            }

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - index.Value;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = totalElapsedTimeInMs.Value / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds. (long) If iteration less than one millisecond, use CalcETAHighDense(index, totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequent must be ticksPerMillisecond.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long? CalcETA(uint? index, uint? totalIndex, long? totalElapsedTicks, long? frequency)
        {
            // Checking at least one the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (index.HasValue == false || totalIndex.HasValue == false || totalElapsedTicks.HasValue == false || frequency.HasValue == false)
            {
                // Returning null value to indicate one of the given parameters was null.
                return null;
            }

            // Checking if index value or frequency is zero. Index value is a dividor on calculation of avarageElapsedTimeInMs. Frequency value is a dividor on calculation of elapsedSeconds.
            if (index.Value == 0 || frequency == 0)
            {
                // Returning null value to indicate index value or frequency is zero.
                return null;
            }

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - index.Value;

            // Calculating elapsed time with dividing totalElapsedTicks to frequency. 
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = elapsedMilliseconds / index.Value;

            // Calculating ETA by multiply avarage time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) If iteration takes close to one millisecond, use CalcETA(index, totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        public static long? CalcETA(int? index, int? totalIndex, long? totalElapsedTimeInMs)
        {
            // Checking one of the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (index.HasValue == false || totalIndex.HasValue == false || totalElapsedTimeInMs.HasValue == false)
            {
                // Returning null value to indicate one of the given parameters was null.
                return null;
            }

            // Checking if index value is zero. Index value is a dividor on calculation of avarageElapsedTimeInMs.
            if (index.Value == 0)
            {
                // Returning null value to indicate index value is zero.
                return null;
            }

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - index.Value;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = totalElapsedTimeInMs.Value / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds. (long) If iteration less than one millisecond, use CalcETAHighDense(index, totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must by ticksPerMilliseconds</param>
        /// <returns>The left time to finish iteration. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long? CalcETA(int? index, int? totalIndex, long? totalElapsedTicks, long? frequency)
        {
            // Checking at least one given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (index.HasValue == false || totalIndex.HasValue == false || totalElapsedTicks.HasValue == false || frequency.HasValue == false)
            {
                // Returning null value to indicate one of the given parameters was null.
                return null;
            }

            // Checking if index value or frequency is zero. Index value is a dividor on calculation of avarageElapsedTimeInMs. Frequency value is a dividor on calculation of elapsedSeconds.
            if (index.Value == 0 || frequency == 0)
            {
                // Returning null value to indicate index value or frequency is zero.
                return null;
            }

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - index.Value;

            // Calculating elapsed time with dividing totalElapsedTicks to frequency.
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            //  Calculating avarage elapsed time with dividing totalElapsedTicks to frequency.
            long avarageElapsedTimeInMs = elapsedMilliseconds / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (double) If iteration takes close to one millisecond, use CalcETA(index, totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        /// <returns>The left time to finish iteration in milliseconds. (double)</returns>
        /// <exception cref = "System.DivideByZeroException" > Throws exception if index is zero.</exception>
        public static double? CalcETA(uint? index, uint? totalIndex, TimeSpan? timeSpan)
        {
            // Checking at least one the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (index.HasValue == false || totalIndex.HasValue == false || timeSpan.HasValue == false)
            {
                // Returning null value to indicate one of the given parameters was null.
                return null;
            }

            // Checking if index value is zero. Index value is a dividor on calculation of avarageElapsedTimeInMs.
            if (index.Value == 0)
            {
                // Returning null value to indicate index value is zero.
                return null;
            }

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - index.Value;

            // Getting elapsed time value from timeSpan.TotalMilliseconds.
            double elapsedMilliseconds = timeSpan.Value.TotalMilliseconds;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = elapsedMilliseconds / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (double) If iteration takes close to one millisecond, use CalcETA(index, totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        /// <returns>The left time to finish iteration in milliseconds. (double)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        public static double? CalcETA(int? index, int? totalIndex, TimeSpan? timeSpan)
        {
            // Checking at least one the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (index.HasValue == false || totalIndex.HasValue == false || timeSpan.HasValue == false)
            {
                // Returning null value to indicate one of the given parameters was null.
                return null;
            }

            // Checking if index value is zero. Index value is a dividor on calculation of avarageElapsedTimeInMs.
            if (index.Value == 0)
            {
                // Returning null value to indicate index value is zero.
                return null;
            }

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - index.Value;

            // Getting elapsed time value from timeSpan.TotalMilliseconds.
            double elapsedMilliseconds = timeSpan.Value.TotalMilliseconds;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = elapsedMilliseconds / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (double) If iteration takes close to one millisecond, use CalcETAUnsafe(index, totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        /// <returns>The left time to finish iteration in milliseconds. (double)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        public static double CalcETAUnsafe(uint? index, uint? totalIndex, TimeSpan? timeSpan)
        {
            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - index.Value;

            // Getting elapsed time value from timeSpan.Milliseconds.
            double elapsedMilliseconds = timeSpan.Value.Milliseconds;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = elapsedMilliseconds / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (double) If iteration takes close to one millisecond, use CalcETAUnsafe(index, totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        /// <returns>The left time to finish iteration in milliseconds. (double)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        public static double CalcETAUnsafe(int? index, int? totalIndex, TimeSpan? timeSpan)
        {
            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - index.Value;

            // Getting elapsed time value from timeSpan.TotalMilliseconds.
            double elapsedMilliSeconds = timeSpan.Value.TotalMilliseconds;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = elapsedMilliSeconds / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long) If iteration takes close to one millisecond, use CalcETAUnsafe(index, totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        public static long CalcETAUnsafe(uint? index, uint? totalIndex, long? totalElapsedTimeInMs)
        {
            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - index.Value;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = totalElapsedTimeInMs.Value / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds. (long) If iteration less than one millisecond, use CalcETAHighDenseUnsafe(index, totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>   
        /// <exception cref="System.DivideByZeroException">Throws exception if index or frequency is zero.</exception>
        public static long CalcETAUnsafe(uint? index, uint? totalIndex, long? totalElapsedTicks, long? frequency)
        {
            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - index.Value;

            // Calculating elapsed time with dividing totalElapsedTicks to frequency.
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = elapsedMilliseconds / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long) If iteration takes close to one millisecond, use CalcETAUnsafe(index, totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        public static long CalcETAUnsafe(int? index, int? totalIndex, long? totalElapsedTimeInMs)
        {
            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - index.Value;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = totalElapsedTimeInMs.Value / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds .(long) If iteration less than one millisecond, use CalcETAHighDenseUnsafe(index, totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index or frequency is zero.</exception>
        public static long CalcETAUnsafe(int? index, int? totalIndex, long? totalElapsedTicks, long? frequency)
        {
            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - index.Value;

            // Calculating elapsed time with dividing totalElapsedTicks to frequency.
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = elapsedMilliseconds / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }
    }
}
