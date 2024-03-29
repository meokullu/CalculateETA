﻿using System.Collections.Generic;

namespace CalculateETA
{
    /// <summary>
    /// Reporing module have features to save data.
    /// </summary>
    public static class Report
    {
        // List for calculations in double data type.
        private static readonly List<double?> s_etaInDoubleListToReport = new List<double?>();

        // List for calculations in long data type.
        private static readonly List<long?> s_etaInLongListToReport = new List<long?>();

        /// <summary>
        /// Adds calculated ETA time into a list.
        /// </summary>
        /// <param name="etaTime">Calculated ETA time to add into the list.</param>
        /// <returns>Long value.</returns>
        public static long? AddReport(this long? etaTime)
        {
            // Adding into the list.
            s_etaInLongListToReport.Add(etaTime);

            // Returning value without change.
            return etaTime;
        }

        /// <summary>
        /// Adds calculated ETA time into a list.
        /// </summary>
        /// <param name="etaTime">Calculated ETA time to add into the list.</param>
        /// <returns>Double value.</returns>
        public static double? AddReport(this double? etaTime)
        {
            // Adding into the list.
            s_etaInDoubleListToReport.Add(etaTime);

            // Returning value without change.
            return etaTime;
        }

        /// <summary>
        /// Returns filled list by AddReport() in certain data type.
        /// </summary>
        /// <returns>Array of double values.</returns>
        public static double?[] GetDoubleListReport()
        {
            // Transforming filled list into an array and returns it.
            return s_etaInDoubleListToReport.ToArray();
        }

        /// <summary>
        /// Returns filled list by AddReport() in certain data type.
        /// </summary>
        /// <returns>Array of long values.</returns>
        public static long?[] GetLongListReport()
        {
            // Transforming filled list into an array and returns it.
            return s_etaInLongListToReport.ToArray();
        }

        /// <summary>
        /// Clear list that holds eta values in double data type.
        /// </summary>
        public static void ClearListInDouble()
        {
            s_etaInDoubleListToReport.Clear();
        }

        /// <summary>
        /// Clear list that holds eta values in long data type.
        /// </summary>
        public static void ClearListInLong()
        {
            s_etaInLongListToReport.Clear();
        }

        /// <summary>
        /// Get count of list in double type type.
        /// </summary>
        /// <returns>List count.</returns>
        public static int GetCountListInDouble()
        {
            return s_etaInDoubleListToReport.Count;
        }

        /// <summary>
        /// Get count of list in double type type.
        /// </summary>
        /// <returns>List count.</returns>
        public static int GetCountListInLong()
        {
            return s_etaInLongListToReport.Count;
        }
    }
}
