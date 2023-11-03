using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateETA
{
    public partial class CalculateETA
    {
        /// <summary>
        /// Calling <see cref="CalcETA(int?, int?, long?)"/> method with Task.Run().
        /// </summary>
        public static async Task<long?> CalcETAAsync(int? index, int totalIndex, long? totalElapsedTimeInMs)
        {
            // Calling method with provided values with Task.Run().
            return await Task.Run(() => CalcETA(index: index, totalIndex: totalIndex, totalElapsedTimeInMs: totalElapsedTimeInMs));
        }

        /// <summary>
        /// Calling <see cref="CalcETA(int?, long?)"/> method with Task.Run().
        /// </summary>
        public static async Task<long?> CalcETAAsync(int? totalIndex, long? totalElapsedTime)
        {
            // Calling method with provided values with Task.Run().
            return await Task.Run(() => CalcETA(totalIndex, totalElapsedTime));
        }

        /// <summary>
        /// Calling <see cref="NameETA(long?)"/> method with Task.Run()
        /// </summary>
        public static async Task<string> NameETAAsync(long? etaTimeInMs)
        {
            // Calling method with provided values with Task.Run().
            return await Task.Run(() => NameETA(etaTimeInMs: etaTimeInMs));
        }
    }
}
