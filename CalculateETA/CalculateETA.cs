using System;

namespace CalculateETA
{
    /// <summary>
    /// Calculate the left time to finish current iteration on single-thread and multi-thread applications.
    /// </summary>
    public class CalculateETA
    {
        #region Variables (Multi-Threading)

        // Integer variable that holds total interaction for multi-threading applications. This value should be reset with ResetCounter() after re-use of CalcETA() multi-threading methods.
        private static int counter;

        // Unsigned integer variable that holds total interaction for multi-threading applications. This value should be reset with ResetCounterUint() after re-use of CalcETA() multi-threading methods.
        private static uint counterUint;

        #endregion Variables (Multi-Threading)

        /// <summary>
        /// Returns true if the counter is resetted to zero. Returns false if the counter is already zero. (int methods)
        /// </summary>
        /// <returns>True or false</returns>
        public bool ResetCounter()
        {
            // Checking if the counter is zero.
            if (counter == 0)
            {
                // Returns false indicates that counter was zero already.
                return false;
            }
            else
            {
                // Re-setting the counter value to zero.
                counter = 0;

                // Returns true indicates that re-setting the counter value to zero was successful.
                return true;
            }
        }

        /// <summary>
        /// Returns true if the counter is resetted to zero. Returns false if the counter is already zero. (uint methods)
        /// </summary>
        /// <returns>True or false</returns>
        public bool ResetCounterUint()
        {
            // Checking if the counter is zero.
            if (counterUint == 0)
            {
                // Returns false indicates that counter was zero already.
                return false;
            }
            else
            {
                // Re-setting the counter value to zero.
                counterUint = 0;

                // Returns true indicates that re-setting the counter value to zero is successful.
                return true;
            }
        }

        #region Single-Thread

        #region Safe Methods

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) If iteration takes close to one millisecond, use CalcETA(index, totalIndex, totalElapsedTicks, frequency).
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
        /// [Safe] Returns calculated estimated time to finish iteration on seconds. (long) This method requires addional computational power when it is casting internal variables for calculations. Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequent must be ticksPerMillisecond.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long? CalcETAHighDense(uint? index, uint? totalIndex, long? totalElapsedTicks, long? frequency)
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
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / index.Value;

            // Calculating ETA by multiply avarage time with left count of the iteration.
            double eta = (double)leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
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
        /// [Safe] Returns calculated estimated time to finish iteration on seconds. (long) This method requires addional computational power when it is casting internal variables for calculations. Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequent must be ticksPerMillisecond.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long? CalcETAHighDense(int? index, int? totalIndex, long? totalElapsedTicks, long? frequency)
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
            int leftCount = totalIndex.Value - index.Value;

            // Calculating elapsed time with dividing totalElapsedTicks to frequency. 
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / index.Value;

            // Calculating ETA by multiply avarage time with left count of the iteration.
            double eta = (double)leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
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

        #endregion Safe Methods

        #region Unsafe Methods

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
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long) This method requires addional computational power when it is casting internal variables for calculations.Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>   
        /// <exception cref="System.DivideByZeroException">Throws exception if index or frequency is zero.</exception>
        public static long CalcETAHighDenseUnsafe(uint? index, uint? totalIndex, long? totalElapsedTicks, long? frequency)
        {
            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - index.Value;

            // Calculating elapsed time with dividing totalElapsedTicks to frequency.
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = (double)leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
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

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds. (long) This method requires addional computational power when it is casting internal variables for calculations.Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>   
        /// <exception cref="System.DivideByZeroException">Throws exception if index or frequency is zero.</exception>
        public static long CalcETAHighDenseUnsafe(int? index, int? totalIndex, long? totalElapsedTicks, long? frequency)
        {
            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - index.Value;

            // Calculating elapsed time with dividing totalElapsedTicks to frequency.
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = (double)leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
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

        #endregion Unsafe Methods

        #endregion Single-Thread

        #region Multi-Thread

        #region Safe Methods

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. If iteration takes close to one millisecond, use CalcETA(totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        public static long? CalcETA(uint? totalIndex, long? totalElapsedTimeInMs)
        {
            // Checking parameters for at least one of them is null. This control is not being made for CalcETAUnsafe() method.
            if (totalIndex.HasValue == false || totalElapsedTimeInMs.HasValue == false)
            {
                // Returning null value to indicate that at least one of the given parameter was null.
                return null;
            }

            // Increase counterUint value everytime method is called to determine elapsed/left ratio of the loop. 
            counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - counterUint;

            // Calculating avarage time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = totalElapsedTimeInMs.Value / counterUint;

            // Calculating ETA by multiply elapsed avarage time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations.
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long? CalcETA(uint? totalIndex, long? totalElapsedTicks, long? frequency)
        {
            // Checking at least one of the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (totalIndex.HasValue == false || totalElapsedTicks.HasValue == false || frequency.HasValue == false)
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
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            // Increase counterUint value everytime method is called to determine elapsed/left ratio of the loop.
            counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - counterUint;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = elapsedMilliseconds / counterUint;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. This method requires addional computational power when it is casting internal variables for calculations. Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long? CalcETAHighDense(uint? totalIndex, long? totalElapsedTicks, long? frequency)
        {
            // Checking at least one of the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (totalIndex.HasValue == false || totalElapsedTicks.HasValue == false || frequency.HasValue == false)
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
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            // Increase counterUint value everytime method is called to determine elapsed/left ratio of the loop.
            counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - counterUint;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / counterUint;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = (double)leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
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

            // Increase counterUint value everytime method is called to determine elapsed/left ratio of the loop.
            counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - counterUint;

            // Calculating avarage elapsed time by dividing total time into number of iteration.
            double avarageElapsedTimeInMs = totalMilliseconds / counterUint;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. If iteration takes close to one millisecond, use CalcETA(totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        public static long? CalcETA(int? totalIndex, long? totalElapsedTimeInMs)
        {
            // Checking at least one the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (totalIndex.HasValue == false || totalElapsedTimeInMs.HasValue == false)
            {
                // Returning null value to indicate one of the given parameters was null.
                return null;
            }

            // Increase counter value everytime method is called to determine elapsed/left ratio of the loop.
            counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = totalElapsedTimeInMs.Value / counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations.
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequecny is zero.</exception>
        public static long? CalcETA(int? totalIndex, long? totalElapsedTicks, long? frequency)
        {
            // Checking at least one of the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (totalIndex.HasValue == false || totalElapsedTicks.HasValue == false || frequency.HasValue == false)
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
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            // Increase counter value everytime method is called to determine elapsed/left ratio of the loop.
            counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = elapsedMilliseconds / counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. This method requires addional computational power when it is casting internal variables for calculations. Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequecny is zero.</exception>
        public static long? CalcETAHighDense(int? totalIndex, long? totalElapsedTicks, long? frequency)
        {
            // Checking at least one of the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (totalIndex.HasValue == false || totalElapsedTicks.HasValue == false || frequency.HasValue == false)
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
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            // Increase counter value everytime method is called to determine elapsed/left ratio of the loop.
            counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = (double)leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
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

            // Increase counter value everytime method is called to determine elapsed/left ratio of the loop.
            counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = totalMilliseconds / counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        #endregion Safe Methods

        #region Unsafe Methods

        /// <summary>
        /// [Logically Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. If iteration takes close to one millisecond, use CalcETAUnsafe(totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        public static long CalcETAUnsafe(uint? totalIndex, long? totalElapsedTimeInMs)
        {
            // Increase counterUint value everytime method is called to determine elapsed/left ratio of the loop.
            counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - counterUint;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = totalElapsedTimeInMs.Value / counterUint;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations.
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseond.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long CalcETAUnsafe(uint? totalIndex, long? totalElapsedTicks, long? frequency)
        {
            // Calculating elapsed time with dividing totalElapsedTicks to frequency.
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            // Increase counterUint value everytime method is called to determine elapsed/left ratio of the loop.
            counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - counterUint;

            // Calculating avarage elapsed time by dividing total time into number of iteration.
            long avarageElapsedTimeInMs = elapsedMilliseconds / counterUint;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. This method requires addional computational power when it is casting internal variables for calculations. Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseond.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long CalcETAHighDenseUnsafe(uint? totalIndex, long? totalElapsedTicks, long? frequency)
        {
            // Calculating elapsed time with dividing totalElapsedTicks to frequency.
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            // Increase counterUint value everytime method is called to determine elapsed/left ratio of the loop.
            counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - counterUint;

            // Calculating avarage elapsed time by dividing total time into number of iteration.
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / counterUint;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = (double)leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
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

            // Increase counterUint value everytime method is called to determine elapsed/left ratio of the loop.:
            counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - counterUint;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = totalMilliseconds / counterUint;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Logically Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. If iteration takes close to one millisecond, use CalcETAUnsafe(totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTimeInMs">Elapsed time from starting of the iteration until current iteration on milliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long) </returns>
        public static long CalcETAUnsafe(int? totalIndex, long? totalElapsedTimeInMs)
        {
            // Increase counter value everytime method is called to determine elapsed/left ratio of the loop.
            counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = totalElapsedTimeInMs.Value / counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. If iteration takes close to one millisecond, use CalcETAUnsafe(totalIndex, totalElapsedTicks, frequency).
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long CalcETAUnsafe(int? totalIndex, long? totalElapsedTicks, long? frequency)
        {
            // Calculating elapsed time by diving totalElapsedTicks into frequency.
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            // Increase counter value everytime method is called to determine elapsed/left ratio of the loop.
            counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            long avarageElapsedTimeInMs = elapsedMilliseconds / counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            long eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. This method requires addional computational power when it is casting internal variables for calculations. Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="totalElapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long CalcETAHighDenseUnsafe(int? totalIndex, long? totalElapsedTicks, long? frequency)
        {
            // Calculating elapsed time by diving totalElapsedTicks into frequency.
            long elapsedMilliseconds = totalElapsedTicks.Value / frequency.Value;

            // Increase counter value everytime method is called to determine elapsed/left ratio of the loop.
            counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = (double)leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
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

            // Increase counter value everytime method is called to determine elapsed/left ratio of the loop.
            counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = totalMilliseconds / counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return eta;
        }

        #endregion Unsafe Methods

        #endregion Multi-Thread

        #region Visual Format

        /*  For TimeSpanETA(), NumberFormatETA(), NameETA(), NameETABetterVisual(), TimeSpanETAUnsafe(), NumberFormatETAUnsafe(), NameETAUnsafe() and NameETABetterVisualUnsafe()
         *  TimeSpan has four different options. Int data type has maximum value of 2147483647.
            If etaTimeInMs as int decided to use maximum TimeSpan could be created is ~25 days.
            
            This method use (long) ticks to avoid it with higher precision.

            Using of etaTime parameter as in minute, hour or day will lose precision.

            public TimeSpan(long ticks);
            public TimeSpan(int hours, int minutes, int seconds);
            public TimeSpan(int days, int hours, int minutes, int seconds);
            public TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds);
            */

        #region Safe Methods

        /// <summary>
        /// Returns estimated left time to finish on TimeSpan format.
        /// </summary>
        /// <param name="eTATimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns TimeSpan.Zero if etaTimeInMs is either null or negative. Return TimeSpan format.</returns>
        public static TimeSpan? TimeSpanETA(long? eTATimeInMs)
        {
            // Checking if the given parameter is null.
            if (eTATimeInMs == null)
            {
                // Returning null to indicate the given parameter was null.
                return null;
            }
            // Checking if the given parameter is negative.
            else if (eTATimeInMs < 0)
            {
                // Returning TimeSpan.Zero to indicate the given parameter was negative.
                return TimeSpan.Zero;
            }

            // Returning ETA in TimeSpan.
            return new TimeSpan(ticks: eTATimeInMs.Value * TimeSpan.TicksPerMillisecond);
        }

        /// <summary>
        /// Returns estimated left time to finish on string format. (HH:MM.SS)
        /// </summary>
        /// <param name="eTATimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTimeInMs is null. Returns "Negative" if etaTimeInMs is negative. Returns "Too long" if eTATimeInMs is more than a day. Returns number format. (string)</returns>
        public static string NumberFormatETA(long? eTATimeInMs)
        {
            // Checking if the given parameter is null.
            if (eTATimeInMs == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return "Uncalculatable";
            }
            // Checking if the given parameter is negative.
            else if (eTATimeInMs < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return "Negative";
            }
            // Checking if the given parameter value will result misleading return value. Estimation under 24 hours will return.
            else if (eTATimeInMs > 86400000)
            {
                // Returning "Too long" to indicaate the given parameter value will result estimation more than a day.
                return "Too long";
            }

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: eTATimeInMs.Value * TimeSpan.TicksPerMillisecond);

            // Returning ETA in number format. E.g 05:03:24
            return $"{ts.Hours}:{ts.Minutes}:{ts.Seconds}";
        }

        /// <summary>
        /// Returns estimated time to finish on naming format. (xxx ms or xx second(s) or xx minute(s) and yy (second(s)...) Recommended for high-cpu-intense algorithm
        /// </summary>
        /// <param name="eTATimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTimeInMs is null. Returns "Negative" if etaTimeInMs is negative. Returns string format.</returns>
        public static string NameETA(long? eTATimeInMs)
        {
            // Checking if the given parameter is null.
            if (eTATimeInMs == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return "Uncalculatable";
            }
            // Checking if the given parameter is negative.
            else if (eTATimeInMs < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return "Negative";
            }

            // Checking if the given parameter is lower than one second. This is commented out for better performance.
            //else if (eTATimeInMs < 1000)
            //{
            //    //
            //    return $"{eTATimeInMs:0} ms";
            //}

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: eTATimeInMs.Value * TimeSpan.TicksPerMillisecond);

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as xx second(s).
                return $"{ts.Seconds} second(s)";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as xx minute(s) and yy second(s).
                return $"{ts.Minutes} minute(s) and {ts.Seconds} second(s)";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as xx hours(s) and yy minutes(s).
                return $"{ts.Hours} hour(s) and {ts.Minutes} minute(s)";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as xx days(s) and yy hour(s).
                return $"{ts.Days} day(s) and {ts.Hours} hour(s)";
            }
        }

        /// <summary>
        /// Returns estimated time to finish on naming format. (xxx ms or xx second/seconds or xx minute/minutes and yy (second/seconds...) Recommended for low-cpu-intense algorithm in order to better visual output
        /// </summary>
        /// <param name="eTATimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTimeInMs is null. Returns "Negative" if etaTimeInMs is negative. Returns string format.</returns>
        public static string NameETABetterVisual(long? eTATimeInMs)
        {
            // Checking if the given parameter is null.
            if (eTATimeInMs == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return "Uncalculatable";
            }
            // Checking if the given parameter is negative.
            else if (eTATimeInMs < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return "Negative";
            }

            // Checking if parameter is lower than one second. This is commented out for better performance.
            //else if (eTATimeInMs < 1000)
            //{
            //    //
            //    return $"{eTATimeInMs:0} ms";
            //}

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: eTATimeInMs.Value * TimeSpan.TicksPerMillisecond);

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as x second or yy seconds.
                return $"{ts.Seconds} {(ts.Seconds != 1 ? "seconds" : "second")}";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as x minute or xx minutes, y second or yy seconds.
                return $"{ts.Minutes} {(ts.Minutes != 1 ? "minutes" : "minute")} and {ts.Seconds} {(ts.Seconds != 1 ? "seconds" : "second")}";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as x hour or xx hours and, y minute or yy minutes.
                return $"{ts.Hours} {(ts.Hours != 1 ? "hours" : "hour")} and {ts.Minutes} {(ts.Minutes != 1 ? "minutes" : "minute")}";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as x day or xx days, y hour and yy hours.
                return $"{ts.Days} {(ts.Days != 1 ? "days" : "day")} and {ts.Hours} {(ts.Hours != 1 ? "hours" : "hour")}";
            }
        }

        #endregion Safe Methods

        #region Unsafe Methods

        /// <summary>
        /// Returns estimated left time to finish on TimeSpan format.
        /// </summary>
        /// <param name="eTATimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Return TimeSpan format.</returns>
        public static TimeSpan TimeSpanETAUnsafe(long eTATimeInMs)
        {
            return new TimeSpan(ticks: eTATimeInMs * TimeSpan.TicksPerMillisecond);
        }

        /// <summary>
        /// [Unsafe] Returns estimated left time to finish on string format. (HH:MM.SS)
        /// </summary>
        /// <param name="eTATimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns number format. (string)</returns>
        public static string NumberFormatETAUnsafe(long eTATimeInMs)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: eTATimeInMs * TimeSpan.TicksPerMillisecond);

            // Returning ETA in number format. E.g 05:03:24
            return $"{ts.Hours}:{ts.Minutes}:{ts.Seconds}";
        }

        /// <summary>
        /// [Unsafe] Returns estimated time to finish on naming format. (xxx ms or xx second(s) or xx minute(s) and yy (second(s)...) Recommended for high-cpu-intense algorithm
        /// </summary>
        /// <param name="eTATimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns string format.</returns>
        public static string NameETAUnsafe(long eTATimeInMs)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: eTATimeInMs * TimeSpan.TicksPerMillisecond);

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as xx second(s).
                return $"{ts.Seconds} second(s)";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as xx minute(s) and yy second(s).
                return $"{ts.Minutes} minute(s) and {ts.Seconds} second(s)";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as xx hours(s) and yy minutes(s).
                return $"{ts.Hours} hour(s) and {ts.Minutes} minute(s)";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as xx days(s) and yy hour(s).
                return $"{ts.Days} day(s) and {ts.Hours} hour(s)";
            }
        }

        /// <summary>
        /// [Unsafe] Returns estimated time to finish on naming format. (xxx ms or xx second/seconds or xx minute/minutes and yy (second/seconds...) Recommended for low-cpu-intense algorithm in order to better visual output
        /// </summary>
        /// <param name="eTATimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns string format.</returns>
        public static string NameETABetterVisualUnsafe(long eTATimeInMs)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: eTATimeInMs * TimeSpan.TicksPerMillisecond);

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as x second or yy seconds.
                return $"{ts.Seconds} {(ts.Seconds != 1 ? "seconds" : "second")}";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as x minute or xx minutes, y second or yy seconds.
                return $"{ts.Minutes} {(ts.Minutes != 1 ? "minutes" : "minute")} and {ts.Seconds} {(ts.Seconds != 1 ? "seconds" : "second")}";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as x hour or xx hours and, y minute or yy minutes.
                return $"{ts.Hours} {(ts.Hours != 1 ? "hours" : "hour")} and {ts.Minutes} {(ts.Minutes != 1 ? "minutes" : "minute")}";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as x day or xx days, y hour and yy hours.
                return $"{ts.Days} {(ts.Days != 1 ? "days" : "day")} and {ts.Hours} {(ts.Hours != 1 ? "hours" : "hour")}";
            }
        }

        #endregion Unsafe Methods

        #endregion VisualFormat
    }
}