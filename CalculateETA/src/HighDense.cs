namespace CalculateETA
{
    /// <summary>
    /// Single-thread applications.
    /// </summary>
    public partial class CalculateETA
    {
        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds. (long) This method requires addional computational power when it is casting internal variables for calculations. Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequent must be ticksPerMillisecond.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long? CalcETAHighDense(uint? index, uint? totalIndex, long? elapsedTicks, long? frequency)
        {
            // Checking at least one the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (index.HasValue == false || totalIndex.HasValue == false || elapsedTicks.HasValue == false || frequency.HasValue == false)
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
            long elapsedMilliseconds = elapsedTicks.Value / frequency.Value;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / index.Value;

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
        /// <param name="elapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequent must be ticksPerMillisecond.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if index is zero.</exception>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long? CalcETAHighDense(int? index, int? totalIndex, long? elapsedTicks, long? frequency)
        {
            // Checking at least one the given parameters is null. This control is not being made for CalcETAUnsafe() method.
            if (index.HasValue == false || totalIndex.HasValue == false || elapsedTicks.HasValue == false || frequency.HasValue == false)
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
            long elapsedMilliseconds = elapsedTicks.Value / frequency.Value;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / index.Value;

            // Calculating ETA by multiply avarage time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long) This method requires addional computational power when it is casting internal variables for calculations.Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>   
        /// <exception cref="System.DivideByZeroException">Throws exception if index or frequency is zero.</exception>
        public static long CalcETAHighDenseUnsafe(uint? index, uint? totalIndex, long? elapsedTicks, long? frequency)
        {
            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - index.Value;

            // Calculating elapsed time with dividing totalElapsedTicks to frequency.
            long elapsedMilliseconds = elapsedTicks.Value / frequency.Value;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds. (long) This method requires addional computational power when it is casting internal variables for calculations.Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="index">The index of current iteration. Index must not be zero.</param>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>   
        /// <exception cref="System.DivideByZeroException">Throws exception if index or frequency is zero.</exception>
        public static long CalcETAHighDenseUnsafe(int? index, int? totalIndex, long? elapsedTicks, long? frequency)
        {
            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - index.Value;

            // Calculating elapsed time with dividing totalElapsedTicks to frequency.
            long elapsedMilliseconds = elapsedTicks.Value / frequency.Value;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / index.Value;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
        }
    }

    /// <summary>
    /// Multi-thread applications.
    /// </summary>
    public partial class CalculateETA
    {
        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. This method requires addional computational power when it is casting internal variables for calculations. Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long? CalcETAHighDense(uint? totalIndex, long? elapsedTicks, long? frequency)
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
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / s_counterUint;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
        }

        /// <summary>
        /// [Safe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. This method requires addional computational power when it is casting internal variables for calculations. Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequecny is zero.</exception>
        public static long? CalcETAHighDense(int? totalIndex, long? elapsedTicks, long? frequency)
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
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / s_counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. This method requires addional computational power when it is casting internal variables for calculations. Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseond.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long CalcETAHighDenseUnsafe(uint? totalIndex, long? elapsedTicks, long? frequency)
        {
            // Calculating elapsed time with dividing totalElapsedTicks to frequency.
            long elapsedMilliseconds = elapsedTicks.Value / frequency.Value;

            // Increase s_counterUint value everytime method is called to determine elapsed/left ratio of the loop.
            s_counterUint++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            uint leftCount = totalIndex.Value - s_counterUint;

            // Calculating avarage elapsed time by dividing total time into number of iteration.
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / s_counterUint;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
        }

        /// <summary>
        /// [Unsafe] Returns calculated estimated time to finish iteration on seconds (long) on Multi-Threading iterations. This method requires addional computational power when it is casting internal variables for calculations. Use this method if iteration has been made under one millisecond.
        /// </summary>
        /// <param name="totalIndex">Total index of iteration.</param>
        /// <param name="elapsedTicks">Elapsed ticks from starting of the iteration until current iteration on ticks.</param>
        /// <param name="frequency">The frequency of tick. Frequency must not be zero. Frequency must be ticksPerMilliseconds.</param>
        /// <returns>The left time to finish iteration in milliseconds. (long)</returns>
        /// <exception cref="System.DivideByZeroException">Throws exception if frequency is zero.</exception>
        public static long CalcETAHighDenseUnsafe(int? totalIndex, long? elapsedTicks, long? frequency)
        {
            // Calculating elapsed time by diving totalElapsedTicks into frequency.
            long elapsedMilliseconds = elapsedTicks.Value / frequency.Value;

            // Increase s_counter value everytime method is called to determine elapsed/left ratio of the loop.
            s_counter++;

            // Calculating leftCount by last Index of the iteration and current index of the iteration.
            int leftCount = totalIndex.Value - s_counter;

            // Calculating avarage elapsed time by dividing total time into number of the iteration.
            double avarageElapsedTimeInMs = (double)elapsedMilliseconds / s_counter;

            // Calculating ETA by multiply avarage elapsed time with left count of the iteration.
            double eta = leftCount * avarageElapsedTimeInMs;

            // Returning ETA in milliseconds.
            return (long)eta;
        }
    }
}