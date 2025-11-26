using System;
using System.Globalization;

namespace GameRoundResult.Web.Configuration
{
    public static class ViewFormat
    {
        public const string NumberFormat = "#,##0.##";

        public const string _2DecimalsFormat = "#,##0.00";

        public const string TicketDateFormat = "MM/dd/yyyy";

        public const string TicketTimeFormat = "hh:mm:ss tt";

        public const string RoundTimeFormat = "hh:mm tt";

        public const string RoundTimeWithSecondFormat = "hh:mm:ss tt";

        public const string RoundDateFormat = "MM/dd/yyyy";

        public const string RoundDateTimeFormat = "MM/dd/yyyy hh:mm:ss tt";
    }

    public static class FormatHelper
    {
        public static string Format(this decimal value, int xMode = 1)
        {
            var decimalPlaces = (int)Math.Log10(xMode) + 2;
            var format = ViewFormat.NumberFormat + new string('#', decimalPlaces);
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        public static string Format2Decimals(this decimal value)
        {
            return value.ToString(ViewFormat._2DecimalsFormat, CultureInfo.InvariantCulture);
        }

        public static string RoundDateFormat(this DateTimeOffset dateTime)
        {
            return dateTime.ToString(ViewFormat.RoundDateFormat, CultureInfo.InvariantCulture);
        }

        public static string RoundTimeWithSecondFormat(this DateTimeOffset dateTime)
        {
            return dateTime.ToString(ViewFormat.RoundTimeWithSecondFormat, CultureInfo.InvariantCulture);
        }


        public static string RoundDateTimeFormat(this DateTimeOffset dateTime)
        {
            return dateTime.ToString(ViewFormat.RoundDateTimeFormat, CultureInfo.InvariantCulture);
        }

        public static string FormatOdds(this decimal value, bool frationalFormat)
        {
            var odds = frationalFormat == true ? value - 1 : value;
            return odds.ToString(ViewFormat.NumberFormat, CultureInfo.InvariantCulture);
        }

        public static string FormatOddsWithZero(this decimal value, bool frationalFormat)
        {
            if(value == 0)
            {
                return "-";
            }
            else
            {
                return FormatHelper.FormatOdds(value, frationalFormat);
            }            
        }
    }
}