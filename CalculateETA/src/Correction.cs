using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculateETA
{
    /// <summary>
    /// Extensions for CalculateETA.
    /// </summary>
    public class Correction
    {
        #region Core

        // List to hold ETA.
        private readonly List<long?> s_etaInLongList = new List<long?>();

        // List to hold ETA.
        private readonly List<double?> s_etaInDoubleList = new List<double?>();

        /// <summary>
        /// Populating private variable that holds eta values.
        /// </summary>
        /// <param name="eta">Value to add.</param>
        /// <returns>Returns false if value was not in the list. Returns true if value was in the list already.</returns>
        private bool PopulateETAList(long? eta)
        {
            // Null check
            if (eta == null)
            {
                // Returning false to indicate value was not used to populate.
                return false;
            }

            // Checking if value already exists in the list.
            if (s_etaInLongList.Contains(eta) == false)
            {
                // Adding value into the list.
                s_etaInLongList.Add(eta);

                // Returning false to indicate value was not used to populate.
                return false;
            }
            else
            {
                // Returning true to indicate value was already in the list.
                return true;
            }
        }

        /// <summary>
        /// Populating private variable that holds eta values.
        /// </summary>
        /// <param name="eta">Value to add.</param>
        /// <returns>Returns false if value was not in the list. Returns true if value was in the list already.</returns>
        private bool PopulateETAList(double? eta)
        {
            // Null check
            if (eta == null)
            {
                // Returning false to indicate value was not used to populate.
                return false;
            }

            // Checking if value already exists in the list.
            if (s_etaInDoubleList.Contains(eta) == false)
            {
                // Adding value into the list.
                s_etaInDoubleList.Add(eta);

                // Returning false to indicate value was not used to populate.
                return false;
            }
            else
            {
                // Returning true to indicate value was already in the list.
                return true;
            }
        }

        // Method to clear saved ETA lists.
        private void ClearList()
        {
            s_etaInLongList?.Clear();
            s_etaInDoubleList?.Clear();
        }

        #endregion Core

        /// <summary>
        /// Prevents surging by checking if value is in the range of previous saved ETA.
        /// </summary>
        /// <param name="eta">Value to check.</param>
        /// <param name="discretePercentage">Double value between 0.00 and 1.00</param>
        /// <returns>Returns the last value in the list of saved ETA if given ETA, was in the range.</returns>
        /// <exception cref="ArgumentException">Throws exception if discretePercentage is not valid.</exception>
        public long? PreventSurgeByPercentage(long? eta, double discretePercentage)
        {
            // Getting last saved ETA from the list.
            long? lastSavedETA = s_etaInLongList.LastOrDefault();

            // Populating ETA list, ignoring return value.
            PopulateETAList(eta: eta);

            // Checking if given paramter is in the list.
            if (discretePercentage > 0 && discretePercentage < 1)
            {
                // Checking if value is between calculated range.
                // For example, with given 0.2 discretePercentage and 15000 eta value and last saved ETA is 17000.
                // If value lower than 12000 (15000 * 0.2 + eta) or greater than 18000 (15000 * 0.2 + eta), it return lastSavedETA instead of given ETA.
                if ((lastSavedETA - lastSavedETA * discretePercentage) > eta || (lastSavedETA + lastSavedETA * discretePercentage) < eta)
                {
                    // Returning last saved ETA from the list.
                    return lastSavedETA;
                }
                else
                {
                    // Returning given value.
                    return eta;
                }
            }
            else
            {
                // Throwing an exception to indicate discretePercentage is not valid.
                throw new ArgumentException("discretePercentage must be between 0.00 and 1.00");
            }
        }

        /// <summary>
        /// Prevents surging by checking if value is in the range of previous saved ETA.
        /// </summary>
        /// <param name="eta">Value to check.</param>
        /// <param name="discretePercentage">Double value between 0.00 and 1.00</param>
        /// <returns>Returns the last value in the list of saved ETA if given ETA, was in the range.</returns>
        /// <exception cref="ArgumentException">Throws exception if discretePercentage is not valid.</exception>
        public double? PreventSurgeByPercentage(double? eta, double discretePercentage)
        {
            // Getting last saved ETA from the list.
            double? lastSavedETA = s_etaInDoubleList.LastOrDefault();

            // Populating ETA list, ignoring return value.
            PopulateETAList(eta: eta);

            // Checking if given paramter is in the list.
            if (discretePercentage > 0 && discretePercentage < 1)
            {
                // Checking if value is between calculated range.
                // For example, with given 0.2 discretePercentage and 15000 eta value and last saved ETA is 17000.
                // If value lower than 12000 (15000 * 0.2 + eta) or greater than 18000 (15000 * 0.2 + eta), it return lastSavedETA instead of given ETA.
                if ((lastSavedETA - lastSavedETA * discretePercentage) > eta || (lastSavedETA + lastSavedETA * discretePercentage) < eta)
                {
                    // Returning last saved ETA from the list.
                    return lastSavedETA;
                }
                else
                {
                    // Returning given value.
                    return eta;
                }
            }
            else
            {
                // Throwing an exception to indicate discretePercentage is not valid.
                throw new ArgumentException("discretePercentage must be between 0.00 and 1.00");
            }
        }

        /// <summary>
        /// Prevents surging by checking if value is in the list of saved ETA.
        /// </summary>
        /// <param name="eta">Value to check.</param>
        /// <returns>Returns </returns>
        public long? PreventSurgeByValueRepeatence(long? eta)
        {
            // Checking if eta is null.
            if (eta == null)
            {
                // Returning last saved eta which could be a value or null.
                return s_etaInLongList.LastOrDefault();
            }

            // Populating ETA list. True value indicated given value was already in the list.
            bool result = PopulateETAList(eta: eta);
            if (result == true)
            {
                // Returning previous saved ETA to prevent surge.
                return s_etaInLongList.LastOrDefault();
            }
            else
            {
                // Returning eta because it wasn't in the saved list.
                return eta;
            }
        }

        /// <summary>
        /// Prevents surging by checking if value is in the list of saved ETA.
        /// </summary>
        /// <param name="eta">Value to check.</param>
        /// <returns>Returns </returns>
        public double? PreventSurgeByValueRepeatence(double? eta)
        {
            // Checking if eta is null.
            if (eta == null)
            {
                // Returning last saved eta which could be a value or null.
                return s_etaInDoubleList.LastOrDefault();
            }

            // Populating ETA list. True value indicated given value was already in the list.
            bool result = PopulateETAList(eta: eta);
            if (result == true)
            {
                // Returning previous saved ETA to prevent surge.
                return s_etaInDoubleList.LastOrDefault();
            }
            else
            {
                // Returning eta because it wasn't in the saved list.
                return eta;
            }
        }
    }
}