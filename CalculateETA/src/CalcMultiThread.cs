using System;

namespace CalculateETA
{
    /// <summary>
    /// Multi-Thread
    /// </summary>
    public partial class CalculateETA
    {
        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. If iteration takes close to one millisecond, use CalcETA(totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsed">Elapsed time from starting of the iteration until current iteration on milliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        public static long? CalcETA(uint? totalIndex, long? elapsed)
        {
            // Checking parameters for at least one of them is null. This control is not being made for CalcETAUnsafe() method.
            if (totalIndex.HasValue == false || elapsed.HasValue == false)
            {
                // Returning null value to indicate that at least one of the given parameter was null.
                return null;
            }

            // Increase s_counterUint value everytime method is called to determine elapsed/left ratio of the loop. 
            s_counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - s_counterUint;

            // Calculating avarage time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = elapsed.Value / s_counterUint;

            // Calculating ETA by multiply elapsed avarage time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations.
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long? CalcETA(uint? totalIndex, long? elapsedTicks, long? frequency)
        {
            // Checking at least one of the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (totalIndex.HasValue == false || elapsedTicks.HasValue == false || frequency.HasValue == false)
            {
                // Returning null value to indicate one of the given parameters was null.
                return null;
            }

            // Checking if index value is zero. Frequency value is a dividor on calculation of elapsedSeconds.
            if (frequency.Value == 0)
            {
                // Returning null value to indicate frequency value is zero.
                return null;
            }

            // Calculating elapsed time with dividing totalElapsedTicks to frequency.
            long elapsedMilliseconds = elapsedTicks.Value / frequency.Value;

            // Increase s_counterUint value everytime method is called to determine elapsed/left ratio of the loop.
            s_counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - s_counterUint;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = elapsedMilliseconds / s_counterUint;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. If iteration takes close to one millisecond, use CalcETA(totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsed">Elapsed time from starting of the iteration until current iteration on milliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        public static long? CalcETA(int? totalIndex, long? elapsed)
        {
            // Checking at least one the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (totalIndex.HasValue == false || elapsed.HasValue == false)
            {
                // Returning null value to indicate one of the given parameters was null.
                return null;
            }

            // Increase s_counter value everytime method is called to determine elapsed/left ratio of the loop.
            s_counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - s_counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = elapsed.Value / s_counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations.
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequecny is zero.</exception>
        public static long? CalcETA(int? totalIndex, long? elapsedTicks, long? frequency)
        {
            // Checking at least one of the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (totalIndex.HasValue == false || elapsedTicks.HasValue == false || frequency.HasValue == false)
            {
                // Returning null value to indicate one of the given parameters was null.
                return null;
            }

            // Checking if frequency is zero. Frequency value is a dividor on calculation of elapsedSeconds.
            if (frequency == 0)
            {
                // Returning null value to indicate index value or frequency is zero.
                return null;
            }

            // Calculating elapsed time with dividing totalElapsedTicks to tickFrequency.
            long elapsedMilliseconds = elapsedTicks.Value / frequency.Value;

            // Increase s_counter value everytime method is called to determine elapsed/left ratio of the loop.
            s_counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - s_counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = elapsedMilliseconds / s_counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (double) on Multi-Threading iterations. If iteration takes close to one millisecond, use CalcETA(totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        /// <returns>The left time to finish iteration in milliseconds. (double)</returns>
        public static double? CalcETA(uint? totalIndex, TimeSpan? timeSpan)
        {
            // Checking at least one the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (totalIndex.HasValue == false || timeSpan.HasValue == false)
            {
                // Returning null value to indicate one of the given parameters was null.
                return null;
            }

            // Getting totalMilliseconds value from timeSpan.TotalMilliseconds.
            double totalMilliseconds = timeSpan.Value.TotalMilliseconds;

            // Increase s_counterUint value everytime method is called to determine elapsed/left ratio of the loop.
            s_counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - s_counterUint;

            // Calculating avarage elapsed time by dividing total time into number of iteration.
            double avarageElapsedTimeInMs = totalMilliseconds / s_counterUint;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (double) on Multi-Threading iterations. If iteration takes close to one millisecond, use CalcETA(totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        /// <returns>The left time to finish iteration in milliseconds. (double)</returns>
        public static double? CalcETA(int? totalIndex, TimeSpan? timeSpan)
        {
            // Checking at least one the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (totalIndex.HasValue == false || timeSpan.HasValue == false)
            {
                // Returning null value to indicate one of the given parameters was null.
                return null;
            }

            // Getting totalMilliseconds value from timeSpan.TotalMilliseconds.
            double totalMilliseconds = timeSpan.Value.TotalMilliseconds;

            // Increase s_counter value everytime method is called to determine elapsed/left ratio of the loop.
            s_counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - s_counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = totalMilliseconds / s_counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Logically Unsafe] Returns calculated estimated time to finish iteration on seconds (double) on Multi-Threading iterations. If iteration takes close to one millisecond, use CalcETAUnsafe(totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        /// <returns>The left time to finish iteration in milliseconds. (double)</returns>
        public static double CalcETAUnsafe(uint? totalIndex, TimeSpan? timeSpan)
        {
            // Get totalMilliseconds from TimeSpan formatted parameter.
            double totalMilliseconds = timeSpan.Value.TotalMilliseconds;

            // Increase s_counterUint value everytime method is called to determine elapsed/left ratio of the loop.:
            s_counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - s_counterUint;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = totalMilliseconds / s_counterUint;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Logically Unsafe] Returns calculated estimated time to finish iteration on seconds (double) on Multi-Threading iterations. If iteration takes close to one millisecond, use CalcETAUnsafe(totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="timeSpan">Elapsed time from starting of the iteration until current iteration on TimeSpan format</param>
        /// <returns>The left time to finish iteration in milliseconds. (double)</returns>
        public static double CalcETAUnsafe(int? totalIndex, TimeSpan? timeSpan)
        {
            // Get totalMilliseconds from TimeSpan formatted parameter.
            double totalMilliseconds = timeSpan.Value.TotalMilliseconds;

            // Increase s_counter value everytime method is called to determine elapsed/left ratio of the loop.
            s_counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - s_counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = totalMilliseconds / s_counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Logically Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. If iteration takes close to one millisecond, use CalcETAUnsafe(totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsed">Elapsed time from starting of the iteration until current iteration on milliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        public static long CalcETAUnsafe(uint? totalIndex, long? elapsed)
        {
            // Increase s_counterUint value everytime method is called to determine elapsed/left ratio of the loop.
            s_counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - s_counterUint;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = elapsed.Value / s_counterUint;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations.
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseond.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long CalcETAUnsafe(uint? totalIndex, long? elapsedTicks, long? frequency)
        {
            // Calculating elapsed time with dividing totalElapsedTicks to frequency.
            long elapsedMilliseconds = elapsedTicks.Value / frequency.Value;

            // Increase s_counterUint value everytime method is called to determine elapsed/left ratio of the loop.
            s_counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - s_counterUint;

            // Calculating avarage elapsed time by dividing total time into number of iteration.
            long avarageElapsedTimeInMs = elapsedMilliseconds / s_counterUint;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Logically Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. If iteration takes close to one millisecond, use CalcETAUnsafe(totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsed">Elapsed time from starting of the iteration until current iteration on milliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long) </returns>
        public static long CalcETAUnsafe(int? totalIndex, long? elapsed)
        {
            // Increase s_counter value everytime method is called to determine elapsed/left ratio of the loop.
            s_counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - s_counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = elapsed.Value / s_counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. If iteration takes close to one millisecond, use CalcETAUnsafe(totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long CalcETAUnsafe(int? totalIndex, long? elapsedTicks, long? frequency)
        {
            // Calculating elapsed time by diving totalElapsedTicks into frequency.
            long elapsedMilliseconds = elapsedTicks.Value / frequency.Value;

            // Increase s_counter value everytime method is called to determine elapsed/left ratio of the loop.
            s_counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - s_counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = elapsedMilliseconds / s_counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }
    }
}
