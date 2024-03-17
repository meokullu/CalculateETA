using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// TextMessage has multiple properties to set text values for naming.
        /// Optional parameters are used on methods: <see cref="NameETA(long?)"/> <see cref="NameETAUnsafe(long)"/> <see cref="NameETAAsync(long?)"/>
        /// <br />
        /// Non-Optional parameters are used on methods: <see cref="NameETABetterVisual(long?)"/> <see cref="NameETABetterVisualUnsafe(long)"/>
        /// </summary>
        public class TextMessage
        {
            /// <summary>
            /// Stands to indicate second while it could be plural or singular. Default value is " second(s)"
            /// </summary>
            public static string TextSecondOptionalPlural = " second(s)";

            /// <summary>
            /// Stands to indicate minute while it could be plural or singular. Default value is " minute(s)"
            /// </summary>
            public static string TextMinuteOptionalPlural = " minute(s)";

            /// <summary>
            /// Stands to indicate hour while it could be plural or singular. Default value is " hour(s)"
            /// </summary>
            public static string TextHourOptionalPlural = " hour(s)";

            /// <summary>
            /// Stands to indicate day while it could be plural or singular. Default value is " day(s)"
            /// </summary>
            public static string TextDayOptionalPlural = " day(s)";

            /// <summary>
            /// Stands to indicate second while it could be singular. Default value is " second"
            /// </summary>
            public static string TextSecond = " second";

            /// <summary>
            /// Stands to indicate minute while it could be singular. Default value is " minute"
            /// </summary>
            public static string TextMinute = " minute";

            /// <summary>
            /// Stands to indicate hour while it could be singular. Default value is " hour"
            /// </summary>
            public static string TextHour = " hour";

            /// <summary>
            /// Stands to indicate day while it could be singular. Default value is " day"
            /// </summary>
            public static string TextDay = " day";

            /// <summary>
            /// Stands to indicate second while it could be plural. Default value is " seconds"
            /// </summary>
            public static string TextSeconds = " seconds";

            /// <summary>
            /// Stands to indicate minute while it could be plural. Default value is " minutes
            /// </summary>
            public static string TextMinutes = " minute";

            /// <summary>
            /// Stands to indicate hour while it could be plural. Default value is " hours
            /// </summary>
            public static string TextHours = " hours";

            /// <summary>
            /// Stands to indicate day while it could be plural. Default value is " days
            /// </summary>
            public static string TextDays = " days";

            /// <summary>
            /// Stands to indicate uncalculatable while ETA value is not possible to calculate. Default value is "Uncalculatable"
            /// </summary>
            public static string TextUncalculatable = "Uncalculatable";

            /// <summary>
            /// Stands to indicate negative while ETA value is negative. Default value is "Negative"
            /// </summary>
            public static string TextNegative = "Negative";

            /// <summary>
            /// Stands to indicate too long while ETA value is too long. Default value is "Too long"
            /// </summary>
            public static string TextTooLong = "Too long";

            /// <summary>
            /// Stands to indicate and between time indicators. Default value is " and " such as "1 hour and 2 minutes"
            /// </summary>
            public static string TextAnd = " and ";

            /// <summary>
            /// Stands to indicate and between time indicators on <see cref="NumberFormatETA(long?)"/> and <see cref="NumberFormatETAUnsafe(long)"/>.
            /// </summary>
            public static string TextNumberFormatSeparator = ":";
        }

        /// <summary>
        /// Returns estimated time to finish on naming format. (xxx ms or xx second(s) or xx minute(s) and yy (second(s)...) Recommended for high-cpu-intense algorithm
        /// </summary>
        /// <param name="etaTimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTimeInMs is null. Returns "Negative" if etaTimeInMs is negative. Returns string format.</returns>
        public static string NameETA(long? etaTimeInMs)
        {
            // Checking if the given parameter is null.
            if (etaTimeInMs == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return TextUncalculatable;
            }
            // Checking if the given parameter is negative.
            else if (etaTimeInMs < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return TextNegative;
            }

            // Checking if the given parameter is lower than one second. This is commented out for better performance.
            //else if (etaTimeInMs < 1000)
            //{
            //    //
            //    return $"{etaTimeInMs:0} ms";
            //}

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: etaTimeInMs.Value * TimeSpan.TicksPerMillisecond);

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
        /// <param name="etaTime">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTime is null. Returns "Negative" if etaTime is negative. Returns string format.</returns>
        public static string NameETA(double? etaTime)
        {
            // Checking if the given parameter is null.
            if (etaTime == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return TextUncalculatable;
            }
            // Checking if the given parameter is negative.
            else if (etaTime < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return TextNegative;
            }

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: (long)(etaTime.Value * TimeSpan.TicksPerMillisecond));

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
        /// <param name="etaTimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns string format.</returns>
        public static string NameETAUnsafe(long etaTimeInMs)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: etaTimeInMs * TimeSpan.TicksPerMillisecond);

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
        /// <param name="etaTime">The left time to finish. (milliseconds)</param>
        /// <returns>Returns string format.</returns>
        public static string NameETAUnsafe(double etaTime)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: (long)(etaTime * TimeSpan.TicksPerMillisecond));

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

        [Obsolete("Renamed as NameETAUnsafe(double etaTime)")]
        public static string NameETAUnSafe(double etaTime)
        {
            return NameETAUnsafe(etaTime);
        }

        /// <summary>
        /// Returns estimated time to finish on naming format. (xxx ms or xx second/seconds or xx minute/minutes and yy (second/seconds...) Recommended for low-cpu-intense algorithm in order to better visual output
        /// </summary>
        /// <param name="etaTimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTimeInMs is null. Returns "Negative" if etaTimeInMs is negative. Returns string format.</returns>
        public static string NameETABetterVisual(long? etaTimeInMs)
        {
            // Checking if the given parameter is null.
            if (etaTimeInMs == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return TextUncalculatable;
            }
            // Checking if the given parameter is negative.
            else if (etaTimeInMs < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return TextNegative;
            }

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: etaTimeInMs.Value * TimeSpan.TicksPerMillisecond);

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as x second or yy seconds.
                return $"{ts.Seconds} {(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as x minute or xx minutes, y second or yy seconds.
                return $"{ts.Minutes} {(ts.Minutes != 1 ? TextMinutes : TextMinute)}{TextAnd}{ts.Seconds} {(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as x hour or xx hours and, y minute or yy minutes.
                return $"{ts.Hours} {(ts.Hours != 1 ? TextHours : TextHour)}{TextAnd}{ts.Minutes} {(ts.Minutes != 1 ? TextMinutes : TextMinute)}";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as x day or xx days, y hour and yy hours.
                return $"{ts.Days} {(ts.Days != 1 ? TextDays : TextDay)}{TextAnd}{ts.Hours} {(ts.Hours != 1 ? TextHours : TextHour)}";
            }
        }

        /// <summary>
        /// Returns estimated time to finish on naming format. (xxx ms or xx second/seconds or xx minute/minutes and yy (second/seconds...) Recommended for low-cpu-intense algorithm in order to better visual output
        /// </summary>
        /// <param name="etaTime">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTime is null. Returns "Negative" if etaTime is negative. Returns string format.</returns>
        public static string NameETABetterVisual(double? etaTime)
        {
            // Checking if the given parameter is null.
            if (etaTime == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return TextUncalculatable;
            }
            // Checking if the given parameter is negative.
            else if (etaTime < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return TextNegative;
            }

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: (long)(etaTime.Value * TimeSpan.TicksPerMillisecond));

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as x second or yy seconds.
                return $"{ts.Seconds} {(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as x minute or xx minutes, y second or yy seconds.
                return $"{ts.Minutes} {(ts.Minutes != 1 ? TextMinutes : TextMinute)}{TextAnd}{ts.Seconds} {(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as x hour or xx hours and, y minute or yy minutes.
                return $"{ts.Hours} {(ts.Hours != 1 ? TextHours : TextHour)}{TextAnd}{ts.Minutes} {(ts.Minutes != 1 ? TextMinutes : TextMinute)}";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as x day or xx days, y hour and yy hours.
                return $"{ts.Days} {(ts.Days != 1 ? TextDays : TextDay)}{TextAnd}{ts.Hours} {(ts.Hours != 1 ? TextHours : TextHour)}";
            }
        }

        /// <summary>
        /// [Unsafe] Returns estimated time to finish on naming format. (xxx ms or xx second/seconds or xx minute/minutes and yy (second/seconds...) Recommended for low-cpu-intense algorithm in order to better visual output
        /// </summary>
        /// <param name="etaTimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns string format.</returns>
        public static string NameETABetterVisualUnsafe(long etaTimeInMs)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: etaTimeInMs * TimeSpan.TicksPerMillisecond);

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as x second or yy seconds.
                return $"{ts.Seconds} {(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as x minute or xx minutes, y second or yy seconds.
                return $"{ts.Minutes} {(ts.Minutes != 1 ? TextMinutes : TextMinute)}{TextAnd}{ts.Seconds} {(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as x hour or xx hours and, y minute or yy minutes.
                return $"{ts.Hours} {(ts.Hours != 1 ? TextHours : TextHour)}{TextAnd}{ts.Minutes} {(ts.Minutes != 1 ? TextMinutes : TextMinute)}";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as x day or xx days, y hour and yy hours.
                return $"{ts.Days} {(ts.Days != 1 ? TextDays : TextDay)}{TextAnd}{ts.Hours} {(ts.Hours != 1 ? TextHours : TextHour)}";
            }
        }

        /// <summary>
        /// [Unsafe] Returns estimated time to finish on naming format. (xxx ms or xx second/seconds or xx minute/minutes and yy (second/seconds...) Recommended for low-cpu-intense algorithm in order to better visual output
        /// </summary>
        /// <param name="etaTime">The left time to finish. (milliseconds)</param>
        public static string NameETABetterVisualUnsafe(double etaTime)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: (long)(etaTime * TimeSpan.TicksPerMillisecond));

            // Checking if the parameter is shorter than one minute.
            if (ts.TotalSeconds < 60)
            {
                // Returning ETA as x second or yy seconds.
                return $"{ts.Seconds} {(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one hour.
            else if (ts.TotalSeconds < 3600)
            {
                // Returning ETA as x minute or xx minutes, y second or yy seconds.
                return $"{ts.Minutes} {(ts.Minutes != 1 ? TextMinutes : TextMinute)}{TextAnd}{ts.Seconds} {(ts.Seconds != 1 ? TextSeconds : TextSecond)}";
            }
            // Checking if parameter is shorter than one day.
            else if (ts.TotalSeconds < 86400)
            {
                // Returning ETA as x hour or xx hours and, y minute or yy minutes.
                return $"{ts.Hours} {(ts.Hours != 1 ? TextHours : TextHour)}{TextAnd}{ts.Minutes} {(ts.Minutes != 1 ? TextMinutes : TextMinute)}";
            }
            // If parameter is longer than a day.
            else
            {
                // Returning ETA as x day or xx days, y hour and yy hours.
                return $"{ts.Days} {(ts.Days != 1 ? TextDays : TextDay)}{TextAnd}{ts.Hours} {(ts.Hours != 1 ? TextHours : TextHour)}";
            }
        }

        /// <summary>
        /// Returns estimated left time to finish on string format. (HH:MM.SS)
        /// </summary>
        /// <param name="etaTimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTimeInMs is null. Returns "Negative" if etaTimeInMs is negative. Returns "Too long" if etaTimeInMs is more than a day. Returns number format. (string)</returns>
        public static string NumberFormatETA(long? etaTimeInMs)
        {
            // Checking if the given parameter is null.
            if (etaTimeInMs == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return TextUncalculatable;
            }
            // Checking if the given parameter is negative.
            else if (etaTimeInMs < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return TextNegative;
            }
            // Checking if the given parameter value will result misleading return value. Estimation under 24 hours will return.
            else if (etaTimeInMs > 86400000)
            {
                // Returning "Too long" to indicaate the given parameter value will result estimation more than a day.
                return TextTooLong;
            }

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: etaTimeInMs.Value * TimeSpan.TicksPerMillisecond);

            // Returning ETA in number format. E.g 05:03:24
            return $"{ts.Hours}{TextNumberFormatSeparator}{ts.Minutes}{TextNumberFormatSeparator}{ts.Seconds}";
        }

        /// <summary>
        /// Returns estimated left time to finish on string format. (HH:MM.SS)
        /// </summary>
        /// <param name="etaTime">The left time to finish. (milliseconds)</param>
        /// <returns>Returns "Uncalculatable" if etaTime is null. Returns "Negative" if etaTime is negative. Returns "Too long" if etaTimeInMs is more than a day. Returns number format. (string)</returns>
        public static string NumberFormatETA(double? etaTime)
        {
            // Checking if the given parameter is null.
            if (etaTime == null)
            {
                // Returning "Uncalculatable" to indicate the given parameter was null.
                return TextUncalculatable;
            }
            // Checking if the given parameter is negative.
            else if (etaTime < 0)
            {
                // Returning "Negative" to indicate the given parameter was negative. 
                return TextNegative;
            }
            // Checking if the given parameter value will result misleading return value. Estimation under 24 hours will return.
            else if (etaTime > 86400000)
            {
                // Returning "Too long" to indicaate the given parameter value will result estimation more than a day.
                return TextTooLong;
            }

            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: (long)(etaTime.Value * TimeSpan.TicksPerMillisecond));

            // Returning ETA in number format. E.g 05:03:24
            return $"{ts.Hours}{TextNumberFormatSeparator}{ts.Minutes}{TextNumberFormatSeparator}{ts.Seconds}";
        }

        /// <summary>
        /// [Unsafe] Returns estimated left time to finish on string format. (HH:MM.SS)
        /// </summary>
        /// <param name="etaTimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns number format. (string)</returns>
        public static string NumberFormatETAUnsafe(long etaTimeInMs)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: etaTimeInMs * TimeSpan.TicksPerMillisecond);

            // Returning ETA in number format. E.g 05:03:24
            return $"{ts.Hours}{TextNumberFormatSeparator}{ts.Minutes}{TextNumberFormatSeparator}{ts.Seconds}";
        }

        /// <summary>
        /// [Unsafe] Returns estimated left time to finish on string format. (HH:MM.SS)
        /// </summary>
        /// <param name="etaTime">The left time to finish. (milliseconds)</param>
        /// <returns>Returns number format. (string)</returns>
        public static string NumberFormatETAUnsafe(double etaTime)
        {
            // Creating a TimeSpan from TimeSpan(ticks:)
            TimeSpan ts = new TimeSpan(ticks: (long)(etaTime * TimeSpan.TicksPerMillisecond));

            // Returning ETA in number format. E.g 05:03:24
            return $"{ts.Hours}{TextNumberFormatSeparator}{ts.Minutes}{TextNumberFormatSeparator}{ts.Seconds}";
        }

        /// <summary>
        /// Returns estimated left time to finish on TimeSpan format.
        /// </summary>
        /// <param name="etaTimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Returns TimeSpan.Zero if etaTimeInMs is either null or negative. Return TimeSpan format.</returns>
        public static TimeSpan? TimeSpanETA(long? etaTimeInMs)
        {
            // Checking if the given parameter is null.
            if (etaTimeInMs == null)
            {
                // Returning null to indicate the given parameter was null.
                return null;
            }
            // Checking if the given parameter is negative.
            else if (etaTimeInMs < 0)
            {
                // Returning TimeSpan.Zero to indicate the given parameter was negative.
                return TimeSpan.Zero;
            }

            // Returning ETA in TimeSpan.
            return new TimeSpan(ticks: etaTimeInMs.Value * TimeSpan.TicksPerMillisecond);
        }

        /// <summary>
        /// Returns estimated left time to finish on TimeSpan format.
        /// </summary>
        /// <param name="etaTime">The left time to finish. (milliseconds)</param>
        /// <returns>Returns TimeSpan.Zero if etaTime is either null or negative. Return TimeSpan format.</returns>
        public static TimeSpan? TimeSpanETA(double? etaTime)
        {
            // Checking if the given parameter is null.
            if (etaTime == null)
            {
                // Returning null to indicate the given parameter was null.
                return null;
            }
            // Checking if the given parameter is negative.
            else if (etaTime < 0)
            {
                // Returning TimeSpan.Zero to indicate the given parameter was negative.
                return TimeSpan.Zero;
            }

            // Returning ETA in TimeSpan.
            return new TimeSpan(ticks: (long)(etaTime.Value * TimeSpan.TicksPerMillisecond));
        }

        /// <summary>
        /// Returns estimated left time to finish on TimeSpan format.
        /// </summary>
        /// <param name="etaTimeInMs">The left time to finish. (milliseconds)</param>
        /// <returns>Return TimeSpan format.</returns>
        public static TimeSpan TimeSpanETAUnsafe(long etaTimeInMs)
        {
            // Returning Timespan created by parameter changed into ticks.
            return new TimeSpan(ticks: etaTimeInMs * TimeSpan.TicksPerMillisecond);
        }

        /// <summary>
        /// Returns estimated left time to finish on TimeSpan format.
        /// </summary>
        /// <param name="etaTime">The left time to finish. (milliseconds)</param>
        /// <returns>Return TimeSpan format.</returns>
        public static TimeSpan TimeSpanETAUnsafe(double etaTime)
        {
            // Returning Timespan created by parameter changed into ticks.
            return new TimeSpan(ticks: (long)(etaTime * TimeSpan.TicksPerMillisecond));
        }

        #endregion VisualFormat        
    }
}
