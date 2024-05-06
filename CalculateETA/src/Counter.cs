namespace CalculateETA
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CalculateETA
    {
        #region Variables

        // Unsigned integer variable that holds total interaction for multi-threading applications. This value should be reset with ResetCounterUint() after re-use of CalcETA() multi-threading methods.
        private static uint s_counterUint;

        // Integer variable that holds total interaction for multi-threading applications. This value should be reset with ResetCounter() after re-use of CalcETA() multi-threading methods.
        private static int s_counter;

        #endregion Variables

        #region Reset Counters

        /// <summary>
        /// Returns true if the counter is resetted to zero. Returns false if the counter is already zero. (uint methods)
        /// </summary>
        /// <returns>True or false</returns>
        public static bool ResetCounterUint()
        {
            // Checking if the counter is zero.
            if (s_counterUint == 0)
            {
                // Returns false indicates that counter was zero already.
                return false;
            }
            else
            {
                // Re-setting the counter value to zero.
                s_counterUint = 0;

                // Returns true indicates that re-setting the counter value to zero is successful.
                return true;
            }
        }

        /// <summary>
        /// Returns true if the counter is resetted to zero. Returns false if the counter is already zero. (int methods)
        /// </summary>
        /// <returns>True or false</returns>
        public static bool ResetCounter()
        {
            // Checking if the counter is zero.
            if (s_counter == 0)
            {
                // Returns false indicates that counter was zero already.
                return false;
            }
            else
            {
                // Re-setting the counter value to zero.
                s_counter = 0;

                // Returns true indicates that re-setting the counter value to zero was successful.
                return true;
            }
        }

        #endregion ResetCounter
    }
}
