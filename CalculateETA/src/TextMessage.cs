﻿namespace CalculateETA
{
    public partial class CalculateETA
    {
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
        /// Sets all text messages Turkish.
        /// </summary>
        public static void SetTextMessageTurkish()
        {
            TextMessage.TextSecondOptionalPlural = " saniye";
            TextMessage.TextMinuteOptionalPlural = " dakika";
            TextMessage.TextHourOptionalPlural = " saat";
            TextMessage.TextDayOptionalPlural = " gün";

            TextMessage.TextSecond = " saniye";
            TextMessage.TextMinute = " dakika";
            TextMessage.TextHour = " saat";
            TextMessage.TextDay = " gün";

            TextMessage.TextSeconds = " saniye";
            TextMessage.TextMinutes = " dakika";
            TextMessage.TextHours = " saat";
            TextMessage.TextDays = " gün";

            TextMessage.TextUncalculatable = " hesaplanamıyor";
            TextMessage.TextNegative = " negatif";
            TextMessage.TextTooLong = " çok uzun süre";
            TextMessage.TextAnd = " ve ";

            TextMessage.TextNumberFormatSeparator = ".";
        }

        /// <summary>
        /// Sets all text messages with abbrevations.
        /// </summary>
        public static void SetTextMessageAbbrevations()
        {
            TextMessage.TextSecondOptionalPlural = " secs";
            TextMessage.TextMinuteOptionalPlural = " mins";
            TextMessage.TextHourOptionalPlural = " hours";
            TextMessage.TextDayOptionalPlural = " days";

            TextMessage.TextSecond = " s";
            TextMessage.TextMinute = " m";
            TextMessage.TextHour = " h";
            TextMessage.TextDay = " d";

            TextMessage.TextSeconds = " s";
            TextMessage.TextMinutes = " m";
            TextMessage.TextHours = " h";
            TextMessage.TextDays = " d";

            TextMessage.TextUncalculatable = " unc";
            TextMessage.TextNegative = " neg";
            TextMessage.TextTooLong = " too long";
            TextMessage.TextAnd = " and ";

            TextMessage.TextNumberFormatSeparator = ".";
        }
    }
}