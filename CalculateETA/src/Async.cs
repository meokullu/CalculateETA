using System.Threading.Tasks;

namespace CalculateETA
{
    public partial class CalculateETA
    {
        /// <summary>
        /// Calling <see cref="CalcETA(int?, int?, long?)"/> method with Task.Run().
        /// </summary>
        public static async Task<long?> CalcETAAsync(int? index, int totalIndex, long? elapsed)
        {
            // Calling method with provided values with Task.Run().
            return await Task.Run(() => CalcETA(index: index, totalIndex: totalIndex, elapsed: elapsed));
        }

        /// <summary>
        /// Calling <see cref="CalcETA(int?, long?)"/> method with Task.Run().
        /// </summary>
        public static async Task<long?> CalcETAAsync(int? totalIndex, long? elapsed)
        {
            // Calling method with provided values with Task.Run().
            return await Task.Run(() => CalcETA(totalIndex, elapsed));
        }

        /// <summary>
        /// Calling <see cref="NameETA(long?)"/> method with Task.Run()
        /// </summary>
        public static async Task<string> NameETAAsync(long? eta)
        {
            // Calling method with provided values with Task.Run().
            return await Task.Run(() => NameETA(eta: eta));
        }
    }
}
