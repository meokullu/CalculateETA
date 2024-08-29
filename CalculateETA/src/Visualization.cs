using System;
using static CalculateETA.CalculateETA.TextMessage;

namespace CalculateETA
{
    /// <summary>
    /// Common output formatting
    /// </summary>
    public partial class CalculateETA
    {
        #region Visual Format

        // TimeSpan has five different constructors. See here: https://learn.microsoft.com/en-us/dotnet/api/system.timespan.-ctor?view=net-7.0
        // 
        // public TimeSpan(long ticks);
        // public TimeSpan(int hours, int minutes, int seconds);
        // public TimeSpan(int days, int hours, int minutes, int seconds);
        // public TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds);
        // public TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds, int milliseconds);
        //
        // Int32 data type has maximum value of 2147483647. https://learn.microsoft.com/en-us/dotnet/api/system.int32?view=net-7.0
        //
        // If etaTimeInMs as int decided to use for constructing TimeSpan, longest TimeSpan will be around ~25 days.
        // To avoid this limit and for increase precision only TimeSpan(long: ticks) constructor is used.
        //
        // TimeSpanETA(), NumberFormatETA(), NameETA(), NameETABetterVisual(), TimeSpanETAUnsafe(), NumberFormatETAUnsafe(), NameETAUnsafe() and NameETABetterVisualUnsafe() methods use TimeSpan(long: ticks) constructor.

        /// <summary>
        /// Returns estimated time to finish on naming format. (xxx ms or xx second(s) or xx minute(s) and yy (second(s)...) Recommended for high-cpu-intense algorithm
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if eta is null. Returns "Negative" if eta is negative. Returns string format.</returns>
        public static string NameETA(long? eta)
        {
            // Checking if the given parameter is null.
            if (eta == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return TextUncalculatable;
            }
            // Checking if the given parameter is negative.
            else if (eta < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return TextNegative;
            }

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: eta.Value * TimeSpan.TicksPerMillisecond);

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as xx second(s).
                return $"{ts.Seconds}{TextSecondOptionalPlural}";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as xx minute(s) and yy second(s).
                return $"{ts.Minutes}{TextMinuteOptionalPlural}{TextAnd}{ts.Seconds}{TextSecondOptionalPlural}";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as xx hours(s) and yy minutes(s).
                return $"{ts.Hours}{TextHourOptionalPlural}{TextAnd}{ts.Minutes}{TextMinuteOptionalPlural}";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as xx days(s) and yy hour(s).
                return $"{ts.Days}{TextDayOptionalPlural}{TextAnd}{ts.Hours}{TextHourOptionalPlural}";
            }
        }

        /// <summary>
        /// Returns estimated time to finish on naming format. (xxx ms or xx second(s) or xx minute(s) and yy (second(s)...) Recommended for high-cpu-intense algorithm
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTime is null. Returns "Negative" if etaTime is negative. Returns string format.</returns>
        public static string NameETA(double? eta)
        {
            // Checking if the given parameter is null.
            if (eta == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return TextUncalculatable;
            }
            // Checking if the given parameter is negative.
            else if (eta < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return TextNegative;
            }

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: (long)(eta.Value * TimeSpan.TicksPerMillisecond));

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as xx second(s).
                return $"{ts.Seconds}{TextSecondOptionalPlural}";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as xx minute(s) and yy second(s).
                return $"{ts.Minutes}{TextMinuteOptionalPlural}{TextAnd}{ts.Seconds}{TextSecondOptionalPlural}";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as xx hours(s) and yy minutes(s).
                return $"{ts.Hours}{TextHourOptionalPlural}{TextAnd}{ts.Minutes}{TextMinuteOptionalPlural}";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as xx days(s) and yy hour(s).
                return $"{ts.Days}{TextDayOptionalPlural}{TextAnd}{ts.Hours}{TextHourOptionalPlural}";
            }
        }

        /// <summary>
        /// [Unsafe] Returns estimated time to finish on naming format. (xxx ms or xx second(s) or xx minute(s) and yy (second(s)...) Recommended for high-cpu-intense algorithm
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Returns string format.</returns>
        public static string NameETAUnsafe(long eta)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: eta * TimeSpan.TicksPerMillisecond);

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as xx second(s).
                return $"{ts.Seconds}{TextSecondOptionalPlural}";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as xx minute(s) and yy second(s).
                return $"{ts.Minutes}{TextMinuteOptionalPlural}{TextAnd}{ts.Seconds}{TextSecondOptionalPlural}";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as xx hours(s) and yy minutes(s).
                return $"{ts.Hours}{TextHourOptionalPlural}{TextAnd}{ts.Minutes}{TextMinuteOptionalPlural}";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as xx days(s) and yy hour(s).
                return $"{ts.Days}{TextDayOptionalPlural}{TextAnd}{ts.Hours}{TextHourOptionalPlural}";
            }
        }

        /// <summary>
        /// [Unsafe] Returns estimated time to finish on naming format. (xxx ms or xx second(s) or xx minute(s) and yy (second(s)...) Recommended for high-cpu-intense algorithm
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Returns string format.</returns>
        public static string NameETAUnsafe(double eta)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: (long)(eta * TimeSpan.TicksPerMillisecond));

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as xx second(s).
                return $"{ts.Seconds}{TextSecondOptionalPlural}";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as xx minute(s) and yy second(s).
                return $"{ts.Minutes}{TextMinuteOptionalPlural}{TextAnd}{ts.Seconds}{TextSecondOptionalPlural}";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as xx hours(s) and yy minutes(s).
                return $"{ts.Hours}{TextHourOptionalPlural}{TextAnd}{ts.Minutes}{TextMinuteOptionalPlural}";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as xx days(s) and yy hour(s).
                return $"{ts.Days}{TextDayOptionalPlural}{TextAnd}{ts.Hours}{TextHourOptionalPlural}";
            }
        }

        /// <summary>
        /// Returns estimated time to finish on naming format. (xxx ms or xx second/seconds or xx minute/minutes and yy (second/seconds...) Recommended for low-cpu-intense algorithm in order to better visual output
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTimeInMs is null. Returns "Negative" if etaTimeInMs is negative. Returns string format.</returns>
        public static string NameETABetterVisual(long? eta)
        {
            // Checking if the given parameter is null.
            if (eta == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return TextUncalculatable;
            }
            // Checking if the given parameter is negative.
            else if (eta < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return TextNegative;
            }

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: eta.Value * TimeSpan.TicksPerMillisecond);

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as x second or yy seconds.
                return $"{ts.Seconds}{(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as x minute or xx minutes, y second or yy seconds.
                return $"{ts.Minutes}{(ts.Minutes != 1 ? TextMinutes : TextMinute)}{TextAnd}{ts.Seconds}{(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as x hour or xx hours and, y minute or yy minutes.
                return $"{ts.Hours}{(ts.Hours != 1 ? TextHours : TextHour)}{TextAnd}{ts.Minutes}{(ts.Minutes != 1 ? TextMinutes : TextMinute)}";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as x day or xx days, y hour and yy hours.
                return $"{ts.Days}{(ts.Days != 1 ? TextDays : TextDay)}{TextAnd}{ts.Hours}{(ts.Hours != 1 ? TextHours : TextHour)}";
            }
        }

        /// <summary>
        /// Returns estimated time to finish on naming format. (xxx ms or xx second/seconds or xx minute/minutes and yy (second/seconds...) Recommended for low-cpu-intense algorithm in order to better visual output
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTime is null. Returns "Negative" if etaTime is negative. Returns string format.</returns>
        public static string NameETABetterVisual(double? eta)
        {
            // Checking if the given parameter is null.
            if (eta == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return TextUncalculatable;
            }
            // Checking if the given parameter is negative.
            else if (eta < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return TextNegative;
            }

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: (long)(eta.Value * TimeSpan.TicksPerMillisecond));

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as x second or yy seconds.
                return $"{ts.Seconds}{(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as x minute or xx minutes, y second or yy seconds.
                return $"{ts.Minutes}{(ts.Minutes != 1 ? TextMinutes : TextMinute)}{TextAnd}{ts.Seconds}{(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as x hour or xx hours and, y minute or yy minutes.
                return $"{ts.Hours}{(ts.Hours != 1 ? TextHours : TextHour)}{TextAnd}{ts.Minutes}{(ts.Minutes != 1 ? TextMinutes : TextMinute)}";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as x day or xx days, y hour and yy hours.
                return $"{ts.Days}{(ts.Days != 1 ? TextDays : TextDay)}{TextAnd}{ts.Hours}{(ts.Hours != 1 ? TextHours : TextHour)}";
            }
        }

        /// <summary>
        /// [Unsafe] Returns estimated time to finish on naming format. (xxx ms or xx second/seconds or xx minute/minutes and yy (second/seconds...) Recommended for low-cpu-intense algorithm in order to better visual output
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Returns string format.</returns>
        public static string NameETABetterVisualUnsafe(long eta)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: eta * TimeSpan.TicksPerMillisecond);

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as x second or yy seconds.
                return $"{ts.Seconds}{(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as x minute or xx minutes, y second or yy seconds.
                return $"{ts.Minutes}{(ts.Minutes != 1 ? TextMinutes : TextMinute)}{TextAnd}{ts.Seconds}{(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as x hour or xx hours and, y minute or yy minutes.
                return $"{ts.Hours}{(ts.Hours != 1 ? TextHours : TextHour)}{TextAnd}{ts.Minutes}{(ts.Minutes != 1 ? TextMinutes : TextMinute)}";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as x day or xx days, y hour and yy hours.
                return $"{ts.Days}{(ts.Days != 1 ? TextDays : TextDay)}{TextAnd}{ts.Hours}{(ts.Hours != 1 ? TextHours : TextHour)}";
            }
        }

        /// <summary>
        /// [Unsafe] Returns estimated time to finish on naming format. (xxx ms or xx second/seconds or xx minute/minutes and yy (second/seconds...) Recommended for low-cpu-intense algorithm in order to better visual output
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        public static string NameETABetterVisualUnsafe(double eta)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: (long)(eta * TimeSpan.TicksPerMillisecond));

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as x second or yy seconds.
                return $"{ts.Seconds}{(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as x minute or xx minutes, y second or yy seconds.
                return $"{ts.Minutes}{(ts.Minutes != 1 ? TextMinutes : TextMinute)}{TextAnd}{ts.Seconds}{(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as x hour or xx hours and, y minute or yy minutes.
                return $"{ts.Hours}{(ts.Hours != 1 ? TextHours : TextHour)}{TextAnd}{ts.Minutes}{(ts.Minutes != 1 ? TextMinutes : TextMinute)}";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as x day or xx days, y hour and yy hours.
                return $"{ts.Days}{(ts.Days != 1 ? TextDays : TextDay)}{TextAnd}{ts.Hours}{(ts.Hours != 1 ? TextHours : TextHour)}";
            }
        }

        /// <summary>
        /// Returns estimated left time to finish on string format. (HH:MM.SS)
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTimeInMs is null. Returns "Negative" if etaTimeInMs is negative. Returns "Too long" if etaTimeInMs is more than a day. Returns number format. (string)</returns>
        public static string NumberFormatETA(long? eta)
        {
            // Checking if the given parameter is null.
            if (eta == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return TextUncalculatable;
            }
            // Checking if the given parameter is negative.
            else if (eta < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return TextNegative;
            }
            // Checking if the given parameter value will result misleading return value. Estimation under 24 hours will return.
            else if (eta > 86400000)
            {
                // Returning "Too long" to indicaate the given parameter value will result estimation more than a day.
                return TextTooLong;
            }

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: eta.Value * TimeSpan.TicksPerMillisecond);

            // Returning ETA in number format. E.g 05:03:24
            return $"{ts.Hours}{TextNumberFormatSeparator}{ts.Minutes}{TextNumberFormatSeparator}{ts.Seconds}";
        }

        /// <summary>
        /// Returns estimated left time to finish on string format. (HH:MM.SS)
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTime is null. Returns "Negative" if etaTime is negative. Returns "Too long" if etaTimeInMs is more than a day. Returns number format. (string)</returns>
        public static string NumberFormatETA(double? eta)
        {
            // Checking if the given parameter is null.
            if (eta == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return TextUncalculatable;
            }
            // Checking if the given parameter is negative.
            else if (eta < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return TextNegative;
            }
            // Checking if the given parameter value will result misleading return value. Estimation under 24 hours will return.
            else if (eta > 86400000)
            {
                // Returning "Too long" to indicaate the given parameter value will result estimation more than a day.
                return TextTooLong;
            }

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: (long)(eta.Value * TimeSpan.TicksPerMillisecond));

            // Returning ETA in number format. E.g 05:03:24
            return $"{ts.Hours}{TextNumberFormatSeparator}{ts.Minutes}{TextNumberFormatSeparator}{ts.Seconds}";
        }

        /// <summary>
        /// [Unsafe] Returns estimated left time to finish on string format. (HH:MM.SS)
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Returns number format. (string)</returns>
        public static string NumberFormatETAUnsafe(long eta)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: eta * TimeSpan.TicksPerMillisecond);

            // Returning ETA in number format. E.g 05:03:24
            return $"{ts.Hours}{TextNumberFormatSeparator}{ts.Minutes}{TextNumberFormatSeparator}{ts.Seconds}";
        }

        /// <summary>
        /// [Unsafe] Returns estimated left time to finish on string format. (HH:MM.SS)
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Returns number format. (string)</returns>
        public static string NumberFormatETAUnsafe(double eta)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: (long)(eta * TimeSpan.TicksPerMillisecond));

            // Returning ETA in number format. E.g 05:03:24
            return $"{ts.Hours}{TextNumberFormatSeparator}{ts.Minutes}{TextNumberFormatSeparator}{ts.Seconds}";
        }

        /// <summary>
        /// Returns estimated left time to finish on TimeSpan format.
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Returns TimeSpan.Zero if etaTimeInMs is either null or negative. Return TimeSpan format.</returns>
        public static TimeSpan? TimeSpanETA(long? eta)
        {
            // Checking if the given parameter is null.
            if (eta == null)
            {
                // Returning null to indicate the given parameter was null.
                return null;
            }
            // Checking if the given parameter is negative.
            else if (eta < 0)
            {
                // Returning TimeSpan.Zero to indicate the given parameter was negative.
                return TimeSpan.Zero;
            }

            // Returning ETA in TimeSpan.
            return new TimeSpan(ticks: eta.Value * TimeSpan.TicksPerMillisecond);
        }

        /// <summary>
        /// Returns estimated left time to finish on TimeSpan format.
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Returns TimeSpan.Zero if etaTime is either null or negative. Return TimeSpan format.</returns>
        public static TimeSpan? TimeSpanETA(double? eta)
        {
            // Checking if the given parameter is null.
            if (eta == null)
            {
                // Returning null to indicate the given parameter was null.
                return null;
            }
            // Checking if the given parameter is negative.
            else if (eta < 0)
            {
                // Returning TimeSpan.Zero to indicate the given parameter was negative.
                return TimeSpan.Zero;
            }

            // Returning ETA in TimeSpan.
            return new TimeSpan(ticks: (long)(eta.Value * TimeSpan.TicksPerMillisecond));
        }

        /// <summary>
        /// Returns estimated left time to finish on TimeSpan format.
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Return TimeSpan format.</returns>
        public static TimeSpan TimeSpanETAUnsafe(long eta)
        {
            // Returning Timespan created by parameter changed into ticks.
            return new TimeSpan(ticks: eta * TimeSpan.TicksPerMillisecond);
        }

        /// <summary>
        /// Returns estimated left time to finish on TimeSpan format.
        /// </summary>
        /// <param name="eta">The left time to finish. (milliseconds)</param>
        /// <returns>Return TimeSpan format.</returns>
        public static TimeSpan TimeSpanETAUnsafe(double eta)
        {
            // Returning Timespan created by parameter changed into ticks.
            return new TimeSpan(ticks: (long)(eta * TimeSpan.TicksPerMillisecond));
        }

        #endregion VisualFormat        
    }
}
