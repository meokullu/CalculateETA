using System.Collections.Generic;

namespace CalculateETA
{
    /// <summary>
    /// Reporing module have features to save data.
    /// </summary>
    public class Reporting
    {
        // List for calculations in double data type.
        private readonly List<double?> s_etaInDoubleListToReport = new List<double?>();

        // List for calculations in long data type.
        private readonly List<long?> s_etaInLongListToReport = new List<long?>();

        /// <summary>
        /// Adds calculated ETA time into a list.
        /// </summary>
        /// <param name="eta">Calculated ETA time to add into the list.</param>
        /// <returns>Long value.</returns>
        public void AddReport(long? eta)
        {
            // Adding into the list.
            s_etaInLongListToReport.Add(eta);
        }

        /// <summary>
        /// Adds calculated ETA time into a list.
        /// </summary>
        /// <param name="eta">Calculated ETA time to add into the list.</param>
        /// <returns>Double value.</returns>
        public void AddReport(double? eta)
        {
            // Adding into the list.
            s_etaInDoubleListToReport.Add(eta);
        }

        /// <summary>
        /// Returns filled list by AddReport() in certain data type.
        /// </summary>
        /// <returns>Array of long values.</returns>
        public long?[] GetLongListReport()
        {
            // Transforming filled list into an array and returns it.
            return s_etaInLongListToReport.ToArray();
        }

        /// <summary>
        /// Returns filled list by AddReport() in certain data type.
        /// </summary>
        /// <returns>Array of double values.</returns>
        public double?[] GetDoubleListReport()
        {
            // Transforming filled list into an array and returns it.
            return s_etaInDoubleListToReport.ToArray();
        }

        /// <summary>
        /// Clear list that holds eta values in long data type.
        /// </summary>
        public void ClearListInLong()
        {
            s_etaInLongListToReport.Clear();
        }

        /// <summary>
        /// Clear list that holds eta values in double data type.
        /// </summary>
        public void ClearListInDouble()
        {
            s_etaInDoubleListToReport.Clear();
        }

        /// <summary>
        /// Get count of list in double type type.
        /// </summary>
        /// <returns>List count.</returns>
        public int GetCountListInLong()
        {
            return s_etaInLongListToReport.Count;
        }

        /// <summary>
        /// Get count of list in double type type.
        /// </summary>
        /// <returns>List count.</returns>
        public int GetCountListInDouble()
        {
            return s_etaInDoubleListToReport.Count;
        }
    }
}
